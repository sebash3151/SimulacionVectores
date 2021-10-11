using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MyCustomLookAt : MonoBehaviour
{
    [SerializeField] Color color;
    VectorPoderoso posicion;
    [SerializeField] float speed = 5f;
    VectorPoderoso observar;

    void Start()
    {
        posicion = new VectorPoderoso(transform.position.x, transform.position.y);
    }

    void Update()
    {
        var mousePosition = GetWorldMousePosition();
        RotateZ(LookAtOMG(mousePosition));
        Impulso();
    }

    private void Impulso()
    {

        VectorPoderoso velocity = observar.Multiplicar(speed);
        Vector3 finalPosition = new Vector3(velocity.X, velocity.Y, 0);
        transform.position += finalPosition * Time.deltaTime;
    }

    private float LookAtOMG(VectorPoderoso mirar)
    {
        observar = mirar.Resta(posicion);
        observar.Normalizar();
        mirar.DibujarVector(color);
        float direccion = Mathf.Atan2(mirar.Y, mirar.X);
        RotateZ(direccion);
        return (direccion);
    }

    private VectorPoderoso GetWorldMousePosition()
    {
        Camera camera = Camera.main;
        Vector3 screenPos = new Vector3(Input.mousePosition.x, Input.mousePosition.y, camera.nearClipPlane);
        Vector4 worldPos = Camera.main.ScreenToWorldPoint(screenPos);
        VectorPoderoso posicionFinal = new VectorPoderoso(worldPos.x, worldPos.y);
        return posicionFinal;
    }

    private void RotateZ(float radians)
    {
        transform.rotation = Quaternion.Euler(0.0f, 0.0f, radians * Mathf.Rad2Deg);
    }
}
