using UnityEngine;

public class Movement : MonoBehaviour
{
    public float moveSpeed = 0.5f;

    public float turnSpeed = 2f;

    Animator m_Animator;

    Rigidbody m_Rigidbady;

    Vector3 m_Movement;

    Quaternion m_Rotation = Quaternion.identity;

    void Start()
    {
        m_Animator = GetComponent<Animator>();

        m_Rigidbady = GetComponent<Rigidbody>();
    }

    void FixedUpdate()
    {
        float horizontal = Input.GetAxis("Horizontal");
        float vertical = Input.GetAxis("Vertical");

        Vector3 rotationTarget = new Vector3();
        if (!Mathf.Approximately(horizontal, 0f))
        {
            if (horizontal > 0)
            {
                rotationTarget.Set(transform.forward.z, 0f, -transform.forward.x);
                // print(transform.forward + ", " + rotationTarget);
            }
            else
            {
                rotationTarget.Set(-transform.forward.z, 0f, transform.forward.x);
                // print(transform.forward + ", " + rotationTarget);
            }

            rotationTarget.Normalize();
        }

        bool isWalking = !Mathf.Approximately(vertical, 0f);

        m_Animator.SetBool("IsWalking", isWalking);

        if (isWalking)
        {
            if (vertical > 0)
                m_Movement.Set(transform.forward.x, transform.forward.y, transform.forward.z);
            else
                m_Movement.Set(-transform.forward.x, transform.forward.y, -transform.forward.z);

            m_Movement.Normalize();
        }
        else
            m_Movement.Set(0, 0, 0);

        Vector3 desiredForward = Vector3.RotateTowards(transform.forward, rotationTarget, turnSpeed * Time.deltaTime, 0f);

        m_Rotation = Quaternion.LookRotation(desiredForward);
    }

    void OnAnimatorMove()
    {
        m_Rigidbady.MovePosition(m_Rigidbady.position + m_Movement * moveSpeed);
        m_Rigidbady.MoveRotation(m_Rotation);
    }
}
