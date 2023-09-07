using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class NewSceneLoader : MonoBehaviour
{
    public screenLoader screen;
    private void OnTriggerEnter(Collider other)
    {
        if (SceneManager.sceneCountInBuildSettings - 1 == SceneManager.GetActiveScene().buildIndex)
        {
            screen.LoadNextScene(0);
            Cursor.visible = true;
            Cursor.lockState = CursorLockMode.None;
        } else
        {
            string level = (SceneManager.GetActiveScene().buildIndex + 1).ToString();
            GameJolt.API.DataStore.Set("levelIndex", level, false, (bool success) => { Debug.LogError(success); });
            screen.LoadNextScene(SceneManager.GetActiveScene().buildIndex + 1);
        }
        


    }

}
