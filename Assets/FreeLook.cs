using Unity.Cinemachine;
using UnityEngine;

public class FreeLookCam : MonoBehaviour
{
    private CinemachineFreeLook freeLookCamera;

    [Header("Sensitivity Settings")]
    public float xSensitivityMultiplier = 2f; // Multiplier for X axis sensitivity
    public float ySensitivityMultiplier = 2f; // Multiplier for Y axis sensitivity

    void Start()
    {
        freeLookCamera = GetComponent<CinemachineFreeLook>();

        if (freeLookCamera != null)
        {
            // Adjust X axis sensitivity
            freeLookCamera.m_XAxis.m_MaxSpeed = 300f * xSensitivityMultiplier;
            freeLookCamera.m_XAxis.m_AccelTime = 0.1f / xSensitivityMultiplier;
            freeLookCamera.m_XAxis.m_DecelTime = 0.1f / xSensitivityMultiplier;

            // Adjust Y axis sensitivity
            freeLookCamera.m_YAxis.m_MaxSpeed = 2f * ySensitivityMultiplier;
            freeLookCamera.m_YAxis.m_AccelTime = 0.1f / ySensitivityMultiplier;
            freeLookCamera.m_YAxis.m_DecelTime = 0.1f / ySensitivityMultiplier;
        }
        else
        {
            Debug.LogError("CinemachineFreeLook component not found!");
        }
    }
}