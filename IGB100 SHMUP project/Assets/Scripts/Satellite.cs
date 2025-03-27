using System.Collections;
using System.Collections.Generic;
using System.Numerics;
using UnityEngine;

public class Satellite : MonoBehaviour
{
    public void SatelliteWin()
    {
        if(GameManager.instance.Player)
        {
            transform.position = new UnityEngine.Vector3(transform.position.x - 0.01f, transform.position.y, transform.position.z);
        }
        
    }
}
