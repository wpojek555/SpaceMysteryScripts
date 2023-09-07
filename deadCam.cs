using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class deadCam : MonoBehaviour
{
    public bool isEnd;
    public GameObject deadScreen;
    public GameObject pauseScreen;

    // Update is called once per frame
    void Update()
    {
        if (isEnd)
        {
            deadScreen.SetActive(true);
            Cursor.visible = true;
            Cursor.lockState = CursorLockMode.None;
            DestroyObject(pauseScreen);

        }
    }
}
