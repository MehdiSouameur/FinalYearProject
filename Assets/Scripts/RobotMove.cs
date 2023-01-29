using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RobotMove : MonoBehaviour
{
    private Animator animator;

    [Header("Movement")]
    public float moveSpeed;

    public Transform orientation;

    [Header("Timer")]
    public float timer = 2;

    Vector3 moveDirection;

    Rigidbody rb;

    private bool isMoving;
    private bool isMove = true;

    // Start is called before the first frame update
    void Start()
    {
        animator = GetComponent<Animator>();
        rb = GetComponent<Rigidbody>();
        rb.freezeRotation = true;
    }

    private void FixedUpdate()
    {
        if (timer > 0)
            timer -= Time.deltaTime;
        else
        {
            setMove();
            this.timer = 2;
        }

        isMoving = animator.GetBool("isMoving");

        if (isMoving)
        {
            Move();
        } 
        else if(!isMoving)
        {
            rb.velocity = new Vector3(0, 0, 0);
        }
        Debug.Log(animator.GetBool("isMoving"));
    }

    // Update is called once per frame
    void Update()
    {
            
    }

    private void Move()
    {
        moveDirection = orientation.forward;
        rb.AddForce(moveDirection.normalized * moveSpeed * 10f, ForceMode.Force);
    }

    private void setMove()
    {
        this.isMove = !this.isMove;
        animator.SetBool("isMoving", isMove);
    }

}
