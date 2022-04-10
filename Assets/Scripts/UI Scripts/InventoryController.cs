using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InventoryController: MonoBehaviour
{
    public List<GameObject>items;
    public List<int>invSlotPosition;
    public List<bool>invCheck;
    public Dictionary<string, int> itemContainer = new Dictionary<string, int>(){
        {"milk",0}
    };
}
