using UnityEngine;

public abstract class Tower : MonoBehaviour,IAtacante
{
    // Estadisticas de la torre
    public string nombre;
    public int daño;
    public int rango;
    public int costo;
    public int nivel = 1;

    public abstract void Atacar(Enemy objetivo);

    public void MostrarInfo()
    {
        Debug.Log("Torre: " + nombre + " | Daño: " + daño + " | Rango: " + rango + " | Costo: " + costo + " | Nivel: " + nivel);
    }

    public int CalcularFibonacci(int n)
    {
        if (n <= 1)
        {
            return n;
        }

        int anterior = 0;
        int actual = 1;

        for (int i = 2; i <= n; i++)
        {
            int siguiente = anterior + actual;
            anterior = actual;
            actual = siguiente;
        }
        return actual;
    }

    public void SubirNivel()
    {
        nivel++;
        int multiplicadorFibonacci = CalcularFibonacci(nivel);
        daño += multiplicadorFibonacci;
        Debug.Log(nombre + " subió a nivel " + nivel + "! Nuevo daño: " + daño + " (bonus Fibonacci: +" + multiplicadorFibonacci + ")");
    }
}
