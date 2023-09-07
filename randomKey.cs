using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class randomKey : MonoBehaviour
{
    public int randomNumber;
    public Transform transform1, transform2, transform3, transform4, transform5;
    public GameObject key;
    // Start is called before the first frame update
    void Start()
    {
        randomNumber = Random.Range(1, 5);
        Debug.Log(randomNumber);
        if(randomNumber == 1) { key.transform.SetPositionAndRotation(transform1.position, transform1.rotation); }
        if(randomNumber == 2) { key.transform.SetPositionAndRotation(transform2.position, transform2.rotation); }
        if(randomNumber == 3) { key.transform.SetPositionAndRotation(transform3.position, transform3.rotation); }
        if(randomNumber == 4) { key.transform.SetPositionAndRotation(transform4.position, transform4.rotation); }
        if(randomNumber == 5) { key.transform.SetPositionAndRotation(transform5.position, transform5.rotation); }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
