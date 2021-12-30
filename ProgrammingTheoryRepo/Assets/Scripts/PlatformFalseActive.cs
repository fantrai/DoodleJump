using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlatformFalseActive : MonoBehaviour
{
    static public float PosYLastPlatform = -1;

    private void Awake()
    {
        PosYLastPlatform = -1;
    }

    private void LateUpdate()
    {
        if (transform.position.y < Player.player.transform.position.y - 10)
        {
            PosYLastPlatform = transform.position.y;
            gameObject.SetActive(false);
            gameObject.GetComponent<Collider>().isTrigger = true;
        }
    }



}
