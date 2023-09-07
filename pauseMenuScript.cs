using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
public class pauseMenuScript : MonoBehaviour
{
    public GameObject pauseMenuUI;
    public bool isOpen;
    public Button resumeBT, quitBT;
    public bool isPossible;
    public screenLoader screen;

    // Start is called before the first frame update
    void Start()
    {
        resumeBT.onClick.AddListener(OnResumeButtonClick);
        quitBT.onClick.AddListener(OnQuitButtonClick);
    }

    // Update is called once per frame
    void Update()
    {

            if (Input.GetButton("Cancel"))
            {
                Debug.LogWarning(isPossible);
                if (isOpen)
                {
                    isOpen = false;
                    pauseMenuUI.SetActive(false);
                    Cursor.visible = false;
                    Cursor.lockState = CursorLockMode.Locked;
                }
                if (!isOpen)
                {
                    isOpen = true;
                    pauseMenuUI.SetActive(true);
                    Cursor.visible = true;
                    Cursor.lockState = CursorLockMode.None;
                }
            
        }
    }
    public void OnResumeButtonClick()
    {
        isOpen = false;
        pauseMenuUI.SetActive(false);
        Cursor.visible = false;
    }
    public void OnQuitButtonClick()
    {
        screen.LoadNextScene(0);
;    }
}
