using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class Toggle2Sound : MonoBehaviour
{
    public Toggle m_Toggle2;

    void Start()
    {
        if (m_Toggle2 == null)
        {
            m_Toggle2 = FindObjectOfType<Toggle>();
            if (m_Toggle2 == null)
            {
                Debug.LogError("Toggle2 bile�eni bulunamad�.");
            }
        }

        m_Toggle2.onValueChanged.AddListener(OnToggleValueChanged);
        OnToggleValueChanged(m_Toggle2);

        // Ba�lang�� durumu i�in ToggleValueChanged metodunu �a��rmak
    }

    // Toggle de�eri de�i�ti�inde �a�r�lacak metod
    public void OnToggleValueChanged(bool isOn)
    {
        if (isOn)
        {
            Debug.Log("Toggle acildi");
        }
        else
        {
            Debug.Log("Toggle kapandi!");
        }
    }

    public bool AcikMi(bool isOn)
    {
        if (isOn)
        {
            return true;
        }
        else
        {
            return false;
        }
    }
}
