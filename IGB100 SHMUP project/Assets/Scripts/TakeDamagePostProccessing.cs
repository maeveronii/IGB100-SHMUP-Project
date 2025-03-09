using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering.PostProcessing;

public class TakeDamagePostProccessing : MonoBehaviour
{
    public float intensity = 0;

    PostProcessVolume volume;
    Vignette vignette;

    // Start is called before the first frame update
    void Start()
    {
        volume = GetComponent<PostProcessVolume>();
        volume.profile.TryGetSettings<Vignette>(out vignette);

        if(!vignette)
        {
            Debug.Log("error vingette empty");
        }

        else
        {
            vignette.enabled.Override(false);
        }

    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public IEnumerator takeDamageEffect()
    {
        
        intensity = 0.5f;

        vignette.enabled.Override(true);
        vignette.intensity.Override(0.5f);

        yield return new WaitForSeconds(0.4f);

        while (intensity > 0)
        {
            intensity -= 0.01f;
            if (intensity < 0 ) intensity = 0;
            vignette.intensity.Override(intensity);
            yield return new WaitForSeconds(0.1f);
        }

        vignette.enabled.Override(false);
        yield break;
    }

}
