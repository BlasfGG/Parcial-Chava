
using TMPro;
using UnityEngine;

public class PauseMenu : MonoBehaviour
{
    private bool gameIsPaused = false;

    [SerializeField] private GameObject backGround;
    [SerializeField] private GameObject sure;
    [SerializeField] private TextMeshProUGUI exitMenu;

    void Start()
    {
        backGround.SetActive(false); // Asegura que el menú de pausa esté apagado al inicio
    }

    void Update()
    {
        HandlePause();
    }

    void HandlePause()
    {
        if (Input.GetKeyDown(KeyCode.Escape)) // Si se presiona la tecla Escape
        {
            if (!gameIsPaused) // Si el juego no está en pausa
            {
                Pause(); // Pausa el juego
            }
            else
            {
                Continue(); // Reanuda el juego
            }
        }
    }

    public void Continue() // Método para reanudar el juego
    {
        backGround.SetActive(false);
        gameIsPaused = false;
        Time.timeScale = 1f;
    }

    void Pause() // Método para pausar el juego
    {
        backGround.SetActive(true);
        gameIsPaused = true;
        Time.timeScale = 0f;
    }

    public void Exit()
    {
        exitMenu.enabled = false; // Desactiva el texto de salida
        sure.SetActive(true); // Activa el menú de confirmación
    }
    public void Yes()
    {
        Application.Quit(); // Sale de la aplicación
    }
    public void No()
    {
        sure.SetActive(false); // Desactiva el menú de confirmación
        exitMenu.enabled = true; // Activa el texto de salida
    }
}
