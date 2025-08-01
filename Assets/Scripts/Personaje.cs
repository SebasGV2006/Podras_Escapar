using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "NuevoPersonaje", menuName = "Personaje")]

public class Personaje : ScriptableObject
{
    public GameObject personajeJugable;
    public Sprite imagen;

    public string nombre;
}
