using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using System.IO;

public class GameManager : MonoBehaviour
{   
    [SerializeField]  GameObject platformPrefab;
    [SerializeField]  GameObject crackPlatformPrafab;
    [SerializeField] TextMeshProUGUI gameOverText;
    [SerializeField] TextMeshProUGUI scoreText;
    [SerializeField] TextMeshProUGUI recordText;
    [SerializeField] Button restartButton;
    [SerializeField] Button outMenuButton;

    private GameObject[] platforms;
    private float maxPosYPlatform = 2;
    private int score = 0;
    private int recordScore = 0;
    private string recordName = "";

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

        DataRead();

        recordText.text = "Record: " + recordName + " - " + recordScore;
    }

    private void LateUpdate()
    {
        if (Player.player.transform.position.y > score)
        {
            score = Mathf.RoundToInt(Player.player.transform.position.y);
            scoreText.text = MenuManager.namePlayer + ": " + score;
        }

        if (Player.player.transform.position.y < PlatformFalseActive.PosYLastPlatform)
        {
            DataSave();
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
        restartButton.gameObject.SetActive(true);
        outMenuButton.gameObject.SetActive(true);
    }

    void DataRead()
    {
        if (File.Exists(Application.persistentDataPath + "Save"))
        {
            SaveLider outSave = JsonUtility.FromJson<SaveLider>(File.ReadAllText(Application.persistentDataPath + "Save"));
            recordName = outSave.name;
            recordScore = outSave.score;
        }
    }

    void DataSave()
    {
        if (score > recordScore)
        {
            SaveLider save = new SaveLider();
            save.score = score;
            save.name = MenuManager.namePlayer;
            File.WriteAllText(Application.persistentDataPath + "Save" ,JsonUtility.ToJson(save));
        }
    }

   public void Restart()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    public void OutMenu()
    {
        SceneManager.LoadScene("Menu");
    }

    [System.Serializable]
    class SaveLider
    {
        public string name;
        public int score;
    }
}
