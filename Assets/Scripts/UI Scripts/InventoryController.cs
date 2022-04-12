using System.Collections;
using UnityEngine.UI;
using TMPro;
using System.Collections.Generic;
using UnityEngine;

public class InventoryController: MonoBehaviour
{
    public List<GameObject>inventorySlots=new List<GameObject>();
    public List<string>items;
    public List<bool>invCheck;
    public bool canCollide;
    public Dictionary<string,int>nonStackableItemsContainer=new Dictionary<string, int>(){
    };
    public Dictionary<string,int>StackableItemsContainer=new Dictionary<string, int>(){
        {"pumkinseed",0},
        {"milk",0},
    };
    private void Awake(){
        inventorySlots.Add(GameObject.Find("InvSlot_1"));
        inventorySlots.Add(GameObject.Find("InvSlot_2"));
        inventorySlots.Add(GameObject.Find("InvSlot_3"));
        inventorySlots.Add(GameObject.Find("InvSlot_4"));
        inventorySlots.Add(GameObject.Find("InvSlot_5"));
    }
    private void Update(){
        if(items.Count>0){//if theres any items in item list
            for(int i=0;i<items.Count;i++){//loop
                if(StackableItemsContainer.ContainsKey(items[i])){
                    GameObject.FindWithTag("InvSlot_"+i+"_Quantity").GetComponent<TextMeshProUGUI>().text=StackableItemsContainer[items[i]].ToString();
                }
                //update each inventory slot
            }
        }
    }

    //inventory animation

}
