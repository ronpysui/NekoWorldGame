using System.Collections;
using UnityEngine.UI;
using System.Collections.Generic;
using UnityEngine;

public class PickUpFunction : MonoBehaviour
{
    public GameObject player;
    [SerializeField]private float translateObj=4;
    [SerializeField]private float timeElapsed=0;
    [SerializeField]private float timeSpeed=5.2f;
    [SerializeField]private float maxTime=1.3f;
    [SerializeField]private float impulse=0.3f;
    public bool isStandingOnObject;
    public bool isPickable;
    public bool isStackable;
    public InventoryController invscript;
    public Sprite spriteImage;
    public int count=0;

    private async void OnTriggerStay2D(Collider2D other){
        if(invscript.invCheck[0]==false&&invscript.invCheck[1]==false&&invscript.invCheck[2]==false&&invscript.invCheck[3]==false&&invscript.invCheck[4]==false){
            invscript.canCollide=false;
        }
        else{
            invscript.canCollide=true;
        }
        if(other.gameObject.tag=="StandingOnObject"){
            Debug.Log("is Standing on object");
            if(isStackable==false){
                if(isStackable==false){//if item is not stackable
                    invscript.nonStackableItemsContainer[gameObject.name]+=1;
                    Debug.Log(invscript.nonStackableItemsContainer[gameObject.name]);
                    gameObject.SetActive(false);

                    for(int i=0;i<invscript.invCheck.Count;i++){
                        if(invscript.invCheck[i]==true){
                            invscript.items[i]=gameObject.name;
                            GameObject.FindWithTag("InvSlot_"+i.ToString()).GetComponent<UnityEngine.UI.Image>().color=new Color32(255,255,255,255);
                            GameObject.FindWithTag("InvSlot_"+i.ToString()).GetComponent<UnityEngine.UI.Image>().sprite=spriteImage;
                            invscript.invCheck[i]=false;
                            break;
                        }
                    }
                    Destroy(gameObject);
                }
            }

            else if(isStackable==true){
                invscript.StackableItemsContainer[gameObject.name]+=1;
                    gameObject.SetActive(false);

                    for(int a=0;a<invscript.invCheck.Count;a++){
                        if(invscript.invCheck[a]==true){
                            if(invscript.StackableItemsContainer[gameObject.name]==1){
                                GameObject.FindWithTag("InvSlot_"+a.ToString()).GetComponent<UnityEngine.UI.Image>().color=new Color32(255,255,255,255);
                                GameObject.FindWithTag("InvSlot_"+a.ToString()).GetComponent<UnityEngine.UI.Image>().sprite=spriteImage;
                                //invscript.items.Add(gameObject.name);
                                invscript.items[a]=gameObject.name;
                                invscript.invCheck[a]=false;
                            }
                            break;
                        }
                    }
                    Destroy(gameObject);
            }

            isStandingOnObject=true;
            Debug.Log("Standing on object");
        }
        else if(other.gameObject.tag=="Player"&&invscript.canCollide==true&&isPickable==true&&isStandingOnObject==false){
            isStandingOnObject=false;
            GetComponent<Rigidbody2D>().AddForce(new Vector2(0,impulse),ForceMode2D.Impulse);
            transform.position=Vector2.Lerp(transform.position,player.transform.position,translateObj*Time.deltaTime);
            if(timeElapsed<maxTime){
                timeElapsed+=timeSpeed*Time.deltaTime;
            }
            else if(timeElapsed>=maxTime){
                if(isStackable==false){//if item is not stackable
                    invscript.nonStackableItemsContainer[gameObject.name]+=1;
                    Debug.Log(invscript.nonStackableItemsContainer[gameObject.name]);
                    gameObject.SetActive(false);

                    for(int i=0;i<invscript.invCheck.Count;i++){
                        if(invscript.invCheck[i]==true){
                            invscript.items[i]=gameObject.name;
                            GameObject.FindWithTag("InvSlot_"+i.ToString()).GetComponent<UnityEngine.UI.Image>().color=new Color32(255,255,255,255);
                            GameObject.FindWithTag("InvSlot_"+i.ToString()).GetComponent<UnityEngine.UI.Image>().sprite=spriteImage;
                            invscript.invCheck[i]=false;
                            break;
                        }
                    }
                    Destroy(gameObject);
                }
                else if(isStackable){//if item is stackable
                    invscript.StackableItemsContainer[gameObject.name]+=1;
                    gameObject.SetActive(false);

                    for(int a=0;a<invscript.invCheck.Count;a++){
                        if(invscript.invCheck[a]==true){
                            if(invscript.StackableItemsContainer[gameObject.name]==1){
                                GameObject.FindWithTag("InvSlot_"+a.ToString()).GetComponent<UnityEngine.UI.Image>().color=new Color32(255,255,255,255);
                                GameObject.FindWithTag("InvSlot_"+a.ToString()).GetComponent<UnityEngine.UI.Image>().sprite=spriteImage;
                                //invscript.items.Add(gameObject.name);
                                invscript.items[a]=gameObject.name;
                                invscript.invCheck[a]=false;
                            }
                            break;
                        }
                    }
                    Destroy(gameObject);
                }
            }
        }
        else{
            Debug.Log("cannot pick up items because slots are full");
        }
    }
}
