using System.Collections;
using UnityEngine.UI;
using TMPro;
using System.Collections.Generic;
using UnityEngine;

public class InventoryController: MonoBehaviour
{
    public List<string>items;
    public List<bool>invCheck;
    public bool canCollide;
    public Dictionary<string,int>nonStackableItemsContainer=new Dictionary<string, int>(){
        {"pizza",0}
    };
    public Dictionary<string,int>StackableItemsContainer=new Dictionary<string, int>(){
        {"milk",0},
    };
    private void Start(){
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
}
