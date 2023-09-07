using GameJolt.API;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;
using GameJolt.UI;

public class GameJoltAccountUI : MonoBehaviour
{
    [SerializeField] private GameObject user;
    [SerializeField] private GameObject login;
    [SerializeField] private GameObject MenuUi;
    private bool isSignedIn;
    [SerializeField] private Image userLogo;
    [SerializeField] private TextMeshProUGUI userName;
    // Start is called before the first frame update
    void Start()
    {
        user.SetActive(false);
        login.SetActive(true);
    }

    // Update is called once per frame
    void Update()
    {
        isSignedIn = GameJoltAPI.Instance.CurrentUser != null;
        if (isSignedIn)
        {
            user.SetActive(true);
            login.SetActive(false);
            GameJoltAPI.Instance.CurrentUser.DownloadAvatar();
            userLogo.overrideSprite = GameJoltAPI.Instance.CurrentUser.Avatar;
            userName.text = GameJoltAPI.Instance.CurrentUser.Name;

        }
        else
        {
            user.SetActive(false);
            login.SetActive(true);
            
        }
    }

    public void LogoutUser()
    {
        if (isSignedIn)
        {
            GameJoltAPI.Instance.CurrentUser.SignOut();
            GameJoltUI.Instance.QueueNotification("Succesfully Logged Out");
        }
    }
    public void LoginUser()
    {
        MenuUi.SetActive(false);
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

    }
}
