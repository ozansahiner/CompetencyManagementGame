using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Kapi : MonoBehaviour
{
    public Animator animator; // Kap�y� a�mak ve kapatmak i�in Animator bile�enini kullanaca��z
    private bool isOpen = true; // Kap�n�n a��k olup olmad���n� kontrol etmek i�in
    private Collider2D doorCollider; // Kap�n�n 2D Collider bile�eni

    void Start()
    {
        // Animator ve Collider bile�enlerini al
        animator = GetComponent<Animator>();
        doorCollider = GetComponent<Collider2D>();

        // Kap� kapal�yken Collider'� etkinle�tir
        doorCollider.enabled = true;
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.E))
        {
            if (!isOpen)
            {
                OpenDoor();
            }
            else
            {
                CloseDoor();
            }
        }
    }

    void OpenDoor()
    {
        animator.SetBool("isOpen", true); // Animator'da "isOpen" parametresini true yaparak kap�y� a�
        doorCollider.enabled = true; // Kap� a��ld���nda Collider'� devre d��� b�rak
        isOpen = true;
    }

    void CloseDoor()
    {
        animator.SetBool("isOpen", false); // Animator'da "isOpen" parametresini false yaparak kap�y� kapat
        doorCollider.enabled = false; // Kap� kapand���nda Collider'� etkinle�tir
        isOpen = false;
    }
}