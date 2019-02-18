using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Detector_Controller : MonoBehaviour
{
    public GameObject person;
    private void OnCollisionEnter(Collision collision) {
        if (collision.gameObject.tag == "Dog") {
            person.GetComponent<Person_Controller>().canMove = false;
        }
    }

    private void OnCollisionExit(Collision collision) {
        if (collision.gameObject.tag == "Dog") {
            person.GetComponent<Person_Controller>().canMove = true;
        }
    }
}
