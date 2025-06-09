using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;

public class MenuOpciones : MonoBehaviour
{
    public void PantallaCompleta(bool pantallaCompleta)
    {
        Screen.fullScreen = pantallaCompleta;
    }

    [SerializeField] private AudioMixer audioMixer;
    public void CambiarVolumen(float volumen)
    {
        audioMixer.SetFloat("Volumen", volumen); // Aplica el volumen
        PlayerPrefs.SetFloat("volumen", volumen); // Guarda el volumen
        PlayerPrefs.Save();
    }

    public void CambiarCalidad(int index)
    {
        QualitySettings.SetQualityLevel(index);
    }
}
