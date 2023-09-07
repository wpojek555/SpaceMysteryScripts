using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class blast : MonoBehaviour
{
    public Color blastUIC;
    public Image blastUI;
    public bool isBlast;

    private void OnTriggerEnter(Collider other)
        {
            if (!isBlast)
            {
                blastUIC.a = 1f;
                blastUI.color = blastUIC;
                isBlast = true;
            }


        }
    private void Update()
    {
        if (isBlast)
        {
            if (blastUIC.a > 0f)
            {
                blastUIC.a -= 0.1f;
                blastUI.color = blastUIC;
            }
            if (blastUIC.a <= 0f)
            {
                isBlast = false;
                Destroy(this.gameObject);
            }

        }
    }
    IEnumerator waitFunction()
    {
        yield return new WaitForSeconds(0.2f);
    }
}
