using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;

public class Player : MonoBehaviour
{ 
    public static GameObject player { get; private set;  }

    [SerializeField] Material colorPlayer;

    private const float FORSEJUMP = 225;
    private const float MOVELEFT = 5;
    private const float MAXPOS = 9.5f;

    private Rigidbody playerPB;
    private AudioSource audioS;

    private void Awake()
    {
        player = gameObject;
        playerPB = GetComponent<Rigidbody>();
        audioS = GetComponent<AudioSource>();

        if (File.Exists(Application.persistentDataPath + "ColorSettingsPlayer"))
        {
            ColorSave save = JsonUtility.FromJson<ColorSave>(File.ReadAllText(Application.persistentDataPath + "ColorSettingsPlayer"));
            colorPlayer.color = new Color(save.R, save.G, save.B);
        }

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
        audioS.Play();
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
[System.Serializable]
class ColorSave
{
    public float R;
    public float G;
    public float B;
}

