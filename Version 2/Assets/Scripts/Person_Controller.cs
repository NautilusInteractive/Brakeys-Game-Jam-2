using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Person_Controller : MonoBehaviour
{
    public float speed;
    public float turnSpeed;
    
    private Vector3 moveDirection;
    public GameObject UI;

    private Animator animator;

    public AudioSource hitSound;
    public AudioSource pickupSound;

    private void Start() {
        moveDirection = Vector3.forward;
        animator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update() {
        transform.Translate(moveDirection * speed * Time.deltaTime, Space.World);

        Vector3 lookDirection = Vector3.RotateTowards(transform.forward, moveDirection, turnSpeed * Time.deltaTime, 0.0f);
        transform.rotation = Quaternion.LookRotation(lookDirection);
    }

    public void OnBark(Vector3 dogPosition) {
        animator.SetTrigger("Startle");
        moveDirection = transform.position - dogPosition;
        moveDirection /= moveDirection.magnitude;
        moveDirection.y = 0.0f;
    }

    void Respawn() {
        hitSound.Play();
        UI.GetComponent<UI_Controller>().LoseLife();
        transform.position = Vector3.zero;
    }

    void Pet(GameObject dog) {
        dog.GetComponent<Dog_Controller>().Pet();
    }

    void Pickup(GameObject pickup) {
        pickupSound.Play();
        UI.GetComponent<UI_Controller>().AddScore(1);
        Destroy(pickup);
    }

    private void OnCollisionEnter(Collision collision) {
        switch (collision.gameObject.tag) {
            case "Pickup":
                Pickup(collision.gameObject);
                break;
            case "Dog":
                Pet(collision.gameObject);
                break;
            case "Obstacle":
                Respawn();
                break;
        }
    }
}
