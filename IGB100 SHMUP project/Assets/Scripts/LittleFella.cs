using System.Collections;
using System.Collections.Generic;
using System.Numerics;
using UnityEngine;
using UnityEngine.UIElements;
using Vector3 = UnityEngine.Vector3;
using Quaternion = UnityEngine.Quaternion;
using Vector2 = UnityEngine.Vector2;
using UnityEngine.Rendering;
using UnityEngine.Scripting.APIUpdating;

public class littleFella : MonoBehaviour
{
    public float moveSpeed = 0.0005f;
    public float moveReady;
    public float moveThreshold = 10;
    private Camera cam;
    // Start is called before the first frame update
    void Start()
    {
        cam = Camera.main;
        StartCoroutine("waitJustALittle");
    }

    // Update is called once per frame
    void Update()
    {
        Move();
    }

    public IEnumerator waitJustALittle()
    {
        while (moveReady < moveThreshold)
        {
            moveReady +=  0.001f;
            yield return null;
        }  
        yield return null;

    }

    public void Move()
    {
        if(moveReady >= moveThreshold)
        {
            transform.position += transform.forward * moveSpeed * Time.deltaTime;
            transform.position = new Vector3(transform.position.x, transform.position.y, transform.position.z + 0.001f);
        }
    }




}
