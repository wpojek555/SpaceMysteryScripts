using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LoadGame : MonoBehaviour
{
    private screenLoader screenLoader;
    [SerializeField] private GameObject loadGameButton;
    [SerializeField] private GameObject menuUI;
    private int level;
    private void Start()
    {
        screenLoader = GameObject.Find("ScreenLoading").GetComponent<screenLoader>();
    }
    private void Update()
    {

    }
    public void NewGame()
    {
        screenLoader.LoadNextScene(1);
    }

    public void LoadSave()
    {
        GameJolt.API.DataStore.Get("levelIndex", false, (string value) =>
        {
            if (value != null)
            {
                level = int.Parse(value);
                Debug.LogError(level);
                screenLoader.LoadNextScene(level);
            } else
            {
                level = 1;
                screenLoader.LoadNextScene(level);
            }
        });

        

    }
    public void GoBack()
    {
        menuUI.SetActive(true);
        transform.gameObject.SetActive(false);
    }
}
