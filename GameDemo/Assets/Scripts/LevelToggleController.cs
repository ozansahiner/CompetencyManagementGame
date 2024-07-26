using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class LevelToggleController : MonoBehaviour
{
    public Image levelBar; // Refer to your level bar Image component
    private ToggleManager toggleManager; // Reference to the ToggleManager script
    public float changeAmount = 0.05f; // Amount by which the level bar changes (5%)
    private bool previousToggleStatus; // Previous status of the toggle
    public TextMeshProUGUI percentageText; // Refer to the TextMeshProUGUI component
    public Button confirmButton; // Refer to the confirmation button

    void Start()
    {
        // Find the ToggleManager in the scene
        toggleManager = FindObjectOfType<ToggleManager>();

        if (toggleManager == null)
        {
            Debug.LogError("ToggleManager is not found in the scene.");
        }
        else
        {
            previousToggleStatus = toggleManager.CheckToggleStatus();
            UpdatePercentageText(); // Initialize text value
        }

        if (confirmButton != null)
        {
            confirmButton.onClick.AddListener(OnConfirmButtonClicked);
        }
        else
        {
            Debug.LogError("Confirm Button is not assigned.");
        }
    }

    void OnConfirmButtonClicked()
    {
        if (toggleManager == null)
        {
            return;
        }

        bool currentToggleStatus = toggleManager.CheckToggleStatus();

        // Toggle state deðiþikliði kontrolü ve level bar güncellemesi
        if (currentToggleStatus != previousToggleStatus)
        {
            if (currentToggleStatus)
            {
                IncreaseBar();
            }
            else
            {
                DecreaseBar();
            }
        }
        else
        {
            // Toggle durumu deðiþmediyse, eðer önceki durum aktif deðilse azalt
            if (!currentToggleStatus)
            {
                DecreaseBar();
            }
        }

        previousToggleStatus = currentToggleStatus; // Update the status
    }

    void IncreaseBar()
    {
        levelBar.fillAmount += changeAmount;
        if (levelBar.fillAmount > 1f) // Max value example
        {
            levelBar.fillAmount = 1f;
        }
        UpdatePercentageText();
    }

    void DecreaseBar()
    {
        levelBar.fillAmount -= changeAmount;
        if (levelBar.fillAmount < 0f)
        {
            levelBar.fillAmount = 0f;
        }
        UpdatePercentageText();
    }

    void UpdatePercentageText()
    {
        percentageText.text = ((int)(levelBar.fillAmount * 100f)).ToString() + "%";
    }
}
