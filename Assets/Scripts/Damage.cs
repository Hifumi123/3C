using UnityEngine;

public class Damage : MonoBehaviour
{
    public Transform ladyLeftHand;

    public Transform ladyRightHand;

    Animator m_Animator;

    bool m_IsHurted;

    void Start()
    {
        m_Animator = GetComponentInParent<Animator>();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.transform == ladyLeftHand || other.transform == ladyRightHand)
        {
            m_IsHurted = true;
            // print("Enter");
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.transform == ladyLeftHand || other.transform == ladyRightHand)
        {
            m_IsHurted = false;
            // print("Exit");
        }
    }

    void Update()
    {
        m_Animator.SetBool("IsHurted", m_IsHurted);
    }
}
