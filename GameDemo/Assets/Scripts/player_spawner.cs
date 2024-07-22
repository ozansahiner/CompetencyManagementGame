using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerSpawner : MonoBehaviour
{
    public GameObject playerPrefab;

    void Start()
    {
        // Karakterin konumunu geri y�kle
        float x = PlayerPrefs.GetFloat("PlayerX", 0);
        float y = PlayerPrefs.GetFloat("PlayerY", 0);
        float z = PlayerPrefs.GetFloat("PlayerZ", 0);
        Vector3 spawnPosition = new Vector3(x, y, z);


        // Karakteri belirtilen konumda spawnla
        // Yaln�zca prefab instantiate edilmiyorsa oyuncuyu olu�tur

    }
}
