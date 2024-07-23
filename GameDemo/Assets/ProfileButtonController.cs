using UnityEngine;

public class PanelToggle : MonoBehaviour
{
    public GameObject panel;

    void Start()
    {
        // Paneli baþlangýçta kapalý yap
        panel.SetActive(false);
    }

    public void TogglePanel()
    {
        // Paneli açýp kapat
        if (panel.activeSelf)
        {
            panel.SetActive(true);
        }
        else
        {
            panel.SetActive(false);
        }
    }
}
