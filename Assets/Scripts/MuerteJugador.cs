
using UnityEngine;
using UnityEngine.SceneManagement;

public class MuerteJugador : MonoBehaviour
{
    
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Enemigo")) // Si colisionas con un objeto, con el tag "Enemigo" Se destruye y se reinicia.
        {
            Reiniciar();
            GameManager.Instance.ResetEnemyScore(); // Reinicia el contador de enemigos
        }
    }
    void Reiniciar() // Se carga nuevamente la escena.
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
}
