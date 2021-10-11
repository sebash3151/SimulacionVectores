using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GraficaPolar : MonoBehaviour
{
    [SerializeField] float radio, angulo;
    VectorPoderoso vectorPolar;
    [SerializeField] Color color;
    VectorPoderoso thisPosition;

    [Header("Angular")]
    [SerializeField] float angularSpeed;
    [SerializeField] float angularAcceleration;

    [Header("Radial")]
    [SerializeField] float radialSpeed;
    [SerializeField] float radialAcceleration;

    [Header("Limites")]
    [SerializeField] bool limitesCartesianos = false;
    [SerializeField] bool limitesPolares = true;
    [SerializeField] float xmax = 4.7f;
    [SerializeField] float xmin = -4.7f;
    [SerializeField] float ymax = 4.7f;
    [SerializeField] float ymin = -4.7f;

    void Update()
    {
        thisPosition = new VectorPoderoso(transform.position.x, transform.position.y);

        vectorPolar = new VectorPoderoso(radio, angulo);
        Despolarizar();
        Aumento();
        vectorPolar.DibujarVector(color);
        UpdatePosition();
        CheckCollider();
    }

    private void Despolarizar()
    {
        vectorPolar.X = Mathf.Cos(angulo);
        vectorPolar.Y = Mathf.Sin(angulo);
        vectorPolar.Multiplicar(radio);
    }

    private void Aumento()
    {
        angularSpeed += angularAcceleration * Time.deltaTime;
        radialSpeed += radialAcceleration * Time.deltaTime;

        radio += radialSpeed * Time.deltaTime;
        angulo += angularSpeed * Time.deltaTime;
    }

    void UpdatePosition()
    {
        transform.position = new Vector3(vectorPolar.X, vectorPolar.Y);
    }

    void CheckCollider()
    {
        if (limitesCartesianos)
        {
            BoxLimitsCollisionCartesianos();
        }
        if (limitesPolares)
        {
            BoxLimitsCollisionPolares();
        }
    }

    private void BoxLimitsCollisionPolares()
    {
        if (radio > xmax)
        {
            radio = xmax;
            radialSpeed = -radialSpeed;
        }
        else if (radio < xmin)
        {
            radio = xmin;
            radialSpeed = -radialSpeed;
        }
        if (radio > ymax)
        {
            radio = ymax;
            radialSpeed = -radialSpeed;
        }
        else if (radio < ymin)
        {
            radio = ymin;
            radialSpeed = -radialSpeed;
        }
    }

    private void BoxLimitsCollisionCartesianos()
    {
        if (thisPosition.X > xmax)
        {
            thisPosition.X = xmax;
            radialSpeed = -radialSpeed;
        }
        else if (thisPosition.X < xmin)
        {
            thisPosition.X = xmin;
            radialSpeed = -radialSpeed;
        }
        if (thisPosition.Y > ymax)
        {
            thisPosition.Y = ymax;
            radialSpeed = -radialSpeed;
        }
        else if (thisPosition.Y < ymin)
        {
            thisPosition.Y = ymin;
            radialSpeed = -radialSpeed;
        }
    }
}
