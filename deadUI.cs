using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class deadUI : MonoBehaviour
{
    public Button resumeBT, quitBT;

    // Start is called before the first frame update
    void Start()
    {
        resumeBT.onClick.AddListener(OnResumeButtonClick);
        quitBT.onClick.AddListener(OnQuitButtonClick);
    }
    void OnResumeButtonClick()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
    void OnQuitButtonClick()
    {
        SceneManager.LoadScene(0);
    }
}
