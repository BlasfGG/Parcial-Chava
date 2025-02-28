using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemigoVida : MonoBehaviour
{
    [SerializeField]
    private int vida;

    public void Daño(int daño)
    {
        vida -= daño;

        if (vida <= 0)
        {
           
            Destroy(this.gameObject);
        }
    }
}
