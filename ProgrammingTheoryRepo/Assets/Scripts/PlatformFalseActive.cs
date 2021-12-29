using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlatformFalseActive : MonoBehaviour
{
    private void LateUpdate()
    {
        if (transform.position.y < Player.player.transform.position.y - 10)
        {
            gameObject.SetActive(false);
        }
    }



}
