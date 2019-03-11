using UnityEngine;

public class WhoreGenerator : Interactable {
    public Whore whore;
    public GameObject thisWhoreButton;
    public bool isOccupied = false;
    public int stamina = 100;

    public void MoveWhoreToClient () {
        GetComponent<CharacterMover> ().MoveToTarget (ClientHolder.instance.clientClone.GetComponent<ClientGenerator> ());
    }

    public void MoveWhore (Vector3 point) {
        GetComponent<CharacterMover> ().MoveToPoint (point);
    }

    public void MoveClientToRoom (GameObject client) {
        GetComponent<CharacterMover> ().MoveToPoint (RoomBehaviour.instance.entrance.transform.position);
        client.GetComponent<CharacterMover> ().FollowTarget (this);
        ClientHolder.instance.clientClone = null;
        ClientHolder.instance.clientQueue -= 1;
        //start coroutine for moving to the room entrance
        RoomBehaviour.instance.SomeoneEnteredTheRoom (gameObject, client);

    }
}
