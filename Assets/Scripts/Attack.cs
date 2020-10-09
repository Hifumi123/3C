using UnityEngine;

public class Attack : MonoBehaviour
{
    Animator m_Animator;

    void Start()
    {
        m_Animator = GetComponent<Animator>();
    }

    void Update()
    {
        m_Animator.SetBool("IsAttacking", Input.GetMouseButton(0));
    }
}
