using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;
using UnityEngine.SceneManagement;

public class MainMenuController : MonoBehaviour
{
    public Button startButton;
    public Button messageButton;
    public Button quitButton;
    public Label messageText;

    // Start is called before the first frame update
    void Start()
    {
        var root = GetComponent<UIDocument>().rootVisualElement;

        startButton = root.Q<Button>("Start-button");
        messageButton = root.Q<Button>("Talent-astra");
        quitButton = root.Q<Button>("Quit-button");

        startButton.clicked += StartButtonPressed;
        messageButton.clicked += MessageButtonPressed;
        quitButton.clicked += QuitButtonPressed;
    }

    void StartButtonPressed()
    {
        SceneManager.LoadScene("SampleScene");
    }

    void MessageButtonPressed()
    {
        Application.OpenURL("https://www.talentastra.com");
    }

    void QuitButtonPressed()
    {
        // Editör ortamýnda ise editörden çýkýþ
#if UNITY_EDITOR
        UnityEditor.EditorApplication.isPlaying = false;
#else
        // Uygulamadan çýkýþ
        Application.Quit();
#endif
    }
}