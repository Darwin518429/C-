using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuPausa : MonoBehaviour
{
    // Start is called before the first frame update
 
    [SerializeField] private GameObject botonPausa;
    [SerializeField] private GameObject menuPausa;

    public void Pausa()
    {
        Time.timeScale = 0f; //detener tiempo
        botonPausa.SetActive(false);
        menuPausa.SetActive(true);
    }

    public void Reanudar()
    {
        Time.timeScale = 1f;
        botonPausa.SetActive(true);
        menuPausa.SetActive(false);
    }
    //PANTALLA GANAR
    public void Reinciar()
    {
        Time.timeScale = 1f;
        SceneManager.LoadScene("BOSSS");
    }
    public void Salir ()
    {
        Time.timeScale = 1f;
        SceneManager.LoadScene("MenuInicial");
    }

    public void Ganar()
    {
        Time.timeScale = 1f;
        SceneManager.LoadScene("Joc");
    }

}
