using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Arma : MonoBehaviour
{
    [SerializeField] private float velocidadDeBala;
    [SerializeField] private float carencia;
    [SerializeField] private GameObject municion;
    [SerializeField] private Transform puntoMira;

    private bool puedoDisparar = true;


    void Update()
    {
        DispararArma();
    }
    void DispararArma()
    {
        if (Input.GetKeyDown(KeyCode.Space) && puedoDisparar) // Tecla "Espacio" se enlaza con la accion de disparar y puedo disparar.
        {
            Disparar();
            StartCoroutine(Espera());
        }
    }
    void Disparar()
    {
        GameObject clone = Instantiate(municion, puntoMira.position, puntoMira.rotation); // Instanceo el "Prefab" y creo, clones de la municion.
        Rigidbody rb = clone.GetComponent<Rigidbody>(); // "RigidBody" de los "Prefabs" de los clones.
        rb.AddForce(Vector3.forward * velocidadDeBala); // Agrego fuerza en linea recta.
        Destroy(clone, 7); //Cuenta regresiva para destruccion de la bala.
    }
    IEnumerator Espera() //Tiempo de espera entre disparos.
    {
        puedoDisparar = false;

        yield return new WaitForSeconds(carencia);

        puedoDisparar = true;
    }
}
