using UnityEngine;

public class PanelToggle : MonoBehaviour
{
    public GameObject panel;

    void Start()
    {
        // Paneli ba�lang��ta kapal� yap
        panel.SetActive(false);
    }

    public void TogglePanel()
    {
        // Paneli a��p kapat
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
