using UnityEngine;

public class GameManager : MonoBehaviour
{
    private static GameManager instancia;
    public int dinero = 500;
    public int vidas = 10;
    public int enemigosDestruidos = 0;
    public delegate void CambioEstado(string mensaje);

    
    public event CambioEstado EstadoJuegoCambio;

    public static GameManager ObtenerInstancia()
    {
        if (instancia == null)
        {
            instancia = FindObjectOfType<GameManager>();
        }

        return instancia;
    }

    private void Awake()
    {
        if (instancia == null)
        {
            instancia = this;
            DontDestroyOnLoad(gameObject);
        }
        else if (instancia != this)
        {
            Destroy(gameObject);
        }
    }

    private void Start()
    {
        Debug.Log("GameManager inicio");
    }

    public void AgregarDinero(int cantidad)
    {
        dinero += cantidad;

        Debug.Log("Dinero actual: " + dinero);

        if (EstadoJuegoCambio != null)
        {
            EstadoJuegoCambio.Invoke("El dinero cambió. Dinero actual: " + dinero);
        }
    }
}