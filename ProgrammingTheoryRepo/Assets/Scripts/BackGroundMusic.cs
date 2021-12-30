using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BackGroundMusic : MonoBehaviour
{
    static int thisObjectCount = 0;

    private void Awake()
    {
        if (thisObjectCount == 0)
        {
            DontDestroyOnLoad(gameObject);
            thisObjectCount++;
        }
        else
        {
            Destroy(gameObject);
        }
    }
}
