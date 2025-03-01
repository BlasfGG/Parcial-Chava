using UnityEngine;

public class Arma : MonoBehaviour
{
    [SerializeField] float velocidadBala;
    [SerializeField] GameObject balaPrefab;
    [SerializeField] Transform puntoTiro;
    [SerializeField] float cadenciaDisparo = 0.5f; // Tiempo entre disparos en segundos

    private float tiempoUltimoDisparo;

    private void Start()
    {
        tiempoUltimoDisparo = -cadenciaDisparo; // Permite disparar inmediatamente al inicio
    }

    void Update()
    {
        AccionarArma();
    }

    public void AccionarArma()
    {
        if (JalaGatillo() && PuedeDisparar())
        {
            Disparar();
            SoindoDisparo();
        }
    }

    bool JalaGatillo()
    {
        return Input.GetKeyDown(KeyCode.Mouse0);
    }

    bool PuedeDisparar()
    {
        return Time.time >= tiempoUltimoDisparo + cadenciaDisparo;
    }

    public void SoindoDisparo()
    {
        AudioManager.AudioInstance.Play("Disparo");
    }

    public void Disparar()
    {
        tiempoUltimoDisparo = Time.time;
        GameObject clone = Instantiate(balaPrefab, puntoTiro.position, puntoTiro.rotation);
        Rigidbody rb = clone.GetComponent<Rigidbody>();
        rb.AddForce(puntoTiro.forward * velocidadBala, ForceMode.Impulse);
        Destroy(clone, 7);
    }
}
