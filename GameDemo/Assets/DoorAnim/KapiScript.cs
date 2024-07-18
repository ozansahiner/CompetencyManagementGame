using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Kapi : MonoBehaviour
{
    public Animator animator; // Kap�y� a�mak ve kapatmak i�in Animator bile�eni
    private bool isOpen = false; // Kap�n�n a��k olup olmad���n� kontrol etmek i�in, ba�lang��ta kapal� oldu�unu varsayal�m
    private Collider2D doorCollider; // Kap�n�n 2D Collider bile�eni
    private BoxCollider2D triggerCollider; // Kap� ile etkile�imi tetiklemek i�in tetikleyici Collider
    private BelirteciKontrol belirteciKontrol; // BelirteciKontrol bile�eni

    void Start()
    {
        // Animator bile�enini al
        animator = GetComponent<Animator>();
        doorCollider = GetComponent<Collider2D>();

        // BelirteciKontrol bile�enini al
        belirteciKontrol = GameObject.FindObjectOfType<BelirteciKontrol>();

        // Kap� kapal�yken Collider'� etkinle�tir
        doorCollider.enabled = true;
    }

    public void OpenDoor()
    {
        if (belirteciKontrol != null && belirteciKontrol.playerInRange && !isOpen)
        {
            animator.SetBool("isOpen", true); // Animator'da "isOpen" parametresini true yaparak kap�y� a�
            doorCollider.isTrigger = false; // Kap� a��ld���nda Collider'� tetikleyiciye d�n��t�r
            isOpen = true; // isOpen durumunu g�ncelle, kap� a��k
        }
    }

    public void CloseDoor()
    {
        if (belirteciKontrol != null && belirteciKontrol.playerInRange && isOpen)
        {
            animator.SetBool("isOpen", false); // Animator'da "isOpen" parametresini false yaparak kap�y� kapat
            doorCollider.isTrigger = true; // Kap� kapand���nda Collider'� normal hale getir
            isOpen = false; // isOpen durumunu g�ncelle, kap� kapal�
        }
    }

    // Oyuncu tetikleyici ile etkile�ime girdi�inde
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            // E tu�una bas�l�p kap� kapal�ysa
            if (Input.GetKeyDown(KeyCode.E) && !isOpen)
            {
                // Kap�y� a�
                OpenDoor();
            }
            else if (Input.GetKeyDown(KeyCode.E) && isOpen)
            {
                // Kap�y� kapat
                CloseDoor();
            }
        }
    }
}
