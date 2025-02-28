using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMove : MonoBehaviour
{
    private float movX;
    private float movZ;

    [SerializeField]
    private float movSpeed;

    private CharacterController charCtrl;

    [SerializeField]
    private float gravedad = -9.8f;

    [SerializeField]
    private float fuerzaSalto;

    private Vector3 movVert;

    private bool isGrounded;

    [SerializeField]
    private Transform groundCheck;

    [SerializeField]
    private float radius;

    [SerializeField]
    private LayerMask whatIsGround;

    void Start()
    {
        charCtrl = GetComponent<CharacterController>();
    }

    void Update()
    {
        isGrounded = Physics.CheckSphere(groundCheck.position, radius, whatIsGround);

        
        movX = Input.GetAxis("Horizontal");
        movZ = Input.GetAxis("Vertical");

        Vector3 movimiento = transform.right * movX + transform.forward * movZ;

        charCtrl.Move(movSpeed * Time.deltaTime * movimiento);


        if (isGrounded && movVert.y < 0)
        {
            movVert.y = 0;
        }

        if (Input.GetKeyDown(KeyCode.Space) && isGrounded)
        {
           
            movVert.y = Mathf.Sqrt(fuerzaSalto * -2 * gravedad);
        }

        movVert.y += gravedad * Time.deltaTime;

        charCtrl.Move(movVert * Time.deltaTime);
    }
}
