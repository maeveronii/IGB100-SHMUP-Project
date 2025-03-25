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
    public float distanceToSatellite = 3000;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        updateTimeSurvived();
    }

    public void updateHealth(float currentHealth, float maxHealth)
    {
        healthText.text = currentHealth + " / " + maxHealth;
    }
    public void takeDamage(float currentHealth, float maxHealth)
    {
        healthFill.fillAmount = (float)currentHealth / (float)maxHealth;
    }

    public void updateTimeSurvived()
    {
        distanceToSatellite -= (Time.deltaTime * 10);
        distanceToSatellite = Mathf.Ceil(distanceToSatellite * 10.0f) * 0.1f;
        timeSurvived.text = "Meters to satellite: " + distanceToSatellite + "km";
    }
}
