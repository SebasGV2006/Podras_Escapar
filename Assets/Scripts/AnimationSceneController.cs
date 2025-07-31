using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections;
using UnityEngine.UI;

public class AnimationSceneController : MonoBehaviour
{
    public GameObject textObjecto;   // ← público para arrastrar el texto desde el inspector
    public float waitAfterText = 3f;

    private void Start()
    {
        textObjecto.SetActive(false); // desactiva el texto al inicio
    }

    // Llamado por el Animation Event
    public void OnAnimationEnd()
    {
        textObjecto.SetActive(true);   // activa el texto
        StartCoroutine(ShowTextAndWait());
        Debug.Log("La animación terminó, mostrando texto");
    }

    IEnumerator ShowTextAndWait()
    {
        yield return null;            // fuerza a Unity a dibujar el texto
        yield return new WaitForSeconds(waitAfterText);
        SceneManager.LoadScene("Menu_inicio");
    }
}
