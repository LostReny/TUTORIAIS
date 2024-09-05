using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAnim : MonoBehaviour
{
   public PlayerController player;
   public Animator anim;

   public void Start()
   {
        player = GetComponent<PlayerController>();
        anim = GetComponent<Animator>();
   }

   public void Update()
   {
        if(player.direction.sqrMagnitude > 0)
        {
            anim.SetInteger("transition",1);
        }
        else
        {
            anim.SetInteger("transition",0);
        }
   }
}
