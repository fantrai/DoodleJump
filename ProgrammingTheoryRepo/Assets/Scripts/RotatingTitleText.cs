using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotatingTitleText : MonoBehaviour
{
    private const float ROTATE_SPEED = 0.05f;

    private float rotate = 0;

    private void Start()
    {
        StartCoroutine(RotationText());
    }

    IEnumerator RotationText()
    {
        while (true)
        {
            while (rotate < 5)
            {
                transform.Rotate(Vector3.forward, ROTATE_SPEED);
                rotate += ROTATE_SPEED;
                yield return new WaitForSeconds(Time.deltaTime);
            }
            while (rotate > -5)
            {
                transform.Rotate(Vector3.back, ROTATE_SPEED);
                rotate -= ROTATE_SPEED;
                yield return new WaitForSeconds(Time.deltaTime);
            }
        }
    }
}
