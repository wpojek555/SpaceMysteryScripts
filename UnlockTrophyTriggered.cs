using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UnlockTrophyTriggered : MonoBehaviour
{
    public int TrophyID;
    private void OnTriggerEnter(Collider other)
    {
        GameJolt.API.Trophies.TryUnlock(TrophyID);
    }
}
