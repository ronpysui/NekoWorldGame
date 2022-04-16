using System.Collections;
using UnityEngine.UI;
using TMPro;
using System.Collections.Generic;
using UnityEngine;

public class InventoryController: MonoBehaviour
{
    public List<GameObject>inventorySlots=new List<GameObject>();
    public List<Sprite>itemSprites=new List<Sprite>();
    public Sprite invSelectSprite;
    public Sprite invSprite;
    public List<string>items;
    public List<bool>invCheck;
    public bool canCollide;
    public int scrollposition;
    public int prevscrollposition;
    public Dictionary<string,int>nonStackableItemsContainer=new Dictionary<string, int>(){
    };
    public Dictionary<string,int>StackableItemsContainer=new Dictionary<string, int>(){
        {"pumkinseed",0},
        {"carrotseed",0},
        {"milk",0},
    };
    private void Update(){
        if(items.Count>0){//if theres any items in item list
            for(int i=0;i<items.Count;i++){//loop
                if(StackableItemsContainer.ContainsKey(items[i])){
                    GameObject.FindWithTag("InvSlot_"+i+"_Quantity").GetComponent<TextMeshProUGUI>().text=StackableItemsContainer[items[i]].ToString();
                    //update each inventory slot
                }
            }
        }
        //0-
        if(Input.GetAxis("Mouse ScrollWheel")>0f){
            if(scrollposition==1){
                GameObject.Find("InvSlot_1").GetComponent<UnityEngine.UI.Image>().sprite=invSelectSprite;
            }
            else{
                if(scrollposition<6){
                    prevscrollposition++;
                    GameObject.Find("InvSlot_"+scrollposition).GetComponent<UnityEngine.UI.Image>().sprite=invSelectSprite;
                    GameObject.Find("InvSlot_"+(prevscrollposition-1)).GetComponent<UnityEngine.UI.Image>().sprite=invSprite;
                }
            }
            if(scrollposition<6){
                scrollposition++;
            }
        }
        //-0
        else if(Input.GetAxis("Mouse ScrollWheel")<0f){
            if(prevscrollposition>1){
                scrollposition--;
                prevscrollposition--;
                GameObject.Find("InvSlot_"+scrollposition).GetComponent<UnityEngine.UI.Image>().sprite=invSprite;
                GameObject.Find("InvSlot_"+(prevscrollposition)).GetComponent<UnityEngine.UI.Image>().sprite=invSelectSprite;
            }
        }
    }
}
