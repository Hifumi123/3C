using UnityEngine;

public class GameExit : MonoBehaviour
{
    void Update()
    {
        if (Input.GetButton("Cancel"))
            Application.Quit();
    }
}
