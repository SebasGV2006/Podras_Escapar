using UnityEngine;
using Cinemachine;
using System.Collections;

public class Teleport : MonoBehaviour
{
    public GameObject puntoSalida;
    private CinemachineVirtualCamera virtualCamera;
    private ScreenFader fader;

    private void Start()
    {
        // Buscamos la Cinemachine Virtual Camera en la escena
        virtualCamera = FindObjectOfType<CinemachineVirtualCamera>();

        // Buscamos el fader en la escena
        fader = FindObjectOfType<ScreenFader>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("personaje"))
        {
            StartCoroutine(TeleportWithFade(collision));
        }
    }

    private IEnumerator TeleportWithFade(Collider2D collision)
    {
        if (fader != null)
            yield return StartCoroutine(fader.FadeOut());

        // Teletransportamos al jugador
        collision.transform.position = puntoSalida.transform.position;

        // La cámara sigue al clone real
        if (virtualCamera != null)
            virtualCamera.Follow = collision.transform;

        if (fader != null)
            yield return StartCoroutine(fader.FadeIn());
    }
}
