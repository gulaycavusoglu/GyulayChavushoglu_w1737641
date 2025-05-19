using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Debug = UnityEngine.Debug;  // Resolve ambiguity with System.Diagnostics.Debug

public class triggerDialogue : StateMachineBehaviour
{
    // Specify the relative path from the Animator's GameObject to your UI Panel.
    // Adjust this path according to your hierarchy (e.g., "Canvas/Panel")
    private string uiPanelPath = "Canvas/Panel";

    // Cache the reference so you don't have to search every time.
    private GameObject uiPanel;

    // Called when entering the animation state.
    public override void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        // If we haven't found the panel yet, try to locate it.
        if (uiPanel == null)
        {
            Transform panelTransform = animator.transform.Find(uiPanelPath);
            if (panelTransform != null)
            {
                uiPanel = panelTransform.gameObject;
            }
            else
            {
                Debug.LogWarning("UI Panel not found at path: " + uiPanelPath);
                return;
            }
        }

        // Activate the panel.
        uiPanel.SetActive(true);
    }

    // Called when exiting the animation state.
    public override void OnStateExit(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        if (uiPanel != null)
        {
            uiPanel.SetActive(false);
        }
    }
}
