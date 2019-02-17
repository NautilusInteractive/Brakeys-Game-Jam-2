using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Dog_Controller : MonoBehaviour
{
    [SerializeField]
    private float RotateSpeed = 100.0f;
    [SerializeField]
    private float MoveSpeed = 2.0f;
    
    // Update is called once per frame
    void Update()
    {
        transform.Rotate(new Vector3(0.0f, Input.GetAxis("Horizontal"), 0.0f) * Time.deltaTime * RotateSpeed);
        transform.Translate(new Vector3(0.0f, 0.0f, Input.GetAxis("Vertical")) * Time.deltaTime * MoveSpeed);
    }
}
