using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class noteScript : MonoBehaviour
{
    public GameObject UINote;
    public GameObject noteON;
    public GameObject noteOFF;
    public GameObject note;
    public bool isOn;
    public AudioSource audioSource;

    private void OnTriggerStay(Collider other)
    {
        UINote.SetActive(true);
        if (isOn)
        {
            noteOFF.SetActive(true);
            noteON.SetActive(false);
        } else if (!isOn)
        {
            noteON.SetActive(true);
            noteOFF.SetActive(false);
        }
        if (Input.GetButton("interact"))
        {
            if (!isOn)
            {
                isOn = true;
                note.SetActive(true);
                audioSource.Play();
            }
            else if (isOn)
            {
                isOn = false;
                note.SetActive(false);
                audioSource.Play();
            }

        }
    }
    private void OnTriggerExit(Collider other)
    {
        UINote.SetActive(false);
        if (isOn)
        {
            note.SetActive(false);
            isOn = false;
            audioSource.Play();
        }
    }
    IEnumerator waitFunction()
    {
        yield return new WaitForSeconds(0.2f);
    }

}
