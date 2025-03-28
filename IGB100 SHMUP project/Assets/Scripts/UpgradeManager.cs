using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UpgradeManager : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    IEnumerator fadeIn()
    {
        CanvasGroup canvasGroup = GetComponent<CanvasGroup>();
        while (canvasGroup.alpha < 1)
        {
            canvasGroup.alpha +=  0.005f;
            yield return null;
        }
        canvasGroup.interactable = true;    
        yield return null;

    }

    IEnumerator fadeOut()
    {
        CanvasGroup canvasGroup = GetComponent<CanvasGroup>();
        canvasGroup.interactable = false;  
        while (canvasGroup.alpha > 0)
        {
            canvasGroup.alpha -=  0.005f;
            yield return null;
        }  
        yield return null;

    }

    public void TurnOff()
    {
        this.enabled = false;
    }
}
