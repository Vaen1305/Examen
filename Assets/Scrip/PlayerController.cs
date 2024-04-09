using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerController : MonoBehaviour
{
    [SerializeField] int speed = 3;
    private Rigidbody _comRigidbody;
    private Vector3 moveInput;
    public float jump = 100f;
    public int extraJumps;
    public int extraJumpValue;
    private bool isGroun;
    private bool salto = true;



    private void Awake()
    {
        extraJumps = extraJumpValue;

        _comRigidbody = GetComponent<Rigidbody>();
    }
    private void Update()
    {
        if (isGroun == true)
        {
            extraJumps = extraJumpValue;
        }
    }
    private void FixedUpdate()
    {
        _comRigidbody.velocity = moveInput * speed;
        if(salto == false && moveInput.z > 0)
        {
            Salto();
        }
        else if (salto == true && moveInput.z < 0)
        {
            Salto();
        }
    }
    public void OnMovement(InputAction.CallbackContext contex)
    {
        moveInput = contex.ReadValue<Vector3>();
    }
    public void OnJump(InputAction.CallbackContext context)
    {
        if (context.performed)
        {
            if (isGroun || extraJumps > 0)
            {
                _comRigidbody.velocity = Vector3.up * jump;
                extraJumps--;
            }
        }
    }
    void Salto()
    {
        salto = !salto;
        Vector3 Scaler = transform.localScale;
        Scaler.x *= -1;
        transform.localScale = Scaler;
    }
}
