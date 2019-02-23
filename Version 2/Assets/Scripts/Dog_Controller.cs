using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Dog_Controller : MonoBehaviour
{
    public GameObject person;
    public float normalSpeed;
    public float turnSpeed;

    public float boostSpeed;
    public float boostTime;
    private float boostRemaining;

    public float timeBetweenPets;
    public ParticleSystem heartsEmitter;
    private float petCooldown;

    private Animator animator;

    public ParticleSystem feetEmitter;

    public AudioSource audioSource;

    private void Start() {
        animator = transform.GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 moveDirection = new Vector3(Input.GetAxis("Horizontal"), 0.0f, Input.GetAxis("Vertical"));

        // Apply speed boost
        float speed = normalSpeed;

        if (boostRemaining > 0) {
            speed = boostSpeed;
        }
        else {
            heartsEmitter.Stop();
        }

        // Move with speed
        transform.Translate(moveDirection * speed * Time.deltaTime, Space.World);

        // Rotate to direction
        Vector3 lookDirection = Vector3.RotateTowards(transform.forward, moveDirection, turnSpeed * Time.deltaTime, 0.0f);
        transform.rotation = Quaternion.LookRotation(lookDirection);

        // Animate to walk
        if (moveDirection.magnitude > 0) {
            animator.SetBool("Walking", true);
            feetEmitter.Play();
            audioSource.UnPause();
        }
        else {
            animator.SetBool("Walking", false);
            feetEmitter.Stop();
            audioSource.Pause();
        }

        // Bark
        if (Input.GetKeyDown("space")) {
            Bark();
        }

        // exit to Menu on escape
        if (Input.GetKeyDown("escape")) {
            SceneManager.LoadScene("Main Menu");
        }

        // Tick timers
        petCooldown = Mathf.Max(petCooldown - Time.deltaTime, 0);
        boostRemaining = Mathf.Max(boostRemaining - Time.deltaTime, 0);
    }

    void Bark() {
        animator.SetTrigger("Bark");
        person.GetComponent<Person_Controller>().OnBark(transform.position);
    }

   public void Pet() {
        if (petCooldown == 0) {
            boostRemaining = boostTime;
            petCooldown = timeBetweenPets;
            // Trigger love hearts
            heartsEmitter.Play();
        }
    }
}
