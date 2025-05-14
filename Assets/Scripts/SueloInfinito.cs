using UnityEngine;

public class SueloInfinito : MonoBehaviour
{
    public float moveSpeed = 5f; // Igual a la velocidad del personaje
    public float resetPositionX = -20f; // Cuando este valor se alcance, se reinicia
    public float startPositionX = 20f;  // Se mueve a esta posición

    private bool activarMovimiento = false;

    void Update()
    {
        if (activarMovimiento)
        {
            transform.Translate(Vector2.left * moveSpeed * Time.deltaTime);

            if (transform.position.x < resetPositionX)
            {
                float ancho = GetComponent<SpriteRenderer>().bounds.size.x;
                transform.position += new Vector3(ancho * 2, 0, 0);
            }
        }
    }

    public void ActivarMovimiento() => activarMovimiento = true;
}
