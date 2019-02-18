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

    private Vector3 direction;

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
        direction = new Vector3(Input.GetAxis("Horizontal"), 0.0f, Input.GetAxis("Vertical"));
        transform.Translate(direction * Time.deltaTime * speed, Space.World);

        Vector3 lookDirection = Vector3.RotateTowards(transform.forward, direction, turnSpeed * Time.deltaTime, 0.0f);
        // Move our position a step closer to the target.
        transform.rotation = Quaternion.LookRotation(lookDirection);
    }

    private void Bark() {
        Debug.Log("Bark");
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
