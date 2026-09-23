using System.Collections;
using System.Collections.Generic;
using Microsoft.Unity.VisualStudio.Editor;
using UnityEngine;

public class delete : MonoBehaviour
{
    public GameObject Box1;
    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Strela"))
        {
                Destroy(Box1);
        }
    }
}
