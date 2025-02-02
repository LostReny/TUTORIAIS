using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class State : MonoBehaviour
{
    public PlayerController player;
    public Animator anim;

    public bool isComplete { get; protected set; }

    protected float startTime; 

    public float time => Time.time - startTime;

    public virtual void Enter() 
    {
        player = GetComponent<PlayerController>();
        anim = GetComponent<Animator>();
    }


    public virtual void Do() { }
    public virtual void FixedDo() { }
    public virtual void Exit() { }
}
