using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BarradeVida : MonoBehaviour
{

   
    public Slider barraDeVida; //La barra de vida 

 /*
  public float vidaActual;

     public float vidaMaxima;*/


    public void Comenzar()
    {
        barraDeVida = GetComponent<Slider>(); //Agarra el compopnentes del objetoque tenga un slider 
    }
    
     public void VidaMax(float vidaMax)
    {
        barraDeVida.maxValue = vidaMax;
    }


    public void VidActual(float vida)
    {
        barraDeVida.value = vida;
    }

    public void EmpezarBarra(float vida)
    {
        VidaMax(vida);
        VidActual(vida);
    }

   
        

    
}
