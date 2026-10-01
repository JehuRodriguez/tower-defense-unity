using UnityEngine;

public class GameLoopManager : MonoBehaviour
{
    public enum EstadoJuego { Inicio, EnJuego, GameOver, Victoria }

    //Estado del jugador
    public EstadoJuego estadoActual = EstadoJuego.Inicio;
    public int vidasJugador = 10;
    public WaveManager waveManager;

    private void Start()
    {
        IniciarJuego();
    }

    public void IniciarJuego()
    {
        estadoActual = EstadoJuego.EnJuego;
        Debug.Log("<color=yellow>--- JUEGO INICIADO ---</color>");

        if (waveManager != null)
        {
            waveManager.IniciarSiguienteOleada();
        }
    }

    public void ReducirVida(int cantidad)
    {
        if (estadoActual != EstadoJuego.EnJuego) return;

        vidasJugador -= cantidad;
        Debug.Log($"<color=orange>Vida base reducida. Vidas restantes: {vidasJugador}</color>");

        if (vidasJugador <= 0)
        {
            ProcesarGameOver();
        }
    }

    private void ProcesarGameOver()
    {
        estadoActual = EstadoJuego.GameOver;
        Debug.Log("<color=red><b>¡GAME OVER! Has perdido la base.</b></color>");
        Time.timeScale = 0f; // Pausa el juego
    }

    public void ProcesarVictoria()
    {
        estadoActual = EstadoJuego.Victoria;
        Debug.Log("<color=green><b>¡VICTORIA! Has defendido todas las oleadas.</b></color>");
    }
}
