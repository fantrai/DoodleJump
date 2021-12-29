using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveCamera : MonoBehaviour
{
    private const float OFFSET_Y = 4;

    private void LateUpdate()
    {
            transform.position = new Vector3(transform.position.x, Player.player.transform.position.y + OFFSET_Y, transform.position.z);
    }
}
