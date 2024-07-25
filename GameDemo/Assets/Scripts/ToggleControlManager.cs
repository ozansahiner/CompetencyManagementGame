using UnityEngine;
using UnityEngine.UI;

public class ToggleManager : MonoBehaviour
{
    private Toggle1Sound toggle1Sound;
    private Toggle2Sound toggle2Sound;

    void Start()
    {
        // Toggle1Sound ve Toggle2Sound scriptlerini sahnede bul
        toggle1Sound = FindObjectOfType<Toggle1Sound>();
        toggle2Sound = FindObjectOfType<Toggle2Sound>();

        if (toggle1Sound == null || toggle2Sound == null)
        {
            Debug.LogError("Toggle1Sound veya Toggle2Sound scriptleri bulunamad�.");
            return;
        }

        // Toggle bile�enlerini bul ve ayarla
        if (toggle1Sound.m_Toggle1 == null)
        {
            toggle1Sound.m_Toggle1 = FindObjectOfType<Toggle>();
            if (toggle1Sound.m_Toggle1 == null)
            {
                Debug.LogError("Toggle1 bile�eni bulunamad�.");
            }
        }

        if (toggle2Sound.m_Toggle2 == null)
        {
            toggle2Sound.m_Toggle2 = FindObjectOfType<Toggle>();
            if (toggle2Sound.m_Toggle2 == null)
            {
                Debug.LogError("Toggle2 bile�eni bulunamad�.");
            }
        }
    }

    public void HandleToggleStatusChanged(Toggle toggle)
    {
        if (CheckToggleStatus())
        {
            Debug.Log("Toggle 1 is Off and Toggle 2 is On");
        }
        else
        {
            Debug.Log("Toggles are not in the desired state");
        }
    }

    public bool CheckToggleStatus()
    {
        if (toggle1Sound == null || toggle2Sound == null)
        {
            Debug.LogError("Toggle1Sound veya Toggle2Sound scriptleri atanmad�.");
            return false;
        }

        if (toggle1Sound.m_Toggle1 == null || toggle2Sound.m_Toggle2 == null)
        {
            Debug.LogError("Toggle bile�enlerinden biri atanmad�.");
            return false;
        }

        return (!toggle1Sound.m_Toggle1.isOn && toggle2Sound.m_Toggle2.isOn);
    }
}
