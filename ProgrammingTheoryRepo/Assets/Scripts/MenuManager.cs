using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;
using System.IO;

public class MenuManager : MonoBehaviour
{
    public static string namePlayer = "";

   [SerializeField] TextMeshProUGUI namePlayerText;

    public void StartButtonDown()
    {
        namePlayer = namePlayerText.text;
        SceneManager.LoadScene("GameScene");
    }

    public void DeluteSave()
    {
        if (File.Exists(Application.persistentDataPath + "Save"))
        {
            File.Delete(Application.persistentDataPath + "Save");
        }
    }
}
