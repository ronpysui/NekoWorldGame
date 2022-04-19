using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class ItemDropFunction : MonoBehaviour
{
    public InventoryController invscript;
    public float timeElapsed;
    public float maxTime;
    public bool isPressed;
    public async void Update(){
        GameObject[]itemDropped;
        itemDropped=GameObject.FindGameObjectsWithTag("new_item");

        if(isPressed==true){
            timeElapsed+=0.3f*Time.deltaTime;
            if(timeElapsed>=maxTime){
                //GameObject.Find("PlayerCollider").GetComponent<CircleCollider2D>().enabled=true;
                //for each new_item
                foreach(GameObject items in itemDropped){
                    items.GetComponent<PickUpFunction>().isPickable=true;
                }
                timeElapsed=0;
                isPressed=false;
            }
        }
        //if items list index count > 0 and scroll position is > 1
        if(invscript.items.Count>0&&invscript.scrollposition>1){
            //if Q key is pressed and slot is taken
            if(Input.GetKeyDown(KeyCode.Q)&&invscript.invCheck[invscript.scrollposition-2]==false){
                //GameObject.Find("PlayerCollider").GetComponent<CircleCollider2D>().enabled=false;
                timeElapsed=0;
                isPressed=true;
                //if item in slot ==1 //Stackable items
                if(invscript.scrollposition>=2&&invscript.StackableItemsContainer[invscript.items[invscript.scrollposition-2].ToString()]==1){
                    //new component
                    GameObject new_item=new GameObject(invscript.items[invscript.scrollposition-2].ToString());

                    //add components
                    new_item.AddComponent<PickUpFunction>();
                    new_item.GetComponent<PickUpFunction>().isPickable=false;
                    new_item.AddComponent<Rigidbody2D>();
                    new_item.AddComponent<SpriteRenderer>();
                    new_item.AddComponent<BoxCollider2D>();
                    //edit components
                    new_item.GetComponent<BoxCollider2D>().size=new Vector2(0.22f,0.277998f);
                    new_item.tag="new_item";

                    //error in the sprite
                    new_item.GetComponent<SpriteRenderer>().sprite=Resources.Load<Sprite>("Sprites/Icons/"+invscript.items[invscript.scrollposition-2])as Sprite;
                    new_item.GetComponent<PickUpFunction>().spriteImage=Resources.Load<Sprite>("Sprites/Icons/"+invscript.items[invscript.scrollposition-2])as Sprite;

                    //load new invslot
                    GameObject.FindWithTag("InvSlot_"+(invscript.scrollposition-2).ToString()).GetComponent<UnityEngine.UI.Image>().color=new Color32(255,255,255,0);
                    GameObject.FindWithTag("InvSlot_"+(invscript.scrollposition-2)+"_Quantity").GetComponent<TextMeshProUGUI>().text="";

                    //add scripts
                    new_item.GetComponent<PickUpFunction>().invscript=GameObject.Find("Player").GetComponent<InventoryController>();
                    new_item.GetComponent<PickUpFunction>().player=GameObject.Find("Player");

                    //edit scripts
                    new_item.GetComponent<PickUpFunction>().isStackable=true;

                    //position = player position
                    new_item.transform.position=GameObject.Find("Player").transform.position;
                    new_item.transform.position=GameObject.Find("Player").transform.position;

                    //add impulse
                    //if(GameObject.Find("Player").transform.localScale=(1,1,1)){

                    //}
                    new_item.GetComponent<Rigidbody2D>().AddForce(new Vector2(5,0),ForceMode2D.Impulse);

                    //minus 1 from stackable item list
                    invscript.StackableItemsContainer[invscript.items[invscript.scrollposition-2]]--;

                    //make item index empty
                    invscript.items[invscript.scrollposition-2]="";

                    //set slot space to avalible
                    invscript.invCheck[invscript.scrollposition-2]=true;
                }
                //if item in slot >1
                else{
                    //minus 1 from item in dictionary
                    invscript.StackableItemsContainer[invscript.items[invscript.scrollposition-2]]--;

                    //new component
                    GameObject new_item=new GameObject(invscript.items[invscript.scrollposition-2].ToString());

                    //add components
                    new_item.AddComponent<PickUpFunction>();
                    new_item.GetComponent<PickUpFunction>().isPickable=false;
                    new_item.AddComponent<Rigidbody2D>();
                    new_item.AddComponent<SpriteRenderer>();
                    new_item.AddComponent<BoxCollider2D>();

                    //add scripts
                    new_item.GetComponent<PickUpFunction>().invscript=GameObject.Find("Player").GetComponent<InventoryController>();
                    new_item.GetComponent<PickUpFunction>().player=GameObject.Find("Player");

                    //edit components
                    new_item.tag="new_item";
                    new_item.GetComponent<BoxCollider2D>().size=new Vector2(0.2f,0.2f);
                    new_item.GetComponent<SpriteRenderer>().sprite=Resources.Load<Sprite>("Sprites/Icons/"+invscript.items[invscript.scrollposition-2])as Sprite;
                    new_item.GetComponent<SpriteRenderer>().sortingOrder=2;

                    //load sprite
                    new_item.GetComponent<PickUpFunction>().spriteImage=Resources.Load<Sprite>("Sprites/Icons/"+invscript.items[invscript.scrollposition-2])as Sprite;

                    //if dictionary contains the name of the new item
                    if(invscript.StackableItemsContainer.ContainsKey(new_item.name)){
                        new_item.GetComponent<PickUpFunction>().isStackable=true;
                    }

                    //new_item position = player position
                    new_item.transform.position=GameObject.Find("Player").transform.position;
                    //add impulse
                    new_item.GetComponent<Rigidbody2D>().AddForce(new Vector2(5,0),ForceMode2D.Impulse);
                }
            }
        }
    }
}
