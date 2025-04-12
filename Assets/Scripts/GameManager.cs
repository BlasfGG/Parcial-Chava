
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

    private void UpdateContador()
    {
        if (contador != null)
        {
            contador.text = "Enemigos Restantes: " + enemigos.ToString();
        }
    }

}
