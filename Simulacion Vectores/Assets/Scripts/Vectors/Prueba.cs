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
        Vector1.DibujarVector(color);
        Vector2.DibujarVector(color2);

        var mitad = VectorPoderoso.Lerpear(Vector1, Vector2, multi);
        mitad.DibujarVector(color3);
      
    }
}
