using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ForceWalker : MonoBehaviour
{
    public VectorPoderoso thisPosition, velocidad;
    [SerializeField] Color colorpos, colorvelo, coloracele;
    [SerializeField] float xmax = 5f, xmin = -5, ymax = 5, ymin = -5, rapidezlimite = 5f;
    VectorPoderoso velocidadaplicada, fuerzaactual, gravedadactual, fuerzaAcumuladaActual;
    [SerializeField] float velocidadPerdida = 0f;

    [SerializeField] bool boxlimits = true;

    //fuerzas
    [SerializeField] VectorPoderoso fuerzaX = new VectorPoderoso(0, 0);
    [SerializeField] VectorPoderoso fuerzaY = new VectorPoderoso(0, 0);
    [SerializeField] [Range(0, 1)] float coeficienteFriccion = 1f;
    [SerializeField] float N = 20f;
    [SerializeField] float masa = 1f;
    VectorPoderoso gravedad = new VectorPoderoso(0, -9.8f);
    [SerializeField] VectorPoderoso fuerzaAcumulada = new VectorPoderoso(0, 0);
    [SerializeField] VectorPoderoso peso;

    private void Start()
    {
        thisPosition.X = this.transform.position.x;
        thisPosition.Y = this.transform.position.y;
    }

    void Update()
    {
        UpdatePosition();
        thisPosition.DibujarVector(colorpos);
        velocidad.DibujarVectorDiferente(thisPosition.X, thisPosition.Y, colorvelo);        
        transform.position = new Vector3(thisPosition.X, thisPosition.Y);
    }

    public void UpdatePosition()
    {
        //Por tener mutable el cosiaco nos toco hacer esto :c
        velocidadaplicada = new VectorPoderoso(velocidad.X, velocidad.Y);

        //fuerzas
        fuerzaAcumulada.X = 0;
        fuerzaAcumulada.Y = 0;

        //Calcular Friccion
        AplicarFriccion();

        ApplyForce(fuerzaX);
        ApplyForce(fuerzaY);
        ApplyGravity();

        fuerzaAcumuladaActual = new VectorPoderoso(fuerzaAcumulada.X, fuerzaAcumulada.Y);

        //sumar la aceleracion a la velocidad
        fuerzaAcumuladaActual.Multiplicar(1 / masa);

        //Aplciar aceleracion a la velocidad
        velocidad.Suma(fuerzaAcumuladaActual.Multiplicar(Time.deltaTime));


        //rapidez limite para que no sobrepase el ecceso
        if (velocidad.CalcularMagnitud() > rapidezlimite)
        {
            velocidad = velocidad.Normalizar();
            velocidad.Multiplicar(rapidezlimite);
        }

        //se le suma la veclocidad a la posicion
        thisPosition.Suma(velocidadaplicada.Multiplicar(Time.deltaTime));

        //limites de la caja
        if (boxlimits)
        {
            BoxLimitsCollision();
        }
    }

    private void AplicarFriccion()
    {
        VectorPoderoso friccion = velocidad.Normalizar();
        friccion.Multiplicar(-coeficienteFriccion * N);       
        SumarFuerzas(friccion);
    }

    private void ApplyForce(VectorPoderoso fuerzaAplicar)
    {
        VectorPoderoso fuerzaAplicadakun = new VectorPoderoso(fuerzaAplicar.X, fuerzaAplicar.Y);
        VectorPoderoso solucion = fuerzaAplicadakun.Multiplicar(1 / masa);
        SumarFuerzas(solucion);
    }

    private void ApplyGravity()
    {
        VectorPoderoso gravedadActual = new VectorPoderoso(gravedad.X, gravedad.Y);
        peso = gravedadActual.Multiplicar(masa);
        SumarFuerzas(peso);
    }

    private void SumarFuerzas(VectorPoderoso fuerzaExtra)
    {
        fuerzaAcumulada.Suma(fuerzaExtra);
        fuerzaExtra.DibujarVectorDiferente(thisPosition.X, thisPosition.Y, coloracele);
    }

    private void PerderVelocidad()
    {
        //velocidad.Multiplicar(velocidadPerdida);
    }

    private void BoxLimitsCollision()
    {
        if (thisPosition.X > xmax)
        {
            thisPosition.X = xmax;
            velocidad.X = -velocidad.X;
            PerderVelocidad();
        }
        else if (thisPosition.X < xmin)
        {
            thisPosition.X = xmin;
            velocidad.X = -velocidad.X;
            PerderVelocidad();
        }
        if (thisPosition.Y > ymax)
        {
            thisPosition.Y = ymax;
            velocidad.Y = -velocidad.Y;
            PerderVelocidad();
        }
        else if (thisPosition.Y < ymin)
        {
            thisPosition.Y = ymin;
            velocidad.Y = -velocidad.Y;
            PerderVelocidad();
        }
    }
}
