using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Animator))]
public class Walk1 : MonoBehaviour
{
    public string animString = "ToOpen";
    public Animator animator;
    void Update()
    {
        
        if (Input.GetKeyDown(KeyCode.A))
        {
            animator.SetTrigger(animString);
        }
    
    }
}
