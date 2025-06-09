using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InfinitFons : MonoBehaviour
{
    // Start is called before the first frame update
    private Transform cameraTransform;
    private Vector3 posicioAnteriorCamera;

    private float ampleSprite, posicioInicial;

    [SerializeField]
    private float parallaxNivell;
    // Start is called before the first frame update
    void Start()
    {
        cameraTransform = Camera.main.transform;
        posicioAnteriorCamera = cameraTransform.position;
        posicioInicial = transform.position.x;

        //si tenim sprite
        ampleSprite = GetComponent<SpriteRenderer>().bounds.size.x;
    }

    // Update is called once per frame
    void LateUpdate()
    {
        float deltaX = (cameraTransform.position.x - posicioAnteriorCamera.x) * parallaxNivell;
        float quantitatMoviment = cameraTransform.position.x * (1 - parallaxNivell);
        transform.Translate(new Vector3(deltaX, 0, 0));

        posicioAnteriorCamera = cameraTransform.position;

        if (quantitatMoviment > posicioInicial + ampleSprite)
        {
            transform.Translate(new Vector3(ampleSprite, 0, 0));
            posicioInicial += ampleSprite;
        }
        else if (quantitatMoviment < posicioInicial - ampleSprite)
        {
            transform.Translate(new Vector3(-ampleSprite, 0, 0));
            posicioInicial -= ampleSprite;
        }
    }
}
