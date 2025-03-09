using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Scripting.APIUpdating;

public class Projectile : MonoBehaviour
{
    public float lifeTime = 3.0f;
    public float moveSpeed = 500f;
    public float damage;
    public bool playerShooting;

    // Start is called before the first frame update
    void Start()
    {
        Destroy(this.gameObject, lifeTime);
    }

    // Update is called once per frame
    void Update()
    {
        Move();
    }

    private void Move()
    {
        transform.position += Time.deltaTime * moveSpeed * transform.forward;
    }

    void OnTriggerEnter(Collider other)
    {
        if(playerShooting == true)
        {
            if(other.transform.tag == "Enemy") 
            {
                other.GetComponent<Enemy>().takeDamage(damage);
                Destroy(this.gameObject);
            }
        }
        else if(playerShooting == false)
        {
            if(other.transform.tag == "Player")
            {
                other.GetComponent<Player>().takeDamage(damage);
                Destroy(this.gameObject);
            }
        }
    }
}
