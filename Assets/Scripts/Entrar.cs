using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Entrar : MonoBehaviour
{
    public GameObject panelDialogEntrada;

    private void Start()
    {
        // Al iniciar el juego, el panel está oculto
        if (panelDialogEntrada != null)
        {
            panelDialogEntrada.SetActive(false);
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        // Verifica si el objeto que entra al trigger tiene el Tag "personaje"
        if (collision.CompareTag("personaje"))
        {
            Debug.Log("Está cerca de la entrada ");

            if (panelDialogEntrada != null)
            {
                panelDialogEntrada.SetActive(true);
            }
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        // Verifica si el objeto que sale del trigger tiene el Tag "personaje"
        if (collision.CompareTag("personaje"))
        {
            Debug.Log("Está lejos de la entrada ");

            if (panelDialogEntrada != null)
            {
                panelDialogEntrada.SetActive(false);
            }
        }
    }
}
