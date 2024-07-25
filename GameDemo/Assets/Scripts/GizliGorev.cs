using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GizliGorev : MonoBehaviour
{
    public GameObject panel;
    public CapsuleCollider2D capsuleCollider;

    void Start()
    {
        // Paneli ba�lang��ta kapal� yap
        panel.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {

    }

    // Collider'a ba�ka bir obje girdi�inde �al���r
    void OnTriggerEnter2D(Collider2D other)
    {
        // Oyuncu g�rev balonuna girdi�inde paneli a�
        if (other.CompareTag("Player"))
        {
            panel.SetActive(true);
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
}
