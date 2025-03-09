using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class ExperienceManager : MonoBehaviour
{
    [Header("Experience")]
    [SerializeField] AnimationCurve experienceCurve;

    int currentLevel, totalExperience;
    int previousLevelsExpereience;
    int nextLevelsExperience = 10;

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
        Debug.Log(xpGained);
        totalExperience += xpGained;
        Debug.Log(totalExperience);
        checkForLevelUp();
        updateInterface();
    }

    void checkForLevelUp()
    {
        if(totalExperience >= nextLevelsExperience)
        {
            currentLevel++;
            updateLevel();
            //add level up system

        }
    }

    void updateLevel()
    {
        previousLevelsExpereience = (int)experienceCurve.Evaluate(currentLevel);
        nextLevelsExperience = (int)experienceCurve.Evaluate(currentLevel + 1);
        updateInterface();
    }

    void updateInterface()
    {
        int start = totalExperience - previousLevelsExpereience;
        int end = nextLevelsExperience - previousLevelsExpereience;

        levelText.text = currentLevel.ToString();
        experienceText.text = start + " parts / " + end + " parts";
        experienceFill.fillAmount = (float)start / (float)end;
    }
}
