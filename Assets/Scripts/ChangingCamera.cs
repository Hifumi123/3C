using UnityEngine;
using Cinemachine;

public class ChangingCamera : MonoBehaviour
{
    public CinemachineVirtualCameraBase freeLook;

    public CinemachineVirtualCameraBase head;

    void Start()
    {
        freeLook.VirtualCameraGameObject.SetActive(true);
        head.VirtualCameraGameObject.SetActive(false);
    }

    void Update()
    {
        if (Input.GetMouseButton(1))
        {
            freeLook.VirtualCameraGameObject.SetActive(false);
            head.VirtualCameraGameObject.SetActive(true);
        }
        else
        {
            freeLook.VirtualCameraGameObject.SetActive(true);
            head.VirtualCameraGameObject.SetActive(false);
        }
    }
}
