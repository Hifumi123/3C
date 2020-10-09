using UnityEngine;

public class Jump : MonoBehaviour
{
    public float upForceValue = 500f;

    public float groundThreshold = 0.1f;

    Rigidbody m_Rigidbody;

    bool m_IsJumping;

    float m_BaseY;

    void Start()
    {
        m_Rigidbody = GetComponent<Rigidbody>();
    }

    void FixedUpdate()
    {
        if (Mathf.Abs(transform.position.y - m_BaseY) < groundThreshold)
            m_IsJumping = false;

        if (Input.GetButton("Jump") && !m_IsJumping)
        {
            m_IsJumping = true;

            m_BaseY = m_Rigidbody.transform.position.y;

            m_Rigidbody.AddForce(Vector3.up * upForceValue);
        }
    }
}
