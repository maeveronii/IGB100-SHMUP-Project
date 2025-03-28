using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class WinPanel : MonoBehaviour
{
    // Start is called before the first frame update
    public IEnumerator winStart()
    {
        CanvasGroup canvasGroup = GetComponent<CanvasGroup>();
        while (canvasGroup.alpha < 1)
        {
            canvasGroup.alpha +=  0.005f;
            Debug.Log(canvasGroup.alpha);
            yield return new WaitForSeconds(0.2f);
        } 
        SceneManager.LoadScene(0); 
        yield return null;
    }

    public void winStart2()
    {
        StartCoroutine("winStart");
    }
}
