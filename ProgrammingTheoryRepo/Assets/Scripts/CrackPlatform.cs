using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CrackPlatform : PlatformFalseActive
{
    [SerializeField] AudioClip crack;

    private void OnCollisionEnter(Collision collision)
    {
        GameManager.gameManager.PlayerAudio(crack);
        gameObject.SetActive(false);
    }
}
