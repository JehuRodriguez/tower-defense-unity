using UnityEngine;

public class Enemy : MonoBehaviour,IMovible
{
    //Estadisticas del enemigo
    public string nombre;
    public int vida;
    public float velocidad;
    public float posicion;

    public virtual void Mover()
    {
        //Movimiento
        transform.Translate(Vector3.forward * velocidad * Time.deltaTime);
        posicion = transform.position.z;
        Debug.Log(nombre + " avanza. Posicion actual " + transform.position);

    }

    public virtual void RecibirDaño(int dañoRecibido)
    {
        vida -= dañoRecibido;
        if (vida < 0)
        {
            vida = 0;
        }


        Debug.Log(nombre + " recibio " + dañoRecibido + " de daño.Vida restante: " + vida);


        if (vida <= 0)
        {
            Morir();
        }
    }


    public bool EstaVivo()
    {
     return vida > 0;
    }

    protected virtual void Morir()
    {

    Debug.Log(nombre + " ha sido eliminado.");
    Destroy(gameObject);

    }
}
