using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bumpercontroller : MonoBehaviour
{
    public Collider bola;
    public float multiplier;

    private Renderer renderer;
    private Animator animator;

    private void Start()
    {
        renderer = GetComponent<Renderer>();
        animator = GetComponent<Animator>();
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.collider == bola)
        {
            Rigidbody bolaRig = bola.GetComponent<Rigidbody>();
            bolaRig.velocity *= multiplier;


            animator.SetTrigger("hit");
            
        }
        
    }
}
