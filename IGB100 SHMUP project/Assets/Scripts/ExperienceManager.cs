using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class ExperienceManager : MonoBehaviour
{
    [Header("Experience")]

    int currentLevel, currentExperience, overFlow;
    int maxExperience = 10;

    [Header("Interface")]
    [SerializeField] TextMeshProUGUI levelText;
    [SerializeField] TextMeshProUGUI experienceText;
    [SerializeField] Image experienceFill;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void addExperience(int xpGained)
    {
        currentExperience += xpGained;
        checkForLevelUp();
        updateInterface();
    }

    void checkForLevelUp()
    {
        if(currentExperience >= maxExperience)
        {
            currentLevel++;
            updateLevel();
            GameManager.instance.Upgrade();
        }
    }

    void updateLevel()
    {
        
        currentExperience -= maxExperience;
        maxExperience += 5;
        updateInterface();
    }

    void updateInterface()
    {
        int start = currentExperience;
        int end = maxExperience;

        levelText.text = currentLevel.ToString();
        experienceText.text = start + " parts / " + end + " parts";
        experienceFill.fillAmount = (float)start / (float)end;
    }
}
