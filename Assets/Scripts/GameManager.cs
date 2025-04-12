
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;


public class GameManager : MonoBehaviour
{
    public static GameManager Instance;
    [SerializeField] private TextMeshProUGUI contador;
    [SerializeField] public int enemigos;
    private int enemigosIniciales;

    void Start()
    {
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(this.gameObject);
            enemigosIniciales = enemigos;
            contador.text = "Enemigos Restantes: " + enemigos.ToString();
        }
        else
        {
            Destroy(this.gameObject);
        }
    }

    private void Update()
    {
        if (enemigos == 0)
        {
            SceneManager.LoadScene("Creditos");
            Debug.Log("Has Ganado");
        }
    }

    public void RestarContador()
    {
        enemigos--;
        UpdateContador();
    }

    // Reiniciar el marcador de enemigos
    public void ResetEnemyScore()
    {
        contador.text = "Enemigos Restantes: " + enemigosIniciales.ToString();
        enemigos = 20;
        Debug.Log("Enemy Score reset to 20");
    }

    private void UpdateContador()
    {
        if (contador != null)
        {
            contador.text = "Enemigos Restantes: " + enemigos.ToString();
        }
    }

}
