using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovementHandler : MonoBehaviour
{
    [SerializeField]float velocity;
    [SerializeField]float jump;
    private Animator animator;
    public bool isGrounded;
    public LayerMask groundLayers;

    private void Start(){
        //GameObject.Find("Sprint Icon").GetComponent<SpriteRenderer>().color=new Color32(255,255,255,140);
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

        if(Input.GetKeyDown(KeyCode.LeftShift)){
            //GameObject.Find("Sprint Icon").GetComponent<SpriteRenderer>().color=new Color32(255,255,255,255);
            animator.SetFloat("velocity multiplyer",2);
            velocity=4;
        }
        else if(Input.GetKeyUp(KeyCode.LeftShift)){
            //GameObject.Find("Sprint Icon").GetComponent<SpriteRenderer>().color=new Color32(255,255,255,140);
            animator.SetFloat("velocity multiplyer",1);
            velocity=2;
        }
        else if(Input.GetKeyDown(KeyCode.Space)){
            if(isGrounded==true){
                GetComponent<Rigidbody2D>().AddForce(new Vector2(0,jump),ForceMode2D.Impulse);
            }
        }

        if(Input.GetKey(KeyCode.A)){
            transform.localScale=new Vector2(-1,1);
            animator.SetBool("run",true);
        }
        else if(Input.GetKey(KeyCode.D)){
            transform.localScale=new Vector2(1,1);
            animator.SetBool("run",true);
        }
        else{
            animator.SetBool("run",false);
        }
    }
}
