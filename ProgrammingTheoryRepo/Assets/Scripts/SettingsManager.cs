using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using System.IO;

public class SettingsManager : MonoBehaviour
{
    [SerializeField] Slider[] slidersColorPlayer;
    [SerializeField] Slider[] slidersColorPlatform;
    [SerializeField] Slider[] slidersColorCrackPlatform;
    [SerializeField] Slider[] slidersColorBorder;
    [SerializeField] Slider[] slidersColorBackground;
    [SerializeField] Slider[] slidersColorFloor;
    [SerializeField] Slider volumeSlider;

    private Slider[][] sliders;

    private void Start()
    {
        sliders = new Slider[6][];
        sliders[0] = slidersColorPlayer;
        sliders[1] = slidersColorPlatform;
        sliders[2] = slidersColorCrackPlatform;
        sliders[3] = slidersColorBorder;
        sliders[4] = slidersColorBackground;
        sliders[5] = slidersColorFloor;

        foreach (var array in sliders)
        {
            foreach (var item in array)
            {
                item.minValue = 0f;
                item.maxValue = 1f;
            }
        }

        volumeSlider.minValue = 0f;
        volumeSlider.maxValue = 1f;

        if (File.Exists(Application.persistentDataPath + "Volume"))
        {
            SaveValue save = JsonUtility.FromJson<SaveValue>(File.ReadAllText(Application.persistentDataPath + "Volume"));
            volumeSlider.value = save.volume;
        }
        else
        {
            volumeSlider.value = 0.5f; 
        }
    }

    public void ReturnMenu()
    {
        SceneManager.LoadScene("Menu");
    }

    public void VolumeSave()
    {
        AudioListener.volume = volumeSlider.value;
        SaveValue save = new SaveValue();
        save.volume = volumeSlider.value;
        File.WriteAllText(Application.persistentDataPath + "Volume" ,JsonUtility.ToJson(save));
    }

}

[System.Serializable]
class SaveValue
{
    public float volume;
}

