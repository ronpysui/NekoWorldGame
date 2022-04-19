using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovementHandler : MonoBehaviour
{
    [SerializeField]float velocity;
    [SerializeField]float velocity_multiplyer;
    [SerializeField]float jump_force;
    [SerializeField]float jumpDelay;
    public bool isfacingRight;
    private Animator animator;
    private float jumpStart=0f;
    public bool isGrounded;
    public LayerMask groundLayers;

    private void Start(){
        animator=GetComponent<Animator>();
    }
    private void FixedUpdate(){
        //horizontal input
        float movementx=Input.GetAxis("Horizontal")*velocity*Time.deltaTime;
        transform.Translate(movementx,0,0);
    }
    async void Update()
    {
        //is grounded
        isGrounded=Physics2D.OverlapArea(new Vector2(transform.position.x-0.5f,transform.position.y-0.5f),
        new Vector2(transform.position.x+0.5f,transform.position.y-0.5f),groundLayers);
        if(isGrounded==true){
            animator.SetBool("jump",false);
        }
        else if(isGrounded==false){
            animator.SetBool("run",false);
            animator.SetBool("jump",true);
        }

        if(Input.GetKeyDown(KeyCode.LeftShift)){
            animator.SetFloat("velocity multiplyer",velocity_multiplyer);
            velocity=3.2f;
        }
        else if(Input.GetKeyUp(KeyCode.LeftShift)){
            animator.SetFloat("velocity multiplyer",1);
            velocity=1.8f;
        }
        else if(Input.GetKeyDown(KeyCode.Space)&&Time.time>jumpStart){
            if(isGrounded==true){
                GetComponent<Rigidbody2D>().AddForce(new Vector2(0,jump_force),ForceMode2D.Impulse);
            }
            jumpStart=Time.time+jumpDelay;
        }

        if(Input.GetKey(KeyCode.A)){
            transform.localScale=new Vector2(-1,1);
            if(isGrounded==true){
                animator.SetBool("run",true);
            }
        }
        else if(Input.GetKey(KeyCode.D)){
            transform.localScale=new Vector2(1,1);
            if(isGrounded==true){
                animator.SetBool("run",true);
            }
        }
        else{
            animator.SetBool("run",false);
        }
    }
}
