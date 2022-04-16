using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class ItemDropFunction : MonoBehaviour
{
    public InventoryController invscript;
    public async void Update(){
        Debug.Log(invscript.StackableItemsContainer["pumkinseed"]);
        //if items list index count > 0 and scroll position is > 1
        if(invscript.items.Count>0&&invscript.scrollposition>1){
            //if Q key is pressed and slot is taken
            if(Input.GetKeyDown(KeyCode.Q)&&invscript.invCheck[invscript.scrollposition-2]==false){
                //if item in slot ==1
                if(invscript.scrollposition>=2&&invscript.StackableItemsContainer[invscript.items[invscript.scrollposition-2].ToString()]==1){
                    //new component
                    GameObject new_item=new GameObject(invscript.items[invscript.scrollposition-2].ToString());

                    //add components
                    new_item.AddComponent<Rigidbody2D>();
                    new_item.AddComponent<BoxCollider2D>();
                    new_item.AddComponent<SpriteRenderer>();
                    new_item.AddComponent<PickUpFunction>();

                    //edit components
                    new_item.GetComponent<BoxCollider2D>().size=new Vector2(0.22f,0.277998f);
                    new_item.GetComponent<PickUpFunction>().isPickable=true;

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
                    new_item.GetComponent<Rigidbody2D>().AddForce(new Vector2(0,10),ForceMode2D.Impulse);

                    //minus 1 from stackable item list
                    invscript.StackableItemsContainer[invscript.items[invscript.scrollposition-2]]--;
                    //remove item from item list
                    invscript.items.RemoveAt(invscript.scrollposition-2);
                    //set slot space to avalible
                    invscript.invCheck[invscript.scrollposition-2]=true;
                }
                //if item in slot >1
                else{
                    invscript.StackableItemsContainer[invscript.items[invscript.scrollposition-2]]--;
                    //new component
                    GameObject new_item=new GameObject(invscript.items[invscript.scrollposition-2].ToString());
                    //add components
                    new_item.AddComponent<Rigidbody2D>();
                    new_item.AddComponent<BoxCollider2D>();
                    new_item.AddComponent<SpriteRenderer>();
                    new_item.AddComponent<PickUpFunction>();

                    //add scripts
                    new_item.GetComponent<PickUpFunction>().invscript=GameObject.Find("Player").GetComponent<InventoryController>();
                    new_item.GetComponent<PickUpFunction>().player=GameObject.Find("Player");

                    //edit components
                    new_item.GetComponent<BoxCollider2D>().size=new Vector2(0.22f,0.277998f);
                    new_item.GetComponent<PickUpFunction>().isPickable=true;
                    new_item.GetComponent<SpriteRenderer>().sprite=Resources.Load<Sprite>("Sprites/Icons/"+invscript.items[invscript.scrollposition-2])as Sprite;

                    //load sprite
                    new_item.GetComponent<PickUpFunction>().spriteImage=Resources.Load<Sprite>("Sprites/Icons/"+invscript.items[invscript.scrollposition-2])as Sprite;

                    if(invscript.StackableItemsContainer.ContainsKey(new_item.name)){
                        new_item.GetComponent<PickUpFunction>().isStackable=true;
                    }
                    new_item.transform.position=GameObject.Find("Player").transform.position;
                    new_item.GetComponent<Rigidbody2D>().AddForce(new Vector2(0,10),ForceMode2D.Impulse);
                }
            }
        }
    }
}
