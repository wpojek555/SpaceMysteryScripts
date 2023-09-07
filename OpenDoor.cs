using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class OpenDoor : MonoBehaviour
{
    public bool active;
    public bool isOpen;
    public GameObject door;
    public AudioSource audioSource;
    public AudioSource warningSorce;
    public GameObject canvas;
    public GameObject textOn;
    public GameObject textOff;
    public bool keyRequaired;
    public keyCollecting keyCollecting;
    public GameObject keyWarningUI;
    public TextMeshProUGUI keyWarningText;
    public bool isKeyOpened;
    public float a;
    public bool warningOn;
    public Animator animatorDoor;
    private void Start()
    {
        if (isOpen)
        {
            door.transform.Rotate(0f, 90f, 0);
        }
    }
    private void OnTriggerStay(Collider other)
    {
        
        if (active)
        {

            canvas.SetActive(true);
            if (isOpen)
            {
                textOn.SetActive(false);
                textOff.SetActive(true);
            } else if (!isOpen)
            {
                textOn.SetActive(true);
                textOff.SetActive(false);
            }

            if (Input.GetButton("interact"))
            {

                if (!isOpen)
                {
                    if (keyRequaired)
                    {
                        if (keyCollecting.haveKey)
                        {
                            isOpen = true;
                            animatorDoor.SetBool("isOpen", true);
                            audioSource.Play();
                            Destroy(keyCollecting.listKey);
                            keyCollecting.haveKey = false;
                            keyRequaired = false;
                        }
                        else
                        {
                            keyWarningUI.SetActive(true);
                            keyWarningText = keyWarningUI.GetComponent<TextMeshProUGUI>();
                            keyWarningText.text = "Nie masz klucza do " + keyCollecting.keyDestination;
                            a = 13f;
                            warningOn = true;
                            warningSorce.Play();

                        }

                    }
                    else
                    {
                        isOpen = true;
                        animatorDoor.SetBool("isOpen", true);
                        audioSource.Play();
                    }

                }
                else if (isOpen)
                {
                    isOpen = false;
                    animatorDoor.SetBool("isOpen", false);
                    audioSource.Play();
                }


            }
        }
    }
    private void OnTriggerExit(Collider other)
    {
        if (active)
        {
            canvas.SetActive(false);
        }
    }
    private void Update()
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
    IEnumerator waitFunction()
    {
        yield return new WaitForSeconds(5f);
    }

}
