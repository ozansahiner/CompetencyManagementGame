using System;
using UnityEngine;
using UnityEngine.UI;

public class LevelBarController : MonoBehaviour
{
    private static LevelBarController instance;

    void Awake()
    {
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }

    /*public void SetLevelBarValue(float value)
    {
        if (levelBar != null)
        {
            levelBar.value = value;
        }
    }
    */
    
}
