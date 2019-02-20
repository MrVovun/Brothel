using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour {
    public Vector3 offset;
    public float pitch = 2f;

    public void Focus (Transform target) {
        transform.position = target.position - offset;
        Debug.Log ("Camera focused on: " + target);
    }

}
