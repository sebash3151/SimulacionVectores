using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

[Serializable]
public struct VectorPoderoso 
{
    [SerializeField] public float X, Y;

    public VectorPoderoso(float x, float y)
    {
        X = x;
        Y = y;
    }

    public VectorPoderoso Suma (VectorPoderoso VectoraSumar)
    {
        X = X + VectoraSumar.X;
        Y = Y + VectoraSumar.Y;     
        return new VectorPoderoso(X,Y); 
    }

    public VectorPoderoso Resta(VectorPoderoso VectoraRestar)
    {
        X = X - VectoraRestar.X;
        Y = Y - VectoraRestar.Y;
        return new VectorPoderoso(X, Y);
    }

    public VectorPoderoso Multiplicar(float ValoraMultiplicar)
    {
        X = X * ValoraMultiplicar;
        Y = Y * ValoraMultiplicar;
        return new VectorPoderoso(X, Y);
    }

    public float CalcularMagnitud()
    {
        float magnitudresultante = Mathf.Sqrt(Mathf.Pow(X, 2) + Mathf.Pow(Y, 2));        
        return magnitudresultante;
    }

    public VectorPoderoso Normalizar()
    {
        float MagnitudHallada = CalcularMagnitud();
        if (MagnitudHallada == 0)
        {
            return new VectorPoderoso(0, 0);
        }
        float magX = X / MagnitudHallada;
        float magY = Y / MagnitudHallada;
        return new VectorPoderoso(magX, magY);
    }

    public override string ToString()
    {
        return ("(" + X.ToString() + " , " + Y.ToString() + ")");
    }

    public void DibujarVector(Color color)
    {
        Vector3 temporal = new Vector3(X, Y);
        Debug.DrawLine(Vector3.zero, temporal, color);
    }
    public void DibujarVectorDiferente(float x, float y, Color color)
    {
        Vector3 inicio = new Vector3(x, y);
        Vector3 temporal = new Vector3(X+x, Y+y);
        Debug.DrawLine(inicio, temporal, color);
    }

    public static VectorPoderoso Lerpear(VectorPoderoso vec1, VectorPoderoso vec2, float t)
    {
        var copia = new VectorPoderoso(vec2.X, vec2.Y);
        copia.Resta(vec1);
        var mitad = new VectorPoderoso(copia.X, copia.Y);
        mitad.Multiplicar(t);
        mitad.Suma(vec1);
        return mitad;
    }
}



