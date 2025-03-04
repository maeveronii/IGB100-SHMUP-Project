using System.Collections;
using System.Collections.Generic;
using System.Numerics;
using UnityEngine;
using Vector3 = UnityEngine.Vector3;

public class Player : MonoBehaviour
{
    //stats
    public float moveSpeed = 100f;
    public float attack = 5f;
    public float attackSpeed = 5f;
    public float attackTime;

    //other
    private UnityEngine.Vector3 position;
    public GameObject projectile;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {   
        Shoot();
    }

    void FixedUpdate()
    {
        Move();
    }

    private void Move()
    {
        float moveHorizontal = Input.GetAxis("Horizontal");
        float moveVertical = Input.GetAxis("Vertical");
        Vector3 move = new Vector3(moveHorizontal, 0.0f, moveVertical);
        GetComponent<Rigidbody>().velocity = move * moveSpeed * Time.fixedDeltaTime;
    }

    private void Shoot()
    {
        if(Input.GetKey("space") && Time.time > attackTime)
        {
            Instantiate(projectile, transform.position, transform.rotation);
            attackTime = Time.time + attackSpeed;
        }
    }
}
