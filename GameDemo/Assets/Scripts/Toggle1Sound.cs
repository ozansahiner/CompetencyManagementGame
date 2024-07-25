using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class Toggle1Sound : MonoBehaviour
{
    public Toggle m_Toggle1;

    void Start()
    {
        if (m_Toggle1 == null)
        {
            m_Toggle1 = FindObjectOfType<Toggle>();
            if (m_Toggle1 == null)
            {
                Debug.LogError("Toggle1 bile�eni bulunamad�.");
            }
        }

        m_Toggle1.onValueChanged.AddListener(OnToggle1ValueChanged);
        OnToggle1ValueChanged(m_Toggle1);

        // Ba�lang�� durumu i�in ToggleValueChanged metodunu �a��rmak
    }

    // Toggle de�eri de�i�ti�inde �a�r�lacak metod
    public void OnToggle1ValueChanged(bool isOn)
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
        if(isOn)
        {
            return true;
        }
        else
        {
            return false;
        }
    }
}
