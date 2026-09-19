using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlatformMove1 : MonoBehaviour
{
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("PointPlatform1"))
        {
            
        }
    }
}
