﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameController : MonoBehaviour {

    #region Singleton

    public static GameController instance;

    private void Awake () {
        if (instance != null) {
            Debug.LogWarning ("More than one instance found");
            return;
        }
        instance = this;
    }
    #endregion

    Camera cam;

    void Start () {
        cam = Camera.main;
    }

    void Update () {
        if (Input.GetMouseButtonDown (0)) {
            Interact ();
        }
        if (Input.GetKeyDown (KeyCode.Space)) {
            SpawnClient ();
        }
        if (Input.GetKeyDown (KeyCode.C)) {
            CompareClient ();
        }
    }

    void Interact () {
        Ray ray = cam.ScreenPointToRay (Input.mousePosition);
        RaycastHit hit;

        if (Physics.Raycast (ray, out hit, 100)) {
            Interactable interactable = hit.collider.GetComponent<Interactable> ();
            if (interactable != null) {
                cam.GetComponent<CameraController> ().Focus (interactable.transform);
            }
        }
    }
    void SpawnClient () {
        ClientHolder.instance.Spawn ();
    }
    public List<Whore> CompareClient () {
        int clientNum = ClientHolder.instance.clientClone.GetComponent<ClientGenerator> ().client.fitsToWhore;
        List<Whore> fittingWhores = new List<Whore> ();
        for (int i = 0; i < WhoreHolder.instance.listOfWhores.Count; i++) {
            if (clientNum == WhoreHolder.instance.listOfWhores[i].GetComponent<WhoreGenerator> ().whore.fitsToClient) {
                fittingWhores.Add (WhoreHolder.instance.listOfWhores[i].GetComponent<WhoreGenerator> ().whore);
            }
        }
        return fittingWhores;
    }
}
