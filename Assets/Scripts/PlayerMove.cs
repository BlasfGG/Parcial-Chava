using UnityEngine;

public class PlayerMove : MonoBehaviour
{
    //Correr
    [SerializeField] private float speed = 0f;
    [SerializeField] private float velocidadCorrer = 5f;
    private float velocidadNormal = 1f;
    private bool estaCorriendo;

    //Saltar
    [SerializeField] private float gravity = -9.81f;
    [SerializeField] private float boxRadio = 0.3f;
    [SerializeField] private float jump = 3f;
    [SerializeField] private LayerMask groundMask;
    [SerializeField] private Transform groundCheck;
    [SerializeField] private AudioSource salto;
    private bool isgrounded;

    [SerializeField] private CharacterController controller;
    Vector3 velocity;

    void Update()
    {
        Cursor.visible = false;

        isgrounded = Physics.CheckSphere(groundCheck.position, boxRadio, groundMask);
        if (isgrounded && velocity.y < 0)
        {
            velocity.y = -2f;
        }

        float x = Input.GetAxis("Horizontal");
        float z = Input.GetAxis("Vertical");

        Vector3 move = transform.right * x + transform.forward * z;
        controller.Move(move * speed * Time.deltaTime * velocidadNormal);

        JumpCheck();
        RunCheck();

        velocity.y += gravity * Time.deltaTime;
        controller.Move(velocity * Time.deltaTime);
    }

    public void JumpCheck()
    {
        if (Input.GetKeyDown(KeyCode.Space) && isgrounded)
        {
            salto.Play();
            velocity.y = Mathf.Sqrt(jump * -2 * gravity);
            
        }
    }

    public void RunCheck()
    {
        if (Input.GetKeyDown(KeyCode.LeftShift))
        {
            estaCorriendo = !estaCorriendo; //||Si es true = lo apaga||, ||Si es false = lo prende||
        }
        if (estaCorriendo == true)
        {
            velocidadNormal = velocidadCorrer;
        }
        else
        {
            velocidadNormal = 1f;
        }
    }

    void OnDrawGizmos()
    {
        // Establecer el color del Gizmo
        Gizmos.color = Color.red;
        // Dibujar una esfera de alambre en la posición y radio especificados
        Gizmos.DrawWireSphere(transform.position, boxRadio);
    }
}
