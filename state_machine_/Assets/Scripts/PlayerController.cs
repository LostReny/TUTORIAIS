using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [Header("Movement")]
    public float speed;
    public float jumpForce;

    private Rigidbody2D rig;
    private Vector2 direction;

    //jump variables
    private bool isGrounded;


    private void Start()
    {
        rig = GetComponent<Rigidbody2D>();
    }

    private void Update()
    {
        OnInput();
        Flip();
    }

    private void FixedUpdate()
    {
        OnMove();
    }

    private void OnInput()
    {
        direction = new Vector2(Input.GetAxisRaw("Horizontal"),0);
    }

    private void OnMove()
    {
        rig.MovePosition(rig.position + direction * speed * Time.fixedDeltaTime);
    }

    private void Flip() 
    {
        if(direction.x > 0)
        {
            transform.eulerAngles = new Vector2(0, 0);
        }
        if(direction.x < 0)
        {
            transform.eulerAngles = new Vector2(0, 180);
        }
    }
}
