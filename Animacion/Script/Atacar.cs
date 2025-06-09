using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Atacar : MonoBehaviour
{
    // Start is called before the first frame update

    public float golpes;
    
    private void OnTriggerEnter2D(Collider2D collision)
    {
        
        
            if (collision.gameObject.tag == "Player")
            {
            collision.GetComponent<JugadoPelea>().AgarrarGolpe(100);
            }
        
    }


}
