using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MuerteJugador : MonoBehaviour
{
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Enemigo")) // Si colisionas con un objeto, con el tag "Enemigo" Se destruye y se reinicia.
        {
            Destroy(gameObject);
            Reiniciar();
        }
    }
    void Reiniciar() // Se carga nuevamente la escena.
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
}
