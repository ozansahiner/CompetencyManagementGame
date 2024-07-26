using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;
using Cinemachine;

public class yukari : MonoBehaviour
{
    public int sceneBuildIndex;          // Hedef sahne index'i
    private GameObject player;           // Oyuncu GameObject'i
    public Animator transitionAnimator;  // Sahne ge�i� animasyonunun Animator bile�eni
    public string closeTrigger = "End";  // Scene kapan�� trigger ismi
    public string openTrigger = "Start"; // Scene a��l�� trigger ismi
    public float transitionTime = 1f;    // Animasyon s�resi

    private void Start()
    {
        // Oyuncu nesnesini sahnede bul
        player = GameObject.FindGameObjectWithTag("Player");

        if (player != null)
        {
            // Oyuncu nesnesinin sahne ge�i�lerinde yok edilmemesini sa�la
            DontDestroyOnLoad(player);
        }
        else
        {
            Debug.LogError("Player object not found. Make sure the player has the 'Player' tag.");
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            Debug.Log("Switching Scene to " + sceneBuildIndex);
            StartCoroutine(SwitchSceneAndRepositionPlayer());
        }
    }

    private IEnumerator SwitchSceneAndRepositionPlayer()
    {
        // Sahne kapan�� animasyonunu ba�lat
        if (transitionAnimator != null)
        {
            Debug.Log("Starting close animation");
            transitionAnimator.SetTrigger(closeTrigger);
        }

        // Animasyonun bitmesini bekle
        yield return new WaitForSeconds(transitionTime);

        // Yeni sahneyi asenkron olarak y�kle
        AsyncOperation asyncLoad = SceneManager.LoadSceneAsync(sceneBuildIndex);

        while (!asyncLoad.isDone)
        {
            yield return null;
        }

        // Oyuncuyu yeni sahnede yeniden konumland�r
        RepositionPlayerInNewScene();

        // Sahne a��l�� animasyonunu ba�lat
        if (transitionAnimator != null)
        {
            Debug.Log("Starting open animation");
            transitionAnimator.SetTrigger(openTrigger);

            // Animasyonun bitmesini bekle
            yield return new WaitForSeconds(transitionTime);
        }

        // Virtual Camera'y� yeniden ayarla
        ReassignVirtualCameraTarget();
    }

    private void RepositionPlayerInNewScene()
    {
        // Yeni sahnedeki oyuncu ba�lang�� konumunu bul
        GameObject playerStart = GameObject.FindGameObjectWithTag("PlayerSpawner");

        if (playerStart != null)
        {
            // Oyuncuyu yeniden konumland�r
            player.transform.position = playerStart.transform.position;
            Debug.Log("Player repositioned to " + player.transform.position);
        }
        else
        {
            Debug.LogWarning("PlayerStart not found in the new scene. Make sure you have a GameObject tagged as 'PlayerStart'.");
        }
    }

    private void ReassignVirtualCameraTarget()
    {
        // Virtual Camera'y� bul ve hedefini ayarla
        var virtualCamera = FindObjectOfType<CinemachineVirtualCamera>();
        var player = GameObject.FindGameObjectWithTag("Player");

        if (virtualCamera != null)
        {
            virtualCamera.Follow = player.transform;
            Debug.Log("Virtual Camera target reassigned to player.");
        }
        else
        {
            Debug.LogError("Virtual Camera not found in the new scene.");
        }
    }
}
        