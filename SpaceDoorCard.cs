using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class SpaceDoorCard : MonoBehaviour
{
    public GameObject doorSlide;
    [SerializeField]
    private bool isNotActive;
    public Animator animatorDoor;
    public bool haveCard;
    public GameObject keyWarningUI;
    public TextMeshProUGUI keyWarningText;
    public bool keyRequaired;
    public keyCollecting keyCollecting;
    private bool warningOn;
    float a;
    // Start is called before the first frame update
    private void OnTriggerStay(Collider other)
    {
        if (!keyRequaired)
        {
            animatorDoor.SetBool("isOpen", true);
        }
        else
        {
            if (keyRequaired)
            {
                if (keyCollecting.haveKey)
                {
                    animatorDoor.SetBool("isOpen", true);
                    Destroy(keyCollecting.listKey);
                    keyCollecting.haveKey = false;
                    keyRequaired = false;
                }
                else
                {
                    keyWarningUI.SetActive(true);
                    keyWarningText = keyWarningUI.GetComponent<TextMeshProUGUI>();
                    keyWarningText.text = "Nie masz karty do " + keyCollecting.keyDestination;
                    a = 13f;
                    warningOn = true;

                }
            }
        }
    }
    private void OnTriggerExit(Collider other)
    {
        animatorDoor.SetBool("isOpen", false);

    }
    // Update is called once per frame
    void Update()
    {
            if (warningOn)
            {
                if (a > 0f)
                {
                    a -= 0.1f;
                }
                if (a <= 0f)
                {
                    warningOn = false;
                    keyWarningUI.SetActive(false);
                }
            }
     }   
}
