using UnityEngine;

public class WhoreGenerator : Interactable {
    public Whore whore;
    public GameObject thisWhoreButton;
    public bool isOccupied = false;
    public int stamina = 100;

    public void MoveWhoreToClient () {
        GetComponent<CharacterMover> ().MoveToTarget (ClientHolder.Instance.clientClone.GetComponent<ClientGenerator> ());
    }

    public void MoveWhore (Vector3 point) {
        GetComponent<CharacterMover> ().MoveToPoint (point);
    }

    public void MoveClientToRoom (GameObject client) {
        GetComponent<CharacterMover> ().MoveToPoint (RoomBehaviour.Instance.entrance.transform.position);
        client.GetComponent<CharacterMover> ().FollowTarget (this);
        ClientHolder.Instance.clientClone = null;
        ClientHolder.Instance.clientQueue -= 1;
        //start coroutine for moving to the room entrance
        RoomBehaviour.Instance.SomeoneEnteredTheRoom (gameObject, client);

    }
}
