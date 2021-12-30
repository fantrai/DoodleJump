using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class GameManager : MonoBehaviour
{
    [SerializeField]  GameObject platformPrefab;
    [SerializeField]  GameObject crackPlatformPrafab;
    [SerializeField] TextMeshProUGUI gameOverText;

    private GameObject[] platforms;
    private float maxPosYPlatform = 3;

    private const int COUNT_PLATFORM = 10;
    private const float RANGE_RANDOM_POS = 10;

    private void Awake()
    {
        platforms = new GameObject[COUNT_PLATFORM];
        for (int i = 0; i < platforms.Length; i++)
        {
            GameObject platf = Instantiate(RandomPlatform());
            platf.SetActive(false);
            platforms[i] = platf;
        }
    }

    private void LateUpdate()
    {
        if (Player.player.transform.position.y < PlatformFalseActive.PosYLastPlatform)
        {
            GameOver();
        }
    }

    private void FixedUpdate()
    {
        foreach (var item in platforms)
        {
            if (item.activeInHierarchy == false)
            {
                item.transform.position = RandomPosPlatform();
                item.SetActive(true);
            }
        }
    }

    Vector3 RandomPosPlatform()
    {
        Vector3 reselt = new Vector3(Random.Range(-RANGE_RANDOM_POS, RANGE_RANDOM_POS), Random.Range(maxPosYPlatform + 1, maxPosYPlatform + 4), transform.position.z);
        if (reselt.y > maxPosYPlatform)
        {
            maxPosYPlatform = reselt.y;
        }
        return reselt;
    }

    GameObject RandomPlatform()
    {
        int random = Random.Range(0, 100);
        if (random > 30)
        {
            return platformPrefab;
        }
        return crackPlatformPrafab;
    }

    void GameOver()
    {
        gameOverText.gameObject.SetActive(true);
    }
}
