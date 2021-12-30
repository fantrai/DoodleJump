using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PulsePlayButton : MonoBehaviour
{
    // Start is called before the first frame update
    private const float PULSE_SPEED = 0.01f;

    private float scale = 3;

    private void Start()
    {
        StartCoroutine(PulseButton());
    }

    IEnumerator PulseButton()
    {
        while (true)
        {
            while (scale < 3)
            {
                transform.localScale += new Vector3(PULSE_SPEED, PULSE_SPEED / 2, 0);
                scale += PULSE_SPEED;
                yield return new WaitForSeconds(Time.deltaTime/2);
            }
            while (scale > 2.8f)
            {
                transform.localScale -= new Vector3(PULSE_SPEED, PULSE_SPEED / 2, 0);
                scale -= PULSE_SPEED;
                yield return new WaitForSeconds(Time.deltaTime/2);
            }
        }
    }
}
