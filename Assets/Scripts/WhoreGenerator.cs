using UnityEngine;

public class WhoreGenerator : Interactable {
    public Whore whore;
    public GameObject thisWhoreButton;
    public bool isOccupied = false;
    public int stamina = 100;

    public void MoveWhoreToClient() {
        GetComponent<Walker>().WalkToTarget(ClientHolder.Instance.clientClone.GetComponent<ClientGenerator>());
    }

    public void MoveWhore(Vector3 point) {
        GetComponent<Walker>().MoveToPoint(point);
    }

    public void MoveClientToRoom(GameObject client) {
        GetComponent<Walker>().MoveToPoint(RoomBehaviour.Instance.entrance.transform.position);
        client.GetComponent<Walker>().Follow(this);
        ClientHolder.Instance.clientClone = null;
        ClientHolder.Instance.clientQueue -= 1;
        //start coroutine for moving to the room entrance
        RoomBehaviour.Instance.SomeoneEnteredTheRoom(gameObject, client);
    }
}