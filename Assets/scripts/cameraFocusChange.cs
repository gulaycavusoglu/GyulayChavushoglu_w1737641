using System.Diagnostics;
using UnityEngine;
using Debug = UnityEngine.Debug;

public class ActivateCharacters : MonoBehaviour
{
    public GameObject dialoguePanel;
    public GameObject player;
    public GameObject npcs;
    public Transform cameraTarget;
    public Camera mainCamera;

    public GameObject thirdPersonCam;
    public Camera camera;
    public GameObject timerUI;
    public GameObject infoButton;

    public void OnFindSurvivorsClicked()
    {
        if (dialoguePanel == null || player == null || npcs == null || cameraTarget == null || mainCamera == null)
        {
            Debug.LogError("One or more required references are missing!");
            return;
        }

        // Hide the dialogue panel
        dialoguePanel.SetActive(false);

        // Show timer and info UI
        if (timerUI != null && infoButton != null)
        {
            timerUI.SetActive(true);
            infoButton.SetActive(true);
        }

        // Find and activate FreeLook Camera
        thirdPersonCam = GameObject.Find("FreeLook Camera");

        if (thirdPersonCam != null)
        {
            mainCamera.enabled = false;
            thirdPersonCam.SetActive(true);
        }
        else
        {
            Debug.LogWarning("ThirdPersonCamera reference is not assigned or found.");
        }
    }
}