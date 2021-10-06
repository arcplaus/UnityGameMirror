using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Inventory : MonoBehaviour
{
    // Start is called before the first frame update

    public GameObject[] inventory = new GameObject[10];
    public void addItem(GameObject item) {
        for (int i = 0; i < inventory.Length; i++) {
            if (inventory[i] == null) {
                inventory[i] = item;
                break;
            }
        }
    }
    public bool hasItem(GameObject item) {
        for (int i = 0; i < inventory.Length; i++)
        {
            if (inventory[i].CompareTag(item.tag))
            {
                return true;
            }
        }
        return false;
    }
}
