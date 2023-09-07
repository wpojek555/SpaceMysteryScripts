using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using TMPro;
using GameJolt.API;
using Unity.VisualScripting;

public class Menu : MonoBehaviour
{
    public Button resumeBT, quitBT;
    public AudioSource Click;
    public screenLoader screenLoader;
    public TextMeshProUGUI versionTitle;
    [SerializeField] private GameObject saveMenu;
    private bool isSignedIn;

    // Start is called before the first frame update
    void Start()
    {
        saveMenu.SetActive(false);
        Cursor.visible = true;
        resumeBT.onClick.AddListener(OnResumeButtonClick);
        quitBT.onClick.AddListener(OnQuitButtonClick);
    }
    private void Update()
    {
        isSignedIn = GameJoltAPI.Instance.CurrentUser != null;
    }

    // Update is called once per frame
    public void OnResumeButtonClick()
    {
        Click.Play();
        if (isSignedIn)
        {
            saveMenu.SetActive(true);
            transform.gameObject.SetActive(false);

        }
        else
        {
            Cursor.visible = false;
            screenLoader.LoadNextScene(SceneManager.GetActiveScene().buildIndex + 1);
        }

    }
    public void OnQuitButtonClick()
    {
        Click.Play();
        Application.Quit();
    }
}
