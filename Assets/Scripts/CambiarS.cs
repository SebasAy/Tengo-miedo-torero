using UnityEngine;
using UnityEngine.SceneManagement;

public class CambiarS : MonoBehaviour
{
    public string nombreEscena; // Nombre exacto de la escena a cargar

    public void CargarEscena()
    {
        SceneManager.LoadScene(nombreEscena);
    }
}
