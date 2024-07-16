using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Kapi : MonoBehaviour
{
    public Animator animator; // Kapıyı açmak ve kapatmak için Animator bileşenini kullanacağız
    private bool isOpen = false; // Kapının açık olup olmadığını kontrol etmek için

    void Start()
    {
        // Animator bileşenini al
        animator = GetComponent<Animator>();
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.E) && !isOpen)
        {
            OpenDoor();
        }
        else if (Input.GetKeyDown(KeyCode.E) && isOpen)
        {
            CloseDoor();
        }
    }

    void OpenDoor()
    {
        animator.SetBool("isOpen", true); // Animator'da "isOpen" parametresini true yaparak kapıyı aç
        isOpen = true;
    }

    void CloseDoor()
    {
        animator.SetBool("isOpen", false); // Animator'da "isOpen" parametresini false yaparak kapıyı kapat
        isOpen = false;
    }
}
