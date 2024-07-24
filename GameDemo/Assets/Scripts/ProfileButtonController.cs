using UnityEngine;
using UnityEngine.UI;

public class PanelToggle : MonoBehaviour
{
    public GameObject panel;
    public Button button;

    void Start()
    {
        // Initially set the panel to inactive
        if (panel != null)
        {
            panel.SetActive(false);
        }
        else
        {
            Debug.LogError("Panel is not assigned.");
        }

        if (button != null)
        {
            button.onClick.AddListener(TogglePanel);
        }
        else
        {
            Debug.LogError("Button is not assigned.");
        }
    }

    public void TogglePanel()
    {
        // Toggle the panel's active state
        if (panel != null)
        {
            panel.SetActive(!panel.activeSelf);
        }
        else
        {
            Debug.LogError("Panel is not assigned.");
        }
    }
}
