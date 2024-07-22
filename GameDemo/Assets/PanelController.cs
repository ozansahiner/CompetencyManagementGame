using UnityEngine;
using UnityEngine.UI;

public class PanelController : MonoBehaviour
{
    public RectTransform panelA; // �lk panel (k���ltece�iniz panel)
    public RectTransform panelB; // �kinci panel (g�sterece�iniz panel)
    public Button resizeButton; // Buton

    // K���ltme miktar�n� belirler
    public float widthReduction = 100f;

    void Start()
    {
        if (resizeButton != null)
        {
            resizeButton.onClick.AddListener(OnResizeButtonClicked);
        }
    }

    void OnResizeButtonClicked()
    {
        if (panelA != null && panelB != null)
        {
            // PanelA'y� k���lt
            Vector2 currentSize = panelA.sizeDelta;
            Vector2 newSize = new Vector2(currentSize.x / 2, currentSize.y);
            panelA.sizeDelta = newSize;

            // PanelA'n�n sa� kenar�n� korumak i�in pozisyonu g�ncelle
            panelA.anchoredPosition = new Vector2(panelA.anchoredPosition.x - (currentSize.x - newSize.x) / 2, panelA.anchoredPosition.y);

            // PanelA'y� gizle ve PanelB'yi g�ster
            panelA.gameObject.SetActive(false);
            panelB.gameObject.SetActive(true);
        }
        else
        {
            Debug.LogError("PanelA or PanelB is not assigned.");
        }
    }
}
