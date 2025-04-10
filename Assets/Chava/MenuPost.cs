using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Menupost : MonoBehaviour
{
    [SerializeField] private GameObject menuPost;
    private bool isPaused = false;

    private void Update()
    {
        // Detecta si se presiona la tecla Escape
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            // Alterna el estado de pausa
            isPaused = !isPaused;

            if (isPaused)
            {
                PauseGame();
            }
            else
            {
                ResumeGame();
            }
        }
    }

    private void PauseGame()
    {
        Time.timeScale = 0f; // Detiene el tiempo del juego
        menuPost.SetActive(true); // Muestra el menú de pausa
        Cursor.lockState = CursorLockMode.None; // Libera el cursor
        Cursor.visible = true; // Hace visible el cursor
    }

    private void ResumeGame()
    {
        Time.timeScale = 1f; // Restaura el tiempo del juego
        menuPost.SetActive(false); // Oculta el menú de pausa
        Cursor.lockState = CursorLockMode.Locked; // Bloquea el cursor
        Cursor.visible = false; // Oculta el cursor
    }
}
