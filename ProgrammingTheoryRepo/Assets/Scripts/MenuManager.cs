using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;
using System.IO;

#if UNITY_EDITOR
using UnityEditor;
#endif

public class MenuManager : MonoBehaviour
{
    public static string namePlayer = "";

   [SerializeField] TextMeshProUGUI namePlayerText;

    private void Start()
    {
        if (File.Exists(Application.persistentDataPath + "Volume"))
        {
            SaveValue save = JsonUtility.FromJson<SaveValue>(File.ReadAllText(Application.persistentDataPath + "Volume"));
            AudioListener.volume = save.volume;
        }
        else
        {
            AudioListener.volume = 0.5f;
        }
    }

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

    public void GameExit()
    {
#if UNITY_EDITOR
        EditorApplication.ExitPlaymode();
#else
        Application.Quit();
#endif
    }

    public void GoToSettings()
    {
        SceneManager.LoadScene("SettingsMenu");
    }
}
