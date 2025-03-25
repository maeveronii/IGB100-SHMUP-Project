using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class GameManager : MonoBehaviour {

    //Singleton Setup
    public static GameManager instance = null;
    public float xBoundary = 30;
    public float zBoundary = 30;
    public float secondsCount;
    public GameObject Player;
    public Player playerScript;
    public bool gameIsPaused = false;
    public Button choiceOne;
    public Button choiceTwo;
    public Button choiceThree;
    public UpgradeManager upgradeManag;
    public AudioSource enemyExplosion;

    // Awake Checks - Singleton setup
    void Awake() {
        //Check if instance already exists
        if (instance == null)

            //if not, set instance to this
            instance = this;

        //If instance already exists and it's not this:
        else if (instance != this)
            //Then destroy this. This enforces our singleton pattern, meaning there can only ever be one instance of a GameManager.
            Destroy(gameObject);
    }

    public void Start()
    {
        Button btn1 = choiceOne.GetComponent<Button>();
		btn1.onClick.AddListener(UpgradeHealth);
        Button btn2 = choiceTwo.GetComponent<Button>();
		btn2.onClick.AddListener(UpgradeDamage);
        Button btn3 = choiceThree.GetComponent<Button>();
		btn3.onClick.AddListener(UpgradeSpeed);
        enemyExplosion = GetComponent<AudioSource>();
    }

    public void Update()
    {
        secondsCount += Time.deltaTime;
    }

    public void Upgrade()
    {
        StartCoroutine("timeSlow");
        upgradeManag.StartCoroutine("fadeIn");
    }

    public void UpgradeHealth()
    {
        Debug.Log("Upgrade Health!");
        playerScript.maxHealth += 25;
        playerScript.health += 25;
        playerScript.attack -= 1;
        StartCoroutine("timeFast");
        upgradeManag.StartCoroutine("fadeOut");
    }

     public void UpgradeDamage()
    {
        Debug.Log("Upgrade Damage!");
        playerScript.attack += 2;
        playerScript.moveSpeed -= 25;
        StartCoroutine("timeFast");
        upgradeManag.StartCoroutine("fadeOut");
    }

     public void UpgradeSpeed()
    {
        Debug.Log("Upgrade Speed!");
        playerScript.moveSpeed += 50;
        playerScript.maxHealth -= 15;
        playerScript.health -= 15;
        StartCoroutine("timeFast");
        upgradeManag.StartCoroutine("fadeOut");
    }

    public IEnumerator timeSlow()
    {
        while(Time.timeScale > 0.005)
        {
            Time.timeScale -= 0.005f;
            yield return null;
        }
    }
    public IEnumerator timeFast()
    {
        while(Time.timeScale < 1)
        {
            Time.timeScale += 0.05f;
            yield return null;
        }
    }

    public void playEnemyExplosion()
    {
        enemyExplosion.Play(0);
    }
}
