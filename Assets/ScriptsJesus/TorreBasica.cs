using UnityEngine;

public class TorreBasica : Tower
{
    public override void Atacar(Enemy objetivo)
    {
        if (objetivo != null)
        {
            Debug.Log(nombre + " dispara a " + objetivo.nombre + " haciendo " + daño + " de daño.");
            objetivo.RecibirDaño(daño);
        }
    }
}
