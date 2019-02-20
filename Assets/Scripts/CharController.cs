using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent (typeof (CharacterMovement))]

public class CharController : MonoBehaviour {

    public Camera cam;
    public LayerMask movementMask;

    CharacterMovement movement;

    [SerializeField]
    bool isMainCharacter;

    void Start () {
        cam = Camera.main;
        if (isMainCharacter == true) {
            cam.GetComponent<CameraController> ().Focus (transform);
        }
        movement = GetComponent<CharacterMovement> ();
    }

    void Update () {
        if (Input.GetMouseButtonDown (0) && isMainCharacter == true) {
            MoveToGround ();
        }
        if (Input.GetMouseButtonDown (1) && isMainCharacter == true) {
            MoveToObject ();
        }
        if (Input.GetKeyDown (KeyCode.Space)) {
            cam.GetComponent<CameraController> ().Focus (transform);
        }
    }

    void MoveToGround () {
        Ray ray = cam.ScreenPointToRay (Input.mousePosition);
        RaycastHit hit;

        if (Physics.Raycast (ray, out hit, 100, movementMask)) {
            movement.MoveToPoint (hit.point);
        }
    }

    void MoveToObject () {

        Ray ray = cam.ScreenPointToRay (Input.mousePosition);
        RaycastHit hit;

        if (Physics.Raycast (ray, out hit, 100)) {
            Interactable interactable = hit.collider.GetComponent<Interactable> ();
            if (interactable != null) {
                cam.GetComponent<CameraController> ().Focus (interactable.transform);
                movement.FollowTarget (interactable);
            }
        }
    }

}
