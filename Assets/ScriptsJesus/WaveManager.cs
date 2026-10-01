using UnityEngine;
using System.Collections;

public class WaveManager : MonoBehaviour
{
    //Configuracion de Oleadas
    public GameObject enemigoPrefab;
    public Transform spawnPoint;
    public float tiempoEntreEnemigos = 1.0f;
    public float tiempoEntreOleadas = 5.0f;

    private int oleadaActual = 1;
    private bool generandoOleada = false;

    // Cálculo recursivo/iterativo de Fibonacci
    private int CalcularFibonacci(int n)
    {

        if (n <= 0) return 0;
        if (n == 1) return 1;

        int a = 0;
        int b = 1;
        for (int i = 2; i <= n; i++)
        {
            int temp = a + b;
            a = b;
            b = temp;
        }
        return b;
    }

    public void IniciarSiguienteOleada()
    {
        if (!generandoOleada)
        {
            StartCoroutine(GenerarOleadaCoroutine());
        }
    }

    private IEnumerator GenerarOleadaCoroutine()
    {
        generandoOleada = true;
        int cantidadEnemigos = CalcularFibonacci(oleadaActual + 1); // Serie: 1, 2, 3, 5, 8, 13...

        Debug.Log("<color=cyan>¡Iniciando Oleada " + oleadaActual + "! Enemigos a generar: " + cantidadEnemigos + "</color>");

        for (int i = 0; i < cantidadEnemigos; i++)
        {
            if (enemigoPrefab != null && spawnPoint != null)
            {
                Instantiate(enemigoPrefab, spawnPoint.position, spawnPoint.rotation);
            }
            yield return new WaitForSeconds(tiempoEntreEnemigos);
        }

        oleadaActual++;
        generandoOleada = false;
        Debug.Log("<color=green>Oleada completada. Próxima oleada en " + tiempoEntreOleadas + " segundos.</color>");
    }


}
