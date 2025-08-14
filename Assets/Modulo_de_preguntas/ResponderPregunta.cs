using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ResponderPregunta : MonoBehaviour
{
    public Text canva_puntos;
    public int puntosPorRespuesta = 0;
    public GameObject activadorPregunta;
    public GameObject Pregunta;

    public static int puntos;

    void Start()
    {
        UpdatePuntosText(); // Actualizar el texto de los puntos al inicio
    }

    // Llamar a esta función pasando true si la respuesta es correcta, false si es incorrecta
    public void Preguntas(bool esCorrecta)
    {
        if (esCorrecta)
        {
            puntos += puntosPorRespuesta;
            StartCoroutine(res_correcta());
        }
        else
        {
            StartCoroutine(res_incorrecta());
        }
    }

    IEnumerator res_correcta()
    {
        gameObject.GetComponent<AudioSource>().Play();
        UpdatePuntosText();
        yield return new WaitForSeconds(0.5f);
        UpdatePuntosText();
        
        // Solo si es correcta, se eliminan
        Destroy(Pregunta);
        Destroy(activadorPregunta);
        // Si quieres que deje de detectar inmediatamente antes de destruir:
        // activadorPregunta.GetComponent<Collider2D>().enabled = false;
    }

    IEnumerator res_incorrecta()
    {
        // Si quieres un sonido diferente para respuesta incorrecta, ponlo aquí
        yield return null; // No se destruye nada
    }

    void UpdatePuntosText()
    {
        canva_puntos.text = "puntos: " + puntos;
    }

    void ClearPuntosText()
    {
        canva_puntos.text = "";
    }
}
