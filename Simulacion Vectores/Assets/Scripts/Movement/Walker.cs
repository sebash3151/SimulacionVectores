using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Walker : MonoBehaviour
{
    public VectorPoderoso thisPosition, velocidad, aceleracion;
    [SerializeField] Color color, color2, color3;
    [SerializeField] float xmax = 5f, xmin = -5, ymax = 5, ymin = -5, rapidezlimite = 5f;
    VectorPoderoso velocidadaplicada, aceleracionaplicada;

    private void Start()
    {

    }
    void Update()
    {
        UpdatePosition();
        //transform.position = new Vector2(thisPosition.X, thisPosition.Y);
        //thisPosition = new VectorPoderoso(transform.position.x, transform.position.y);
        thisPosition.DibujarVector(color);
        velocidad.DibujarVectorDiferente(thisPosition.X, thisPosition.Y, color2);
        aceleracion.DibujarVectorDiferente(thisPosition.X, thisPosition.Y, color3);
        transform.position = new Vector3(thisPosition.X, thisPosition.Y);
    }

    public void UpdatePosition()
    {
        velocidadaplicada = new VectorPoderoso(velocidad.X, velocidad.Y);
        aceleracionaplicada = new VectorPoderoso(aceleracion.X, aceleracion.Y);

        velocidad.Suma(aceleracionaplicada.Multiplicar(Time.deltaTime));
        if (velocidad.CalcularMagnitud() > rapidezlimite)
        {
            velocidad = velocidad.Normalizar();
            velocidad.Multiplicar(rapidezlimite);
        }

        thisPosition.Suma(velocidadaplicada.Multiplicar(Time.deltaTime)); 

        if (thisPosition.X > xmax)
        {
            thisPosition.X = xmax;
            velocidad.X = -velocidad.X;
            // aceleracion.X = -aceleracion.X;
        }
        else if (thisPosition.X < xmin)
        {
            thisPosition.X = xmin;
            velocidad.X = -velocidad.X;
            // aceleracion.X = -aceleracion.X;
        }
        if (thisPosition.Y > ymax)
        {
            thisPosition.Y = ymax;
            velocidad.Y = -velocidad.Y;
            //aceleracion.Y = -aceleracion.Y;
        }
        else if (thisPosition.Y < ymin)
        {
            thisPosition.Y = ymin;
            velocidad.Y = -velocidad.Y;
            //aceleracion.Y = -aceleracion.Y;
        }
    }
}
