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

        // Toggle state listener'lar�n� ayarla
        if (toggle1Sound.m_Toggle1 != null)
        {
            toggle1Sound.m_Toggle1.onValueChanged.AddListener(delegate { HandleToggleChanged(toggle1Sound.m_Toggle1); });
        }

        if (toggle2Sound.m_Toggle2 != null)
        {
            toggle2Sound.m_Toggle2.onValueChanged.AddListener(delegate { HandleToggleChanged(toggle2Sound.m_Toggle2); });
        }
    }

    private void HandleToggleChanged(Toggle changedToggle)
    {
        if (changedToggle == toggle1Sound.m_Toggle1)
        {
            if (toggle1Sound.m_Toggle1.isOn)
            {
                // Toggle1 aktifse, Toggle2'yi kapat
                if (toggle2Sound.m_Toggle2.isOn)
                {
                    toggle2Sound.m_Toggle2.isOn = false;
                }
            }
        }
        else if (changedToggle == toggle2Sound.m_Toggle2)
        {
            if (toggle2Sound.m_Toggle2.isOn)
            {
                // Toggle2 aktifse, Toggle1'i kapat
                if (toggle1Sound.m_Toggle1.isOn)
                {
                    toggle1Sound.m_Toggle1.isOn = false;
                }
            }
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

        // �ki toggle'�n da ayn� anda aktif olup olmad���n� kontrol et
        return (!toggle1Sound.m_Toggle1.isOn && toggle2Sound.m_Toggle2.isOn);
    }
}
