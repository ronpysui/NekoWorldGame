using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DamageHandler : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D other){
        if(other.gameObject.tag=="Enemy"){
            gameObject.GetComponent<SpriteRenderer>().color=new Color32(226,69,67,255);
        }
    }
    private void OnTriggerExit2D(Collider2D other){
        if(other.gameObject.tag=="Enemy"){
            gameObject.GetComponent<SpriteRenderer>().color=new Color32(255,255,255,255);
        }
    }
}
