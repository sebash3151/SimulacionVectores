using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotationExperiment : MonoBehaviour
{
    [SerializeField] [Range(0, 360)] int rotation;
    [SerializeField] Vector3 mPosition;

    void Update()
    {

        //transform.position = new Vector4(2f, 0f, 0f);
        //Quaternion myQaternion = Quaternion.Euler(0f, 0f, rotation);
        //Matrix4x4 rotatedSpace = Matrix4x4.Rotate(myQaternion);
        //transform.position = myQaternion * transform.position;

        mPosition.x = Input.mousePosition.x;
        mPosition.y = Input.mousePosition.y;
        mPosition.z = Camera.main.nearClipPlane;
        transform.position = Camera.main.ScreenToWorldPoint(mPosition);

    }
}
