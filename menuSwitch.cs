using GameJolt.API;
using GameJolt.UI;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class menuSwitch : MonoBehaviour
{
    public Button SettingsBtn, ReturnSettingsBtn;
    public GameObject SettingsUi, MenuUi;
    private bool isOpen;
    bool isSignedIn2;

    private void Start()
    {
        MenuUi.SetActive(false);
        SettingsUi.SetActive(false);
        isSignedIn2 = GameJoltAPI.Instance.CurrentUser != null;
        if (!isSignedIn2)
        {


            GameJoltUI.Instance.ShowSignIn(
      (bool signInSuccess) =>
      {
          Debug.Log(string.Format("Sign-in {0}", signInSuccess ? "successful" : "failed or user's dismissed the window"));
          MenuUi.SetActive(true);
          GameJoltUI.Instance.QueueNotification("Succesfully Logged In");
      },
      (bool userFetchedSuccess) =>
      {
          Debug.Log(string.Format("User details fetched {0}", userFetchedSuccess ? "successfully" : "failed"));
      });
        } else
        {
            MenuUi.SetActive(true);
        }
        SettingsBtn.onClick.AddListener(OpenSettings);
        ReturnSettingsBtn.onClick.AddListener(CloseSettings);
    }
    private void Update()
    {
        if (isOpen)
        {
            if (Input.GetButton("Cancel"))
            {
                CloseSettings();
            }
        }
    }
    public void OpenSettings() 
    {
        if (!isOpen)
        {
            MenuUi.SetActive(false);
            SettingsUi.SetActive(true);
            isOpen = true;
        }
    }
    public void CloseSettings()
    {
        if (isOpen)
        {
            MenuUi.SetActive(true);
            SettingsUi.SetActive(false);
            isOpen = false;
        }
    }
}
