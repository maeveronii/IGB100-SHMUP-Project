using System.Collections;
using System.Collections.Generic;
using System.Numerics;
using UnityEngine;
using Vector3 = UnityEngine.Vector3;
using Quaternion = UnityEngine.Quaternion;

public class EnemySpawner : MonoBehaviour
{
    [SerializeField]
    public GameObject slowCrawlEnemy;

    [SerializeField]
    public GameObject fastCrawlEnemy;

    [SerializeField]
    public GameObject slowShootEnemy;

    public float sceInterval = 2f;
    public float fceInterval = 10f;
    public float sseInterval = 5f;
    public float sceSpawnTime = 0f;
    public float fceSpawnTime = 120f;
    public float sseSpawnTime = 60f;

    public float upperX;
    public float lowerX;
    public float upperZ;
    public float lowerZ;

    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(spawnEnemy(sceInterval, slowCrawlEnemy, sceSpawnTime));
        StartCoroutine(spawnEnemy(fceInterval, fastCrawlEnemy, fceSpawnTime));
        StartCoroutine(spawnEnemy(sseInterval, slowShootEnemy, sseSpawnTime));
    }

    // Update is called once per frame
    void Update()
    {
    }
    
    public IEnumerator spawnEnemy(float interval, GameObject enemy, float spawntime)
    {
        yield return new WaitForSeconds (interval + Random.Range(0f,5f));
        if(GameManager.instance.secondsCount >= spawntime)
        {
            GameObject newEnemy = Instantiate(enemy, new Vector3(Random.Range(lowerX,upperX), 0f, Random.Range(lowerZ, upperZ)), Quaternion.identity);
        }
        StartCoroutine(spawnEnemy(interval, enemy, spawntime));
    }

    public void TurnOff()
    {
        this.enabled = false;
    }
}
