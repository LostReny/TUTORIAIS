using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField] private Rigidbody2D rig;
    public float speed; 


    private void Update()
    {
        OnMove();   
    }

    #region Movement
    public void OnMove()
    {
        float xInput = Input.GetAxis("Horizontal");
        float yInput = Input.GetAxis("Vertical");

        if(Mathf.Abs(xInput) > 0)
        {
            rig.velocity = new Vector2(xInput * speed, rig.velocity.y);
        }
        if(Mathf.Abs(yInput) > 0)
        {
            rig.velocity = new Vector2(rig.velocity.x, yInput * speed);
        }

        //Vector2 direction = new Vector2(xInput,yInput).normalized;
        //rig.velocity = direction * speed * Time.deltaTime;
    }

    #endregion
}
