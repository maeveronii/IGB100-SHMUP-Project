using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Parts : MonoBehaviour
{

    public int xpGiven;
    // Start is called before the first frame update
    void Start()
    {
        transform.Rotate(new Vector3(90,0,0));
    }

    // Update is called once per frame
    void Update()
    {
        transform.Rotate(new Vector3(0, 0.1f, 0) );
    }

    void OnTriggerEnter(Collider other)
    {

        if(other.transform.tag == "Player") 
        {
            other.transform.GetComponent<Player>().addXP(xpGiven);
            Destroy(this.gameObject);
        }
    }
}
