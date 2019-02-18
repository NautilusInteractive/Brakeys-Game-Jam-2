using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Person_Controller : MonoBehaviour
{
    public bool canMove;
    [SerializeField]
    private float speed;
    [SerializeField]
    private float turnSpeed;

    public GameObject dog;
    private Vector3 direction;

    void Start()
    {
        direction = transform.forward;
    }

    void Update()
    {
        if (canMove) {
            transform.Translate(direction * Time.deltaTime * speed, Space.World);

            Vector3 lookDirection = Vector3.RotateTowards(transform.forward, direction, turnSpeed * Time.deltaTime, 0.0f);
            // Move our position a step closer to the target.
            transform.rotation = Quaternion.LookRotation(lookDirection);
        }
    }

    public void OnBark() {
        direction -= dog.transform.position;
        direction.x = Mathf.Clamp(direction.x, -speed, speed);
        direction.z = Mathf.Clamp(direction.z, -speed, speed);
        direction.y = 0.0f;
    }
}
