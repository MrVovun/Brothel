﻿using UnityEngine;

public class Interactable : MonoBehaviour {
    public float radius = 3f;
    public virtual void Interact () {
        Debug.Log ("Interacted with + " + transform.name);
    }
}
