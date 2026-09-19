using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlatformMove2 : MonoBehaviour
{
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("PointPlatform2"))
        {
            
        }
    }
}
