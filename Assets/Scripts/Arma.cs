using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Arma : MonoBehaviour
{
    [SerializeField] float velocidadBala;
    [SerializeField] GameObject balaPrefab;
    [SerializeField] Transform puntoTiro;

   // [SerializeField] public int municionActual = 100;
    //[SerializeField] int capacidadMaxima = 100;

    


    private void Start()
    {
       AudioManager.AudioInstance.Stop("Disparo");
    }

    void Update()
    {
        AccionarArma();
    }
    public void AccionarArma()
    {
        if (JalaGatillo())
        {
            Disparar();

        }
    }
    bool JalaGatillo()
    {
        return Input.GetKeyDown(KeyCode.Mouse0);
    }

    public void Disparar()
    {
        if (JalaGatillo())
        {
            AudioManager.AudioInstance.Play("Disparo");
            GameObject clone = Instantiate(balaPrefab, puntoTiro.position, puntoTiro.rotation);
            Rigidbody rb = clone.GetComponent<Rigidbody>();
            rb.AddForce(puntoTiro.forward * velocidadBala, ForceMode.Impulse);
            Destroy(clone, 7);
            
        }
    }

  
  

}
