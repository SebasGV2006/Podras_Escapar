using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BanioPanel : MonoBehaviour
{
    public GameObject panelDialogBanio;

    private void Start()
    {
        // Al iniciar el juego, el panel está oculto
        if (panelDialogBanio != null)
        {
            panelDialogBanio.SetActive(false);
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        // Verifica si el objeto que entra al trigger tiene el Tag "personaje"
        if (collision.CompareTag("personaje"))
        {
            Debug.Log("Está cerca de la entrada incorrecta");

            if (panelDialogBanio != null)
            {
                panelDialogBanio.SetActive(true);
            }
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        // Verifica si el objeto que sale del trigger tiene el Tag "personaje"
        if (collision.CompareTag("personaje"))
        {
            Debug.Log("Está lejos de la entrada incorrecta");

            if (panelDialogBanio != null)
            {
                panelDialogBanio.SetActive(false);
            }
        }
    }
}
