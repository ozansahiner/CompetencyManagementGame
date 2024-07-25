using UnityEngine;
using UnityEngine.UI;

public class LevelToggleController : MonoBehaviour
{
    public Image levelBar; // Refer to your level bar Image component
    private ToggleManager toggleManager; // Reference to the ToggleManager script
    public float changeAmount = 0.2f; // Amount by which the level bar changes (20%)

    void Start()
    {
        // ToggleManager'ý sahnede bul
        toggleManager = FindObjectOfType<ToggleManager>();

        if (toggleManager == null)
        {
            Debug.LogError("ToggleManager is not found in the scene.");
        }
    }

    void Update()
    {
        if (toggleManager == null)
        {
            return;
        }

        if (toggleManager.CheckToggleStatus())
        {
            IncreaseBar();
        }
        else
        {
            DecreaseBar();
        }
    }

    void IncreaseBar()
    {
        levelBar.fillAmount += changeAmount;
        if (levelBar.fillAmount > 1f)
        {
            levelBar.fillAmount = 1f; // Ensure it doesn't exceed the max value
        }
    }

    void DecreaseBar()
    {
        levelBar.fillAmount -= changeAmount;
        if (levelBar.fillAmount < 0f)
        {
            levelBar.fillAmount = 0f; // Ensure it doesn't go below the min value
        }
    }
}
