using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;


public class PlayerHealth : MonoBehaviour
{
    [Header("Interface")]
    [SerializeField] Image healthFill;
    [SerializeField] TextMeshProUGUI healthText;

    // Start is called before the first frame update
    void Start()
    {
        
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
}
