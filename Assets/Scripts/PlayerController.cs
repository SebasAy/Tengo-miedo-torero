using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerController : MonoBehaviour
{
    public float initialMoveDistance = 2f;
    public float moveSpeed = 5f;
    public float jumpForce = 7f;
    private Rigidbody2D rb;
    private bool isGrounded;
    private bool hasMoved = false;
    public SueloInfinito[] suelos;

    void Start() => rb = GetComponent<Rigidbody2D>();

    void Update()
    {
        // Solo se mueve una vez hacia la derecha hasta cierta distancia
        if (!hasMoved && transform.position.x < initialMoveDistance)
        {
            rb.linearVelocity = new Vector2(moveSpeed, rb.linearVelocity.y);
        }
        else
        {
            rb.linearVelocity = new Vector2(0, rb.linearVelocity.y);
            hasMoved = true;
            // Activar el movimiento del suelo
            foreach (var suelo in suelos)
            {
                suelo.ActivarMovimiento();
            }
        }

        if ((Input.GetKeyDown(KeyCode.Space) || Input.GetMouseButtonDown(0)) && isGrounded)
        {
            rb.linearVelocity = new Vector2(rb.linearVelocity.x, jumpForce);
            isGrounded = false;
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.contacts[0].normal.y > 0.5f)
            isGrounded = true;
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Diablo")) // Asegúrate de que el enemigo tenga este tag
        {
            Debug.Log("¡Tocado por un policía!");
            SceneManager.LoadScene("GameOver"); // Cambia por el nombre exacto de tu escena
        }
    }
}   

