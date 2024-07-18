using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Kapi : MonoBehaviour
{
    public Animator animator; // Kapýyý açmak ve kapatmak için Animator bileþeni
    private bool isOpen = false; // Kapýnýn açýk olup olmadýðýný kontrol etmek için, baþlangýçta kapalý olduðunu varsayalým
    private Collider2D doorCollider; // Kapýnýn 2D Collider bileþeni
    private BoxCollider2D triggerCollider; // Kapý ile etkileþimi tetiklemek için tetikleyici Collider
    private BelirteciKontrol belirteciKontrol; // BelirteciKontrol bileþeni

    void Start()
    {
        // Animator bileþenini al
        animator = GetComponent<Animator>();
        doorCollider = GetComponent<Collider2D>();

        // BelirteciKontrol bileþenini al
        belirteciKontrol = GameObject.FindObjectOfType<BelirteciKontrol>();

        // Kapý kapalýyken Collider'ý etkinleþtir
        doorCollider.enabled = true;
    }

    public void OpenDoor()
    {
        if (belirteciKontrol != null && belirteciKontrol.playerInRange && !isOpen)
        {
            animator.SetBool("isOpen", true); // Animator'da "isOpen" parametresini true yaparak kapýyý aç
            doorCollider.isTrigger = false; // Kapý açýldýðýnda Collider'ý tetikleyiciye dönüþtür
            isOpen = true; // isOpen durumunu güncelle, kapý açýk
        }
    }

    public void CloseDoor()
    {
        if (belirteciKontrol != null && belirteciKontrol.playerInRange && isOpen)
        {
            animator.SetBool("isOpen", false); // Animator'da "isOpen" parametresini false yaparak kapýyý kapat
            doorCollider.isTrigger = true; // Kapý kapandýðýnda Collider'ý normal hale getir
            isOpen = false; // isOpen durumunu güncelle, kapý kapalý
        }
    }

    // Oyuncu tetikleyici ile etkileþime girdiðinde
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            // E tuþuna basýlýp kapý kapalýysa
            if (Input.GetKeyDown(KeyCode.E) && !isOpen)
            {
                // Kapýyý aç
                OpenDoor();
            }
            else if (Input.GetKeyDown(KeyCode.E) && isOpen)
            {
                // Kapýyý kapat
                CloseDoor();
            }
        }
    }
}
