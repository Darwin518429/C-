using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bala : MonoBehaviour
{
    // Start is called before the first frame update
    public float velocidad;

    public int daño;

    private void Update()
    {
        transform.Translate(Time.deltaTime * velocidad * Vector2.right);
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.TryGetComponent(out JugadoPelea vidaJugador))
        {
            vidaJugador.AgarrarGolpe(daño);
        }
    }
}
