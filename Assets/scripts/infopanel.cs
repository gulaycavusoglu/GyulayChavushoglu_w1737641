using UnityEngine;

public class ToggleDialogue : MonoBehaviour
{
    public GameObject dialoguePanel;

    void Start()
    {
        if (dialoguePanel != null && dialoguePanel.activeSelf)
            dialoguePanel.SetActive(false); // safely disable it at start
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            if(dialoguePanel != null)
                dialoguePanel.SetActive(true);
        }
    }
}
