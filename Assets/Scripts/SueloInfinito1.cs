using UnityEngine;

public class SueloInfinito1 : MonoBehaviour
{
    public float velocidad = 5f;          // Igual que la del jugador
    public float limiteX = -25f;          // Cuando el bloque llegue a esta posición, se destruye

    void Update()
    {
        // Mover el bloque hacia la izquierda
        transform.Translate(Vector2.left * velocidad * Time.deltaTime);

        // Destruir el bloque si ya salió de la pantalla
        if (transform.position.x < limiteX)
        {
            Destroy(gameObject);
        }
    }
}
