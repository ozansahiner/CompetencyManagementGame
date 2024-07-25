using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GizliGorev : MonoBehaviour
{
    public GameObject panel;
    public CapsuleCollider2D capsuleCollider;

    void Start()
    {
        // Paneli baþlangýçta kapalý yap
        panel.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {

    }

    // Collider'a baþka bir obje girdiðinde çalýþýr
    void OnTriggerEnter2D(Collider2D other)
    {
        // Oyuncu görev balonuna girdiðinde paneli aç
        if (other.CompareTag("Player"))
        {
            panel.SetActive(true);
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
}
