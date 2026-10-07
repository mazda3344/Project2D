using UnityEngine;

[RequireComponent(typeof(SliderJoint2D))]
public class SliderPlatform : MonoBehaviour {
    [SerializeField, Range(0.01f, 2f)] private float motorSpeed = 1f;
    [SerializeField] private SliderJoint2D sliderJoint2D;

    private void Start() {
        if (sliderJoint2D == null) {
            sliderJoint2D = GetComponent<SliderJoint2D>();
        }
    }

    private void Update() {
        if (sliderJoint2D.limitState != JointLimitState2D.Inactive) {
            JointMotor2D motor2D = sliderJoint2D.motor;
            if (sliderJoint2D.limitState == JointLimitState2D.LowerLimit) {
                motor2D.motorSpeed = motorSpeed;
            } else if (sliderJoint2D.limitState == JointLimitState2D.UpperLimit) {
                motor2D.motorSpeed = -motorSpeed;
            }
            sliderJoint2D.motor = motor2D;
        }
    }
}
