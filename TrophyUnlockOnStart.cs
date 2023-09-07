using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TrophyUnlockOnStart : MonoBehaviour
{
    [SerializeField]
    private int TrophyID;
    // Start is called before the first frame update
    void Start()
    {
        GameJolt.API.Trophies.TryUnlock(TrophyID);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
