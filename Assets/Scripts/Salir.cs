using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Salir : MonoBehaviour
{
    public void SalirDelJuego()
    {
        Application.Quit();
        Debug.Log("Se cerro");
    }
}
