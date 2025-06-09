using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CargarEscenaBoss : MonoBehaviour
{
    public GameObject ventana2D;
    public string escenaBossFinal;

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            ventana2D.SetActive(true);
        }
    }

    public void OnClickSi()
    {
        SceneManager.LoadScene(escenaBossFinal);
    }

    public void OnClickNo()
    {
        ventana2D.SetActive(false);
    }
}
