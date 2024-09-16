using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [Header("States")]
    public IdleState idleState;
    public JumpState jumpState;
    public RunState runState;

    private State currentState;

    [Header("Jump")]
    public Transform groundCheck;
    public float checkRadius;
    public LayerMask whatIsGround;
    public int extraJumpsValue;

    // player components
    private Rigidbody2D _rig;
    public Rigidbody2D rig 
    {  
        get { return _rig; }
        set { _rig = value; }
    }

    private Vector2 _direction;

    // jump variables
    private bool _isGrounded;
    public bool isGrounded
    {
        get { return _isGrounded; }
        set { _isGrounded = value; }
    }


    // propriedade para acessar _direction em outro script
    public Vector2 direction
    {
        get{return _direction;}
        set{_direction = value;}
    }
    private bool _isJumping;
    public bool isJumping
    {
        get{return _isJumping;}
        set{_isJumping = value;}
    }


    private void Start()
    {
        currentState = idleState;
        currentState.Enter();
        
        rig = GetComponent<Rigidbody2D>();
    }

    private void Update()
    {
        OnInput();
        Flip();
        JumpInput();

        currentState.Do();
        currentState.FixedDo();

        if (currentState.isComplete)
        {
            ChangeState(GetNextState());
        }
    }

    private void FixedUpdate()
    {
        OnGround();
    }

    #region State
    private State GetNextState()
    {
        if (isJumping)
        {
            return jumpState;
        }
        else if (direction.sqrMagnitude > 0)
        {
            return runState;
        }
        else
        {
            return idleState;
        }
    }

    private void ChangeState(State newState)
    {
        currentState.Exit();
        currentState = newState;
        currentState.Enter();
    }

    #endregion

    #region Movement

    private void OnInput()
    {
        _direction = new Vector2(Input.GetAxisRaw("Horizontal"), 0);
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
            jumpState.extraJumps = extraJumpsValue;
            _isJumping = false;
        }

        if (Input.GetKeyDown(KeyCode.UpArrow) || Input.GetButtonDown("Jump"))
        {
            if (isGrounded || jumpState.extraJumps > 0)
            {
                rig.velocity = new Vector2(rig.velocity.x, jumpState.jumpForce);
                _isJumping = true;
                jumpState.extraJumps--;
            }
        }
    }


#endregion

}
