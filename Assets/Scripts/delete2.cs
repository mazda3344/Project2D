using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class delete2 : MonoBehaviour
{
    public GameObject arrow;
    void OnTriggerEnter2D(Collider2D other)
    {
        {
            arrow.SetActive(false);
        }
    }
}
