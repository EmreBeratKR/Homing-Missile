using EmreBeratUtils.Helpers;
using UnityEngine;

public class MissileGuidance : MonoBehaviour
{
    [SerializeField] private Rigidbody body;
    [SerializeField] private Transform target;
    [SerializeField] private Clamp steeringClamp;
    [SerializeField] private float forwardSpeed;

    private Vector3 targetPosition => target.position;
    
    private Vector3 forward => this.transform.forward;
    private Vector3 right => this.transform.right;
    private Vector3 up => this.transform.up;

    private Vector3 position
    {
        get => this.transform.position;
        set => this.transform.position = value;
    }
    private Vector3 rotation
    {
        get => this.transform.eulerAngles;
        set => this.transform.eulerAngles = value;
    }
    
    private float steeringY
    {
        get
        {
            var result = Vector3.Dot(this.right, (targetPosition - this.position).normalized) * steeringClamp.max;

            if (result >= 0)
            {

                return Mathf.Clamp(result, steeringClamp.min, steeringClamp.max);
            }

            return Mathf.Clamp(result, -steeringClamp.max, -steeringClamp.min);
        }
    }

    private float steeringX
    {
        get
        {
            var result = Vector3.Dot(this.up, (targetPosition - this.position).normalized) * steeringClamp.max;

            if (result >= 0)
            {
                return Mathf.Clamp(result, steeringClamp.min, steeringClamp.max) * -1;
            }

            return Mathf.Clamp(result, -steeringClamp.max, -steeringClamp.min) * -1;
        }
    }

    private void Update()
    {
        Guide();
    }

    private void Guide()
    {
        this.transform.RotateAround(this.position, this.up, steeringY);
        this.transform.RotateAround(this.position, this.right, steeringX);

        body.velocity = this.forward * forwardSpeed;
    }


    private void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawLine(this.position, targetPosition);
    }
    
}
