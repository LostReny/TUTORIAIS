using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [Header("Movement")]
    public float speed;


    [Header("Jump")]
    public float jumpForce;
    public Transform groundCheck;
    public float checkRadius;
    public LayerMask whatIsGround;
    private int extraJumps; 
    public int extraJumpsValue;
    private bool _isJumping;

    // player components
    private Rigidbody2D rig;
    private Vector2 _direction;

    // jump variables
    private bool isGrounded;

    // propriedade para acessar _direction em outro script
    public Vector2 direction
    {
        get{return _direction;}
        set{_direction = value;}
    }

    public bool isJumping
    {
        get{return _isJumping;}
        set{_isJumping = value;}
    }


    private void Start()
    {
        extraJumps = extraJumpsValue;
        rig = GetComponent<Rigidbody2D>();
    }

    private void Update()
    {
        OnInput();
        Flip();
        JumpInput();
    }

    private void FixedUpdate()
    {
        OnMove();
        OnGround();
    }

#region Movement

    private void OnInput()
    {
        _direction = new Vector2(Input.GetAxisRaw("Horizontal"), 0);
    }

    private void OnMove()
    {
        rig.velocity = new Vector2(_direction.x * speed, rig.velocity.y);
    }

    private void Flip() 
    {
        if (_direction.x > 0)
        {
            transform.eulerAngles = new Vector2(0, 0);
        }
        else if (_direction.x < 0)
        {
            transform.eulerAngles = new Vector2(0, 180);
        }
    }

#endregion

#region Jump

    private void OnGround()
    {   
        isGrounded = Physics2D.OverlapCircle(groundCheck.position, checkRadius, whatIsGround);
    }

    private void JumpInput()
    {
        if (isGrounded)
        {
            extraJumps = extraJumpsValue;
            _isJumping = false; 
        }

        if (Input.GetKeyDown(KeyCode.UpArrow) || Input.GetButtonDown("Jump"))
        {
            if (extraJumps > 0)
            {
                rig.velocity = new Vector2(rig.velocity.x, jumpForce);
                extraJumps--;
            }
            else if (extraJumps == 0 && isGrounded)
            {
                rig.velocity = new Vector2(rig.velocity.x, jumpForce);
            }
            _isJumping = true; 
        }
    }

#endregion

}
