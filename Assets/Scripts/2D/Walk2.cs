using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[RequireComponent(typeof(Animator))]
public class Walk2 : MonoBehaviour
{
    public string animString = "ToOpen";
    public Animator animator;
    void Update()
    {
        
        if (Input.GetKeyDown(KeyCode.D))
        {
            animator.SetTrigger(animString);
        }
    
    }
}
