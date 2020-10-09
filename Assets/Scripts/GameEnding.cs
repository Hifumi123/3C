using UnityEngine;
using UnityEngine.SceneManagement;

public class GameEnding : MonoBehaviour
{
    public float fadeBuration = 1f;

    public float displayImageDuration = 1f;

    public GameObject lady;

    public CanvasGroup backgroundImageCanvasGroup;

    bool m_IsSuccessful;

    float m_Timer;

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject == lady)
            m_IsSuccessful = true;
    }

    void EndLevel()
    {
        m_Timer += Time.deltaTime;

        backgroundImageCanvasGroup.alpha = m_Timer / fadeBuration;

        if (m_Timer > fadeBuration + displayImageDuration)
            SceneManager.LoadScene(0);
    }

    void Update()
    {
        if (m_IsSuccessful)
            EndLevel();
    }
}
