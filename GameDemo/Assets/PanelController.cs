using UnityEngine;
using UnityEngine.UI;

public class PanelController : MonoBehaviour
{
    public RectTransform panelA; // Ýlk panel (küçülteceðiniz panel)
    public RectTransform panelB; // Ýkinci panel (göstereceðiniz panel)
    public Button resizeButton; // Buton

    // Küçültme miktarýný belirler
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
            // PanelA'yý küçült
            Vector2 currentSize = panelA.sizeDelta;
            Vector2 newSize = new Vector2(currentSize.x / 2, currentSize.y);
            panelA.sizeDelta = newSize;

            // PanelA'nýn sað kenarýný korumak için pozisyonu güncelle
            panelA.anchoredPosition = new Vector2(panelA.anchoredPosition.x - (currentSize.x - newSize.x) / 2, panelA.anchoredPosition.y);

            // PanelA'yý gizle ve PanelB'yi göster
            panelA.gameObject.SetActive(false);
            panelB.gameObject.SetActive(true);
        }
        else
        {
            Debug.LogError("PanelA or PanelB is not assigned.");
        }
    }
}
