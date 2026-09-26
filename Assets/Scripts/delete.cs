using System.Collections;
using System.Collections.Generic;
using Microsoft.Unity.VisualStudio.Editor;
using Unity.VisualScripting;
using UnityEngine;

public class delete : MonoBehaviour
{
    public GameObject Box1;
    public GameObject Box2;
    void OnTriggerEnter2D(Collider2D other)
    {
                Box1.SetActive(false);
                Box2.SetActive(false);
    }
    void OnTriggerExit2D(Collider2D other)
    {
        
            
                Box1.SetActive(false);
                Box2.SetActive(false);
    }
}
