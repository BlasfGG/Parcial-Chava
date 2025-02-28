using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemigoVida : MonoBehaviour
{
    [SerializeField]
    private int vida;

    public void Da�o(int da�o)
    {
        vida -= da�o;

        if (vida <= 0)
        {
           
            Destroy(this.gameObject);
        }
    }
}
