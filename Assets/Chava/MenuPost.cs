using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Menupost : MonoBehaviour
{
    [SerializeField] private GameObject menuPost;
    bool isPaused = false;

    private void Update()
    {
        isPaused = !isPaused;
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if(isPaused)
            {
                Time.timeScale = 1f;
                menuPost.SetActive(false);
                Cursor.lockState = CursorLockMode.Locked;
            }
            else
            {
                Time.timeScale = 0f;
                menuPost.SetActive(true);
                Cursor.lockState = CursorLockMode.None;
            }
            
        }
    }
}
