using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickUpFunction : MonoBehaviour
{
    [SerializeField]GameObject player;
    [SerializeField]private float translateObj;
    [SerializeField]private float timeElapsed;
    [SerializeField]private float timeSpeed;
    [SerializeField]private float maxTime;
    [SerializeField]private float impulse;

    private void OnTriggerStay2D(Collider2D other){
        if(other.gameObject.tag=="Player"){
            GetComponent<Rigidbody2D>().AddForce(new Vector2(0,impulse),ForceMode2D.Impulse);
            transform.position=Vector2.Lerp(transform.position,player.transform.position,translateObj*Time.deltaTime);
            Debug.Log("truecollide");
            if(timeElapsed<maxTime){
                timeElapsed+=timeSpeed*Time.deltaTime;
            }
            else if(timeElapsed>=maxTime){
                Destroy(gameObject);
            }
        }
    }
}
