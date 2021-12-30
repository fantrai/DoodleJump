using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CrackPlatform : PlatformFalseActive
{
    private void OnCollisionEnter(Collision collision)
    {
        gameObject.SetActive(false);
    }
}
