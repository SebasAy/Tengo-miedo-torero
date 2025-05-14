using UnityEngine;

public class GeneradorBloques : MonoBehaviour
{
    public GameObject[] bloques;         // Prefabs de los bloques
    public float intervalo = 2.5f;       // Tiempo entre spawns
    private float proximoSpawn = 0f;

    public float posicionX = 20f;        // Lugar donde aparecen los bloques (fuera de pantalla)
    public float posicionY = 0f;         // Y (puedes ajustar si quieres altura variable)

    void Update()
    {
        if (Time.time >= proximoSpawn)
        {
            SpawnBloque();
            proximoSpawn = Time.time + intervalo;
        }
    }

    void SpawnBloque()
    {
        int indice = Random.Range(0, bloques.Length);
        Vector3 posicion = new Vector3(posicionX, posicionY, 0);
        Instantiate(bloques[indice], posicion, Quaternion.identity);
    }
}
