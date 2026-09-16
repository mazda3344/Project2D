using UnityEngine;

public class SliderPlatform : MonoBehaviour {
    [SerializeField] private bool useColliders;
    [SerializeField] private Collider2D topCollider, bottomCollider;
    [SerializeField, Range(0.01f, 2f)] private float motorSpeed = 1f;
    [SerializeField] private SliderJoint2D sliderJoint2D;

    private void Start() {
        if (sliderJoint2D == null) {
            sliderJoint2D = GetComponent<SliderJoint2D>();
        }
    }

    private void Update() {
        if (!useColliders) {
            // Debug.Log("SliderPlatform::Update(); -- limitState:" + sliderJoint2D.limitState);
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

    private void OnTriggerEnter2D(Collider2D other) {
        Debug.Log("SliderPlatform::OnTriggerEnter2D(); -- other:" + other);
        if (useColliders) {
            JointMotor2D motor2D = sliderJoint2D.motor;
            if (other == topCollider) {
                motor2D.motorSpeed = -motorSpeed;
            } else if (other == bottomCollider) {
                motor2D.motorSpeed = motorSpeed;
            }
            sliderJoint2D.motor = motor2D;
            // sliderJoint2D.limits.
        }
    }
}
