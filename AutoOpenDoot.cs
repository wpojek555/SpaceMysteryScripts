using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AutoOpenDoot : MonoBehaviour
{
    public GameObject doorSlide;
    [SerializeField]
    private bool isNotActive;
    // Start is called before the first frame update
    private void OnTriggerStay(Collider other)
    {
        isNotActive = false;


    }
    private void OnTriggerExit(Collider other)
    {
        isNotActive = true;

    }
    // Update is called once per frame
    void Update()
    {

        if (!(doorSlide.transform.position.y <= 0) & isNotActive)
        {
            doorSlide.transform.position += new Vector3(0f, -0.1f, 0f);
        }
        if (!(doorSlide.transform.position.y >= 6) & !isNotActive)
        {
            doorSlide.transform.position += new Vector3(0f, 0.2f, 0f);
        }
    }
}
