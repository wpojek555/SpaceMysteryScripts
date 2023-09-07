using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class camToEnemyStart : MonoBehaviour
{
    public Animator anim;
    
    // Start is called before the first frame update
    void Start()
    {
        
    }
    private void OnTriggerEnter(Collider other)
    {
        anim.SetBool("isActive", true);
    }


    // Update is called once per frame
    void Update()
    {
        
    }
}
