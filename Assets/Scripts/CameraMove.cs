using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMove : MonoBehaviour
{
    [SerializeField] private float _speed;
    private float yRotate; 
    private float xRotate;


    void Update()
    {
        if (Input.GetMouseButton(0))
        {
            yRotate += _speed * -Input.GetAxis("Mouse Y");
            yRotate = Mathf.Clamp(yRotate, -40f, 20f);
            xRotate += _speed * -Input.GetAxis("Mouse X");
            xRotate = Mathf.Clamp(xRotate, -40f, 40f);
            transform.eulerAngles = new Vector3(yRotate, -xRotate);
            
        }
    }
}
