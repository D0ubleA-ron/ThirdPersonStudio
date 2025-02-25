using Unity.Cinemachine;
using UnityEngine;

public class FreeLookCam : MonoBehaviour
{
    private CinemachineFreeLook freeLookCamera;

    void Start()
    {
        freeLookCamera = GetComponent<CinemachineFreeLook>();

        if (freeLookCamera != null)
        {
            // Example: Adjust FreeLook Camera settings
            freeLookCamera.m_XAxis.m_MaxSpeed = 400f;
            freeLookCamera.m_YAxis.m_MaxSpeed = 2f;
        }
        else
        {
            Debug.LogError("CinemachineFreeLook component not found!");
        }
    }
}