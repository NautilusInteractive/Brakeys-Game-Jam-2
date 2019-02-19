using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Dog_Controller : MonoBehaviour
{
    [SerializeField]
    private float speed;
    [SerializeField]
    private float turnSpeed;
    [SerializeField]
    private float barkRadius;

    private Vector3 MoveDirection;
    private CharacterController controller;

    void Start() {
        controller = GetComponent<CharacterController>();    
    }

    void Update()
    {
        Move();

        if (Input.GetKeyDown("space")) {
            Bark();
        }
        if (Input.GetKeyDown("e")) {
            Interact();
        }
    }

    private void Move() {
        MoveDirection = new Vector3(Input.GetAxis("Horizontal"), 0.0f, Input.GetAxis("Vertical")) * speed;
        if (!controller.isGrounded)
            MoveDirection += Physics.gravity;
        controller.Move(MoveDirection * Time.deltaTime);

        MoveDirection.y = 0.0f;
        Vector3 lookDirection = Vector3.RotateTowards(transform.forward, MoveDirection, turnSpeed * Time.deltaTime, 0.0f);
        transform.rotation = Quaternion.LookRotation(lookDirection);
    }

    private void Bark() {
        //Debug.Log("Bark");
        Collider[] hitColliders = Physics.OverlapSphere(transform.position, barkRadius);
        int i = 0;
        while (i < hitColliders.Length) {
            switch (hitColliders[i].tag) {
                case "Person":
                    hitColliders[i].GetComponent<Person_Controller>().OnBark();
                    break;
                case "Enemy":
                    break;
            }
            i++;
        }
    }

    private void Interact() {
        Debug.Log("Interact");
    }
}
