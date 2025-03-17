using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Numerics;
using UnityEngine;
using Vector3 = UnityEngine.Vector3;
using Debug = UnityEngine.Debug;
using Quaternion = UnityEngine.Quaternion;

public class Player : MonoBehaviour
{
    //stats
    public float moveSpeed = 1000f; 
    public float maxHealth = 250f;
    public float health = 250f;
    public float attack = 10f;
    public float attackSpeed = 5f;
    public float attackTime;

    //other
    private UnityEngine.Vector3 position;
    public GameObject projectile;

    public TakeDamagePostProccessing postProcess;
    public TakeDamageCamera shakeScreen;
    public ExperienceManager experienceManag;
    public PlayerHealth healthManag;


    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {   
        gameBoundary();
        Shoot();
        healthManag.updateHealth(health, maxHealth);
    }

    void FixedUpdate()
    {
        Move();
    }

    private void Move()
    {
        var direction = Input.mousePosition - Camera.main.WorldToScreenPoint(transform.position);
        var angle = Mathf.Atan2(direction.x, direction.y) * Mathf.Rad2Deg;
        transform.rotation = Quaternion.AngleAxis(angle, Vector3.up); //thank you gwen
        float moveHorizontal = Input.GetAxis("Horizontal");
        float moveVertical = Input.GetAxis("Vertical");
        Vector3 move = new Vector3(moveHorizontal, 0.0f, moveVertical);
        GetComponent<Rigidbody>().velocity = move * moveSpeed * Time.fixedDeltaTime;
    }

    private void Shoot()
    {
        if(Input.GetKey("space") && Time.time > attackTime)
        {
            GameObject playerBullet = Instantiate(projectile, transform.position, transform.rotation);
            playerBullet.GetComponent<Projectile>().damage = attack;
            playerBullet.GetComponent<Projectile>().playerShooting = true;
            attackTime = Time.time + attackSpeed;
        }
    }

    private void gameBoundary()
    {
        //X bound check (thank you gwen)
        if(transform.position.x > GameManager.instance.xBoundary)
            transform.position = new Vector3(GameManager.instance.xBoundary, transform.position.y, transform.position.z);
        else if (transform.position.x < -GameManager.instance.xBoundary)
            transform.position = new Vector3(-GameManager.instance.xBoundary, transform.position.y, transform.position.z);

        //Z bound check (thank you gwen)
        if(transform.position.z > GameManager.instance.zBoundary)
            transform.position = new Vector3(transform.position.x, transform.position.y, GameManager.instance.zBoundary);
        else if (transform.position.z < -GameManager.instance.zBoundary)
            transform.position = new Vector3(transform.position.x, transform.position.y, -GameManager.instance.zBoundary);
    }

    public void takeDamage(float damage)
    {
        postProcess.StartCoroutine("takeDamageEffect");
        shakeScreen.StartCoroutine("takeDamageShake");
        health -= damage;
        healthManag.takeDamage(health, maxHealth);

        if(health <= 0)
        {
            Destroy(this.gameObject);
        }
    }
    
    public void addXP(int xpGained)
    {
        experienceManag.addExperience(xpGained);
    }
}
