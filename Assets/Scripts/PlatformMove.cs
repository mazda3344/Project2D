using System.Collections;
using UnityEngine;

[RequireComponent(typeof(SliderJoint2D))]
public class AdvancedSliderPlatform : MonoBehaviour
{   
     private float speed = 1f;
     private float waitTime = 3f;

    private SliderJoint2D sliderJoint;
    private JointMotor2D motor;
    private bool isWaiting = false;

    void Start()
    {
        sliderJoint = GetComponent<SliderJoint2D>();
        motor = sliderJoint.motor;
        
        motor.motorSpeed = speed;
        sliderJoint.motor = motor;
    }

    void FixedUpdate()
    {
        if (isWaiting) return;

        if (sliderJoint.limitState == JointLimitState2D.UpperLimit && motor.motorSpeed > 0)
        {
            StartCoroutine(WaitAndSwitchDirection(-speed));
        }

        else if (sliderJoint.limitState == JointLimitState2D.LowerLimit && motor.motorSpeed < 0)
        {
            StartCoroutine(WaitAndSwitchDirection(speed));
        }
    }

    private IEnumerator WaitAndSwitchDirection(float newSpeed)
    {
        isWaiting = true;

        motor.motorSpeed = 0;
        sliderJoint.motor = motor;

        yield return new WaitForSeconds(waitTime);

        motor.motorSpeed = newSpeed;
        sliderJoint.motor = motor;

        isWaiting = false;
    }
}

