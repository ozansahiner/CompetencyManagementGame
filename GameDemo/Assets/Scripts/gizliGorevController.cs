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
        // Paneli ba�lang��ta kapal� yap
        panel.SetActive(false);
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        // Oyuncu g�rev balonuna girdi�inde paneli a�
        if (other.CompareTag("Player"))
        {
            panel.SetActive(true);
            OpenPanel();
        }
    }
    // Collider'dan ba�ka bir obje ��kt���nda �al���r
    void OnTriggerExit2D(Collider2D other)
    {
        // Oyuncu g�rev balonundan ��kt���nda paneli kapat
        if (other.CompareTag("Player"))
        {
            panel.SetActive(false);
        }
 
    }
    void OpenPanel()
    {
        if (panel != null)
        {
            panel.SetActive(true); // Paneli a�
        }
    }
}
