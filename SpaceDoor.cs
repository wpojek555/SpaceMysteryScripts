using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpaceDoor : MonoBehaviour
{
    public GameObject doorSlide;
    [SerializeField]
    private bool isNotActive;
    public ParticleSystem particles;
    public bool particleOn;
    public AudioSource audio;
    bool played = false;
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
            if (played)
            {
                if (particleOn)
                {
                    particles.Play();
                    audio.Play();
                    played = true;
                    WaitFunction();
                    particles.Pause();
                    doorSlide.transform.position += new Vector3(0f, 0.2f, 0f);
                    
                }
            }

            doorSlide.transform.position += new Vector3(0f, 0.2f, 0f);
        }
    }
    IEnumerator WaitFunction()
    {
        yield return new WaitForSeconds(4f);
    }
}
