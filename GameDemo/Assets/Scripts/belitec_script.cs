using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BelirteciKontrol : MonoBehaviour
{
    public GameObject kap�; // Bu belirte�le ili�kili kap�
    private Kapi kapiScript;
    public bool playerInRange = false;

    void Start()
    {
        // Kap�daki Kapi scriptini al
        if (kap� != null)
        {
            kapiScript = kap�.GetComponent<Kapi>();
        }
    }

    // Oyuncu belirtecin i�ine girdi�inde
    public void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            playerInRange = true;
        }
    }

    // Oyuncu belirtecin d���na ��kt���nda
    public void OnTriggerExit2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            playerInRange = false;
        }
    }
}
