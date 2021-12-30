using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.IO;

public class SettingsColorSwitch : MonoBehaviour
{
    [SerializeField] Material colorMaterial;
    [SerializeField] Slider sliderR;
    [SerializeField] Slider sliderG;
    [SerializeField] Slider sliderB;

    private void Start()
    {
        if (File.Exists(Application.persistentDataPath + gameObject.name))
        {
            ColorSave save = JsonUtility.FromJson<ColorSave>(File.ReadAllText(Application.persistentDataPath + gameObject.name));
            sliderR.value = save.R;
            sliderG.value = save.G;
            sliderB.value = save.B;
        }
    }

    public void ReloadColor()
    {
        ColorSave save = new ColorSave();
        ValueRSet(save);
        ValueGSet(save);
        ValueBSet(save);

        File.WriteAllText(Application.persistentDataPath + gameObject.name ,JsonUtility.ToJson(save));
    }
    private void ValueRSet(ColorSave save)
    {
        colorMaterial.color = new Color(sliderR.value, colorMaterial.color.g, colorMaterial.color.b);
        save.R = sliderR.value;
    }
    private void ValueGSet(ColorSave save)
    {
        colorMaterial.color = new Color(colorMaterial.color.r, sliderG.value, colorMaterial.color.b);
        save.G = sliderG.value;
    }
    private void ValueBSet(ColorSave save)
    {
        colorMaterial.color = new Color(colorMaterial.color.r, colorMaterial.color.g, sliderB.value);
        save.B = sliderB.value;
    }

    [System.Serializable]
    class ColorSave
    {
        public float R;
        public float G;
        public float B;
    }
}
