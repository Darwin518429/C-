using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.SceneManagement;
public class Boss : MonoBehaviour
{

    private Animator animator;
    public Rigidbody2D rb2D;
    public Transform jugador;
    private bool mirandoDerecha = true;
    public Player unGolpe;
    [Header("Pantalla de Victoria")]
    [SerializeField] private GameObject pantallaVictoria; 

    [Header("Ataque Cuerpo a Cuerpo")]
    [SerializeField] private Transform controladorAtaque;
    [SerializeField] private float radioAtaque;
    [SerializeField] private float unAtaque;

    [Header("Ataque a Distancia")]
    [SerializeField] private GameObject proyectilPrefab;
    [SerializeField] private Transform puntoDisparo;
    [SerializeField] private float velocidadProyectil;
    [SerializeField] private float distanciaDisparo;

    [Header("Vida")]
    [SerializeField] private float vida;
    [SerializeField] private BarradeVida barraDeVida;

    [Header("Rango de Disparo Rectangular")]
    [SerializeField] private float altoDisparo = 2f;
    [SerializeField] private LayerMask capaJugador;

    // Nuevas variables para los patrones de ataque
    private enum PatronAtaque { CuerpoACuerpo, Distancia }
    private PatronAtaque patronActual = PatronAtaque.CuerpoACuerpo;
    private float tiempoCambioPatron = 5f; // Cambia cada 5 segundos (ajusta como quieras)
    private float tiempoUltimoCambio;

    private void Start()
    {
        unGolpe = FindObjectOfType<Player>();
        animator = GetComponent<Animator>();
        rb2D = GetComponent<Rigidbody2D>();
        barraDeVida.EmpezarBarra(vida);
        jugador = GameObject.FindGameObjectWithTag("Player").GetComponent<Transform>();
        tiempoUltimoCambio = Time.time;

        if (pantallaVictoria != null)
        {
            pantallaVictoria.SetActive(false);
        }
    }

    private void Update()
    {
        if (jugador != null)
        {
            float distanciaJugador = Vector2.Distance(transform.position, jugador.position);
            animator.SetFloat("distanciaPPlayer", distanciaJugador);

            // Cambiar patrón de ataque cada cierto tiempo
            if (Time.time - tiempoUltimoCambio > tiempoCambioPatron)
            {
                CambiarPatron();
                tiempoUltimoCambio = Time.time;
            }

            // Ejecutar el patrón de ataque actual
            if (patronActual == PatronAtaque.Distancia && distanciaJugador > radioAtaque && distanciaJugador <= distanciaDisparo)
            {
                animator.SetTrigger("Recibir");
            }
            else if (patronActual == PatronAtaque.CuerpoACuerpo && distanciaJugador <= radioAtaque)
            {
                animator.SetTrigger("Cuerpo");
            }
        }
    }

    private void CambiarPatron()
    {
        if (patronActual == PatronAtaque.CuerpoACuerpo)
        {
            patronActual = PatronAtaque.Distancia;
        }
        else
        {
            patronActual = PatronAtaque.CuerpoACuerpo;
        }
    }

    public void Disparar()
    {
        if (jugador != null)
        {
            GameObject proyectil = Instantiate(proyectilPrefab, puntoDisparo.position, Quaternion.identity);
            Rigidbody2D rbProyectil = proyectil.GetComponent<Rigidbody2D>();
            Vector2 direccion = (jugador.position - puntoDisparo.position).normalized;
            rbProyectil.velocity = direccion * velocidadProyectil;
        }
    }

    public void Ataque()
    {
        Collider2D[] objetos = Physics2D.OverlapCircleAll(controladorAtaque.position, radioAtaque);
        foreach (Collider2D colision in objetos)
        {
            if (colision.CompareTag("Player"))
            {
                colision.GetComponent<JugadoPelea>().AgarrarGolpe(unAtaque);
            }
        }
    }

    public void Tomar(float golpe)
    {
        vida -= golpe;
        barraDeVida.VidActual(vida);
        if (vida <= 0)
        {
            animator.SetTrigger("Morir");
             if (pantallaVictoria != null)
            {
                pantallaVictoria.SetActive(true);
            }


        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("GOLPE"))
        {

            Tomar(unGolpe.golpear);
        }
    }
    private void Muerte()
    {
        Destroy(gameObject);
    }

    public void MirarJugador()
    {
        if (jugador != null)
        {
            if ((jugador.position.x > transform.position.x && !mirandoDerecha) ||
                (jugador.position.x < transform.position.x && mirandoDerecha))
            {
                mirandoDerecha = !mirandoDerecha;
                transform.eulerAngles = new Vector3(0, transform.eulerAngles.y + 180, 0);
            }
        }
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(controladorAtaque.position, radioAtaque);



        Gizmos.color = Color.blue;

        // Calcula la posición del centro del rectángulo
        Vector2 centroDisparo = transform.position + Vector3.right * (distanciaDisparo / 2);

       
        Gizmos.DrawWireCube(centroDisparo, new Vector2(distanciaDisparo, altoDisparo));
    }
}

    




