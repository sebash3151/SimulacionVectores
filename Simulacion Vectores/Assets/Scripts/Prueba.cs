using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Prueba : MonoBehaviour
{
    [SerializeField] VectorPoderoso Vector1, Vector2;
    [SerializeField] Color color, color2, color3, color4, color5;
    [SerializeField] float origenx, origeny;
    [SerializeField] float multi;
    private void Awake()
    {
       
    }
    private void Start()
    {
        Debug.Log(Vector1);
    }

    private void Update()
    {
        VectorPoderoso vectorcopia = new VectorPoderoso(Vector1.X, Vector1.Y);
        Vector1.DibujarVector(color);
        Vector2.DibujarVector(color2);

        vectorcopia.Resta(Vector2);
        vectorcopia.DibujarVector(color3);
        vectorcopia.DibujarVectorDiferente(Vector2.X, Vector2.Y, color3);

        VectorPoderoso vectormitad = new VectorPoderoso(vectorcopia.X, vectorcopia.Y);
        vectormitad.Multiplicar(multi);
        vectormitad.Suma(Vector2);
        vectormitad.DibujarVector(color4);
    }
}
