using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class gizliGorevController : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject panel;
    public CapsuleCollider2D capsuleCollider;

    void Start()
    {
        // Paneli baþlangýçta kapalý yap
        panel.SetActive(false);
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        // Oyuncu görev balonuna girdiðinde paneli aç
        if (other.CompareTag("Player"))
        {
            panel.SetActive(true);
            OpenPanel();
        }
    }
    // Collider'dan baþka bir obje çýktýðýnda çalýþýr
    void OnTriggerExit2D(Collider2D other)
    {
        // Oyuncu görev balonundan çýktýðýnda paneli kapat
        if (other.CompareTag("Player"))
        {
            panel.SetActive(false);
        }
 
    }
    void OpenPanel()
    {
        if (panel != null)
        {
            panel.SetActive(true); // Paneli aç
        }
    }
}
