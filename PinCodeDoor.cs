using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using System.Globalization;

public class PinCodeDoor : MonoBehaviour
{
    public GameObject doorSlide;
    [SerializeField]
    private bool isOpen;
    public GameObject PinUI;
    public Animator animatorDoor;
    public bool haveCard;
    public Button confirmBT, quitBT;
    public TextMeshProUGUI resultText;
    public int Pin;
    public bool isUnlocked;
    public GameObject InvalidNumberText;
    public GameObject ErrorNumberText;
    public MouseMovement MouseM;
    public PlayerMovement PlayerMovement;
    public GameObject cube;
    public Transform pos1, pos2, pos3, pos4;
    int randomNumber1, randomNumber2, randomNumber3, randomNumber4;
    int index = 1;
    // Start is called before the first frame update
    void Start()
    {
        //confirmBT.onClick.AddListener(OnConfirmButtonClick);
        quitBT.onClick.AddListener(OnQuitButtonClick);
        randomNumber1 = Random.Range(1, 9);
        randomNumber2 = Random.Range(1, 9);
        randomNumber3 = Random.Range(1, 9);
        randomNumber4 = Random.Range(1, 9);
        while ((index <= randomNumber1)) { Instantiate(cube, pos1.position, Quaternion.identity).GetComponent<Rigidbody>().AddTorque(1, 1, 1); index += 1; }
        index = 1;
        while ((index <= randomNumber2)) { Instantiate(cube, pos2.position, Quaternion.identity).GetComponent<Rigidbody>().AddTorque(1, 1, 1); index += 1; }
        index = 1;
        while ((index <= randomNumber3)) { Instantiate(cube, pos3.position, Quaternion.identity).GetComponent<Rigidbody>().AddTorque(1, 1, 1); index += 1; }
        index = 1;
        while ((index <= randomNumber4)) { Instantiate(cube, pos4.position, Quaternion.identity).GetComponent<Rigidbody>().AddTorque(1, 1, 1); index += 1; }
        Pin = (randomNumber1 * 1000) + (randomNumber2 * 100) + (randomNumber3 * 10) + randomNumber4;
    }
    private void OnTriggerEnter(Collider other)
    {
        

        if (!isOpen && !isUnlocked)
        {
            isOpen = true;
            PinUI.SetActive(true);
            Cursor.visible = true;
            Cursor.lockState = CursorLockMode.None;
            MouseM.enable = false;
            PlayerMovement.isAnim1 = true;
        }
        if (isUnlocked)
        {
            animatorDoor.SetBool("isOpen", true);

        }




    }
    private void OnQuitButtonClick()
    {
        if (isOpen)
        {
            isOpen = false;
            PinUI.SetActive(false);
            Cursor.visible = false;
            Cursor.lockState = CursorLockMode.Locked;
            MouseM.enable = true;
            PlayerMovement.isAnim1 = false;
        }

    }
    public void OnConfirmButtonClick(string tekst)
    {
        if (int.TryParse(tekst, out int enteredPin))
        {
            if (enteredPin == Pin)
            {
                isUnlocked = true;
                animatorDoor.SetBool("isOpen", true);
                isOpen = false;
                PinUI.SetActive(false);
                Cursor.visible = false;
                Cursor.lockState = CursorLockMode.Locked;
                MouseM.enable = true;
                PlayerMovement.isAnim1 = false;
            }
            else
            {
                InvalidNumberText.SetActive(true);
                ErrorNumberText.SetActive(false);
                tekst = "";
                Debug.LogWarning("Z³y Pin: " + enteredPin + ".");
            }
        }
        else
        {
            ErrorNumberText.SetActive(true);
            InvalidNumberText.SetActive(false);
            tekst = "";
            Debug.LogWarning("Nieprawid³owy format PINu." + tekst);
        }
    }
    private void OnTriggerExit(Collider other)
    {
        animatorDoor.SetBool("isOpen", false);

    }
    // Update is called once per frame
    void Update()
    {
        
     }   
}
