using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Kanatlar : MonoBehaviour
{
    private Animator animator;
    // Start is called before the first frame update
    void Start()
    {
        animator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {

    }
    private void FixedUpdate()
    {
        if (Input.GetKey(KeyCode.W))
        {
            animator.SetBool("isyuksel", true);
            animator.SetBool("isby", true);


        }
        else
        {
            animator.SetBool("isyuksel", false);
            animator.SetBool("isby", false);

        }
        if (Input.GetKey(KeyCode.S))
        {
            animator.SetBool("isalcal", true);
            animator.SetBool("isucaka", true);
            animator.SetBool("isba", true);
        }
        else
        {
            animator.SetBool("isalcal", false);
            animator.SetBool("isucaka", false);
            animator.SetBool("isba", false);
        }
        if (Input.GetKey(KeyCode.A))
        {
            animator.SetBool("issoladon", true);
        }
        else
        {
            animator.SetBool("issoladon", false);
        }
        if (Input.GetKey(KeyCode.D))
        {
            animator.SetBool("issagadon", true);
        }
        else
        {
            animator.SetBool("issagadon", false);
        }
        
    }
}
