using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TakeDamageCamera : MonoBehaviour
{
    public float shakeDuration = 0.2f;
    public AnimationCurve curve;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public IEnumerator takeDamageShake()
    {
        Vector3 startPosition = transform.position;
        float elapsedTime = 0f;

        while(elapsedTime < shakeDuration)
        {
            elapsedTime += Time.deltaTime;
            float strength = curve.Evaluate(elapsedTime / shakeDuration);
            transform.position = startPosition + Random.insideUnitSphere * strength;
            yield return null;
        }
        transform.position = startPosition;
    }
}
