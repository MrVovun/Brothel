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
    Vector3 clientDestination;
    public GameObject[] whoresOnTheField;
    [SerializeField]
    GameObject whereToSpawnButtons;
    [SerializeField]
    GameObject buttonPrefab;

    void Start () {
        cam = Camera.main;
        UpdateClientDestination ();
        GatherTheWhores ();
    }

    void Update () {
        if (Input.GetMouseButtonDown (0)) {
            Interact ();
        }
        if (Input.GetKeyDown (KeyCode.Space)) {
            SpawnClient ();
        }
        if (Input.GetKeyDown (KeyCode.E)) {
            MoveClientToPoint ();
        }
        if (Input.GetKeyDown (KeyCode.A)) {
            AddWhore ();
        }
        if (Input.GetKeyDown (KeyCode.C)) {
            CompareClient ();
        }
        if (Input.GetKeyDown (KeyCode.F)) {
            SpawnButton ();
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
    void MoveClientToPoint () {
        ClientHolder.instance.MoveClient (clientDestination);
    }
    public List<Whore> CompareClient () {
        int clientNum = ClientHolder.instance.clientClone.GetComponent<ClientGenerator> ().client.fitsToWhore;
        List<Whore> fittingWhores = new List<Whore> ();
        for (int i = 0; i < WhoreHolder.instance.listOfWhores.Count; i++) {
            if (clientNum == WhoreHolder.instance.listOfWhores[i].fitsToClient) {
                fittingWhores.Add (WhoreHolder.instance.listOfWhores[i]);
            }
        }
        return fittingWhores;
    }
    void AddWhore () {
        //WhoreHolder.instance.AddWhore (123);
    }
    public void UpdateClientDestination () {
        clientDestination = GameObject.FindGameObjectWithTag ("DestinationPoint").transform.position;
    }

    public void GatherTheWhores () {
        whoresOnTheField = GameObject.FindGameObjectsWithTag ("Whore");
    }

    void SpawnButton () {
        GameObject buttonToSpawn = Instantiate (buttonPrefab, transform.position, transform.rotation);
        buttonToSpawn.transform.SetParent (whereToSpawnButtons.transform);
    }
}
