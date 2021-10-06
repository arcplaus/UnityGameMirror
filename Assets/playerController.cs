using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playerController : MonoBehaviour
{
    // Start is called before the first frame update
    Camera cam;
    public ArrayList inventory;
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
    
    }

    public void addToInventory(int add) {
        inventory.Add(add);
    }
}
