using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ActivadorPregunta : MonoBehaviour {
    public GameObject Pregunta;

    void Start() {
        Pregunta.SetActive(false);
    }

    void OnTriggerEnter2D(Collider2D col) {
        if (col.gameObject.CompareTag("personaje")) {
            Pregunta.SetActive(true);
        }
    }

    void OnTriggerExit2D(Collider2D col) {
        if (col.gameObject.CompareTag("personaje")) {
            Pregunta.SetActive(false);
        }
    }
}
