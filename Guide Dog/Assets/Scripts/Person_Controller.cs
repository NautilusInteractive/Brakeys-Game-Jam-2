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

    public GameObject UI;
    public GameObject dog;
    private Vector3 direction;
    private CharacterController controller;

    void Start()
    {
        direction = transform.forward;
        controller = GetComponent<CharacterController>();
    }

    void Update()
    {
        if (canMove) {
            Move();
        }
    }

    private void Move() {
        Vector3 MoveDirection = direction * speed;
        if (!controller.isGrounded)
            MoveDirection += Physics.gravity;
        controller.Move(MoveDirection * Time.deltaTime);

        MoveDirection.y = 0.0f;
        Vector3 lookDirection = Vector3.RotateTowards(transform.forward, MoveDirection, turnSpeed * Time.deltaTime, 0.0f);
        transform.rotation = Quaternion.LookRotation(lookDirection);
    }

    public void OnBark() {
        direction = transform.position - dog.transform.position;
        direction /= direction.magnitude;
        direction.y = 0.0f;
    }

    private void Respawn() {
        Vector3 spawnPosition = transform.position;
        spawnPosition.z -= 2.0f;
        transform.position = spawnPosition;
    }

    private void OnCollisionEnter(Collision collision) {
        switch (collision.gameObject.tag) {
            case "Obstacle":
                UI.GetComponent<UI_Controller>().loseLive();
                Respawn();
                break;
            case "Dog":
                canMove = false;
                break;
        }
    }
    private void OnCollisionExit(Collision collision) {
        if (collision.gameObject.tag == "Dog") {
            canMove = true;
        }
    }
}
