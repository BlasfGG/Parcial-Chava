using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Balas : MonoBehaviour
{
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Enemigo"))
        {
            Destroy(this.gameObject); // Destruye la bala 
            Destroy(collision.gameObject); // Destruye la collision
            GameManager.Instance.RestarContador();
        }
    }
}
