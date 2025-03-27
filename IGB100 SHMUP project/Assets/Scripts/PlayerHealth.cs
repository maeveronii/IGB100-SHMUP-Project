using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using System;


public class PlayerHealth : MonoBehaviour
{
    [Header("Interface")]
    [SerializeField] Image healthFill;
    [SerializeField] TextMeshProUGUI healthText;
    [SerializeField] TextMeshProUGUI timeSurvived;
    public float distanceToSatellite = 3600;

    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine("updateTimeSurvived");
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void updateHealth(float currentHealth, float maxHealth)
    {
        healthText.text = currentHealth + " / " + maxHealth;
    }
    public void takeDamage(float currentHealth, float maxHealth)
    {
        healthFill.fillAmount = (float)currentHealth / (float)maxHealth;
    }

    public IEnumerator updateTimeSurvived()
    {
        distanceToSatellite -= 2;
        timeSurvived.text = "Meters to satellite: " + distanceToSatellite + "km";
        yield return new WaitForSeconds(0.1f);
        StartCoroutine("updateTimeSurvived");

    }
}
