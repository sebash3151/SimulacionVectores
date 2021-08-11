using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Prueba : MonoBehaviour
{
    [SerializeField] VectorPoderoso Vector1, Vector2;
    [SerializeField] Color color, color2, color3, color4, color5;
    //[SerializeField] float origenx, origeny;
    [SerializeField][Range(0,1)] float multi;

    private void Update()
    {
        VectorPoderoso vectorcopia = new VectorPoderoso(Vector2.X, Vector2.Y);
        Vector1.DibujarVector(color);
        Vector2.DibujarVector(color2);

        vectorcopia.Resta(Vector1);
        vectorcopia.DibujarVector(color3);
        vectorcopia.DibujarVectorDiferente(Vector1.X, Vector1.Y, color3);

        VectorPoderoso vectormitad = new VectorPoderoso(vectorcopia.X, vectorcopia.Y);
        vectormitad.Lerpear(vectormitad, Vector1, multi);
        vectormitad.DibujarVector(color4);

        /*vectormitad.Multiplicar(multi);
        vectormitad.Suma(Vector1);
        vectormitad.DibujarVector(color4);
        */
    }
}
