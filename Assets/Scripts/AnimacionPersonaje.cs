using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimacionPersonaje : MonoBehaviour
{
    public Animator animator;
    public int movimiento = 0;

    public void Click()
    {
        //animator.SetTrigger(estado);
       
        switch (movimiento)
        {
            case 1:
                animator.GetComponent<MovementInput>().izquierda = true;
                animator.GetComponent<MovementInput>().derecha = false;
                animator.GetComponent<MovementInput>().arriba = false;
                animator.GetComponent<MovementInput>().abajo = false;
                break;
            case 2:
                animator.GetComponent<MovementInput>().izquierda = false;
                animator.GetComponent<MovementInput>().derecha = true;
                animator.GetComponent<MovementInput>().arriba = false;
                animator.GetComponent<MovementInput>().abajo = false; ;
                break;
            case 3:
                animator.GetComponent<MovementInput>().izquierda = false;
                animator.GetComponent<MovementInput>().derecha = false;
                animator.GetComponent<MovementInput>().arriba = true;
                animator.GetComponent<MovementInput>().abajo = false;
                break;
            case 4:
                animator.GetComponent<MovementInput>().izquierda = false;
                animator.GetComponent<MovementInput>().derecha = false;
                animator.GetComponent<MovementInput>().arriba = false;
                animator.GetComponent<MovementInput>().abajo = true;
                break;
        }
        
        //animator.contr
    }
    
}
