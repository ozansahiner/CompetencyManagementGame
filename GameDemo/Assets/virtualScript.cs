using Cinemachine;
using UnityEngine;

public class VirtualScript : MonoBehaviour
{
    private CinemachineVirtualCamera vcam;
    private static VirtualScript _instance;
    public static VirtualScript Instance
    {
        get
        {
            if (_instance == null)
            {
                _instance = FindObjectOfType<VirtualScript>();
                if (_instance == null)
                {
                    GameObject go = new GameObject("VirtualScript");
                    _instance = go.AddComponent<VirtualScript>();
                }
            }
            return _instance;
        }
    }

    void Awake()
    {
        if (_instance == null)
        {
            _instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else if (_instance != this)
        {
            Destroy(gameObject);
        }

        vcam = GetComponent<CinemachineVirtualCamera>();
    }

    public void SetPlayer(GameObject player)
    {
        if (vcam != null && player != null)
        {
            vcam.Follow = player.transform;
            Debug.Log("Virtual Camera target reassigned to player.");
        }
        else
        {
            Debug.LogError("Virtual Camera or Player is null.");
        }
    }

    // Call this method when scene changes to reassign the player to the camera
    public void ReassignVirtualCameraTarget()
    {
        var player = GameObject.FindGameObjectWithTag("Player");
        SetPlayer(player);
    }
}
