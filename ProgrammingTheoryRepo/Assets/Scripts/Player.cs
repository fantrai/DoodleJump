using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public static GameObject player { get; private set;  }

    private const float FORSEJUMP = 225;
    private const float MOVELEFT = 5;
    private const float MAXPOS = 9.5f;

    private Rigidbody playerPB;

    private void Awake()
    {
        player = gameObject;
        playerPB = GetComponent<Rigidbody>();
    }

    private void Update()
    {
        float input = Input.GetAxis("Horizontal");
        playerPB.AddForce(Vector3.right * input * MOVELEFT, ForceMode.Impulse);

        CheckPosition();
    }

    private void OnCollisionEnter(Collision collision)
    {
        playerPB.velocity = Vector3.zero;
        playerPB.AddForce(Vector3.up * FORSEJUMP, ForceMode.Impulse);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.transform.position.y + 0.1f < transform.position.y)
        {
            other.isTrigger = false;
        }
    }

    void CheckPosition()
    {
        if (transform.position.x > MAXPOS)
        {
            transform.position = new Vector3(-MAXPOS, transform.position.y);
        }
        if (transform.position.x < -MAXPOS)
        {
            transform.position = new Vector3(MAXPOS, transform.position.y);
        }
    }
}
