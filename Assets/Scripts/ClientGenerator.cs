using System.Collections;
using UnityEngine;

public class ClientGenerator : Interactable {

    public Client client;

    private void Start () {
        if (BrothelEntranceController.instance.isOccupied == false) {
            GetComponent<CharacterMover> ().MoveToPoint (BrothelEntranceController.instance.transform.position);
        } else {
            //wait until isOccupied == false
        }

    }

    private void Update () {
        if (transform.position.z == BrothelEntranceController.instance.transform.position.z && transform.position.x == BrothelEntranceController.instance.transform.position.x) {
            BrothelEntranceController.instance.isOccupied = true;
            BrothelEntranceController.instance.currentClient = this;
        }
    }

    public void GenerateClient () {
        client = Resources.Load ("ScriptableObjects/Client") as Client;
        //randomize client info here
    }
}
