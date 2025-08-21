using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    public Transform jugador;     // Jugador a seguir
    public float suavizado = 10f;  // Velocidad de seguimiento
    private Vector3 offset;

    [Header("Mapa con Sprites")]
    public Transform mapa; // Arrastra aquí el objeto padre "Aula"

    private float minX, maxX, minY, maxY;
    private float camaraHalfHeight, camaraHalfWidth;

    void Start()
    {
        offset = transform.position - jugador.position;

        // Tamaño de la cámara
        Camera cam = Camera.main;
        camaraHalfHeight = cam.orthographicSize;
        camaraHalfWidth = cam.orthographicSize * cam.aspect;

        // Calcular límites basados en los sprites hijos
        CalcularLimites();
    }

    void CalcularLimites()
    {
        if (mapa == null) return;

        // Tomar todos los SpriteRenderer del mapa
        SpriteRenderer[] sprites = mapa.GetComponentsInChildren<SpriteRenderer>();

        if (sprites.Length == 0) return;

        // Usar el primer sprite como base
        Bounds bounds = sprites[0].bounds;

        // Expandir límites a todos los sprites
        foreach (SpriteRenderer sr in sprites)
        {
            bounds.Encapsulate(sr.bounds);
        }

        // Aplicar límites tomando en cuenta el tamaño de la cámara
        minX = bounds.min.x + camaraHalfWidth;
        maxX = bounds.max.x - camaraHalfWidth;
        minY = bounds.min.y + camaraHalfHeight;
        maxY = bounds.max.y - camaraHalfHeight;
    }

    void LateUpdate()
    {
        if (jugador == null) return;

        // Posición deseada
        Vector3 posicionDeseada = jugador.position + offset;

        // Suavizado
        Vector3 posicionSuavizada = Vector3.Lerp(transform.position, posicionDeseada, suavizado * Time.deltaTime);

        // Limitar dentro del mapa
        float clampX = Mathf.Clamp(posicionSuavizada.x, minX, maxX);
        float clampY = Mathf.Clamp(posicionSuavizada.y, minY, maxY);

        transform.position = new Vector3(clampX, clampY, posicionSuavizada.z);
    }
}
