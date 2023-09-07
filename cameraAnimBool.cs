using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class cameraAnimBool : MonoBehaviour
{
    public bool isAnimated;
    public PlayerMovement PlayerMovement;
    public int IdCamera;
    private void Update()
    {
        if (isAnimated)
        {
            if (IdCamera == 1)
            {
                PlayerMovement.isAnim1 = true;
            }
            if (IdCamera == 2)
            {
                PlayerMovement.isAnim2 = true;
            }
            if (IdCamera == 3)
            {
                PlayerMovement.isAnim3 = true;
            }
            if (IdCamera == 4)
            {
                PlayerMovement.isAnim4 = true;
            }
            if (IdCamera == 5)
            {
                PlayerMovement.isAnim5 = true;
            }
            if (IdCamera == 6)
            {
                PlayerMovement.isAnim6 = true;
            }
        }

        else
        {
            if (IdCamera == 1)
            {
                PlayerMovement.isAnim1 = false;
            }
            if (IdCamera == 2)
            {
                PlayerMovement.isAnim2 = false;
            }
            if (IdCamera == 3)
            {
                PlayerMovement.isAnim3 = false;
            }
            if (IdCamera == 4)
            {
                PlayerMovement.isAnim4 = false;
            }
            if (IdCamera == 5)
            {
                PlayerMovement.isAnim5 = false;
            }
            if (IdCamera == 6)
            {
                PlayerMovement.isAnim6 = false;
            }


        }
    }
}
