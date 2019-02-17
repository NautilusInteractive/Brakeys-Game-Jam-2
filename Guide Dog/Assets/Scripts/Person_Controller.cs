using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Person_Controller : MonoBehaviour
{
    [SerializeField]
    private Vector3 direction;
    [SerializeField]
    private bool move;
    [SerializeField]
    private float speed = 2.0f;
    // Start is called before the first frame update
    void Start()
    {
        direction = transform.forward;
        move = true;
    }

    // Update is called once per frame
    void Update()
    {
        if (move) {
            transform.Translate(direction * Time.deltaTime * speed);
        }
    }
}
