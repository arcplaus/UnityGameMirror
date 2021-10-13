using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InteractionObject : MonoBehaviour
{
    public bool open = false;
    public string noteName = null;
    public void doInteration() {
        gameObject.SetActive(false);
    }

    public void openDoor() {
      //  gameObject.transform.rotation = new Vector3(90);
    }
}
