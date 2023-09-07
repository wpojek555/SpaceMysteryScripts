using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;


public class keyCollecting : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject UIkey;
    public AudioSource audioSource;
    public GameObject key;
    public GameObject keyParticles;
    public GameObject allKey;
    public TextMeshProUGUI collectingText;
    public string keyDestination;
    public GameObject listKeyPrefab;
    public GameObject list;
    GameObject textobj;
    TextMeshProUGUI UItext;
    public bool haveKey;
    public GameObject listKey;
    [Header("animacja kamery")]
    [SerializeField]
    private bool isCameraAnim;
    [SerializeField]
    private Animator animator;
    private void OnTriggerStay(Collider other)
    {
        if(other.tag == "Player")
        {
            collectingText.text = "Podnies klucz do " + keyDestination;
            UIkey.SetActive(true);
            if (Input.GetButton("interact"))
            {
                audioSource.Play();
                UIkey.SetActive(false);

                listKey = Instantiate(listKeyPrefab, new Vector3(0, 0, 0), Quaternion.identity);
                listKey.transform.SetParent(list.transform, false);
                textobj = listKey.transform.GetChild(1).gameObject;
                UItext = textobj.GetComponent<TextMeshProUGUI>();
                UItext.text = "Klucz do " + keyDestination;
                haveKey = true;
                if (isCameraAnim)
                {
                    animator.SetBool("isCollect", true);
                }
                Destroy(allKey);

            }
        }

    }
    private void OnTriggerExit(Collider other)
    {
        UIkey.SetActive(false);
      
    }
    IEnumerator WaitFunction()
    {
        yield return new WaitForSeconds(4f);
    }
}
