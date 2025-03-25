using System.Collections;
using System.Collections.Generic;
using System.Numerics;
using UnityEngine;
using UnityEngine.Scripting.APIUpdating;
using Vector3 = UnityEngine.Vector3;
using Quaternion = UnityEngine.Quaternion;
using System.Security.Cryptography;

public class Enemy : MonoBehaviour
{
    //stats
    public float moveSpeed = 25f;
    public float health = 100f;
    public float attack = 25f;
    private float physAttackSpeed = 1f;
    private float shootAttackSpeed = 1f;
    public bool canShoot = false;
    public GameObject projectile;
    
    //other
    public GameObject deathEffect;
    public GameObject parts;
    private float attackTime;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Move();
        
        if(canShoot == true)
        {
            Shoot();
        }
    }

    //Enemy Movement - Move towards the player
    private void Move()
    {
        if(GameManager.instance.Player)
            transform.LookAt(GameManager.instance.Player.transform.position);
        transform.position += transform.forward * moveSpeed * Time.deltaTime;
        if(transform.position.y != 0)
        {
            transform.position = new Vector3(transform.position.x, 0f, transform.position.z);
        }
    }

    public void takeDamage(float damage)
    {
        health -= damage;

        if(health <= 0)
        {
            GameManager.instance.playEnemyExplosion();
            Destroy(this.gameObject);
            Instantiate(deathEffect, transform.position, transform.rotation);
            Instantiate(parts, transform.position, transform.rotation);
        }
    }


    private void Shoot()
    {
        if(Time.time > attackTime)
        {
            GameObject enemyBullet = Instantiate(projectile, transform.position, transform.rotation);
            enemyBullet.GetComponent<Projectile>().damage = attack;
            enemyBullet.GetComponent<Projectile>().moveSpeed = 50f;
            enemyBullet.GetComponent<Projectile>().playerShooting = false;
            attackTime = Time.time + shootAttackSpeed;
        }
    }

    void OnTriggerStay(Collider other)
    {
        if(other.transform.tag == "Player" && Time.time > attackTime)
        {
            other.transform.GetComponent<Player>().takeDamage(attack);
            attackTime = Time.time + physAttackSpeed;
        }
    }
}
