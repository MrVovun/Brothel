using UnityEngine;

public class WhoreGenerator : Interactable {
    public Whore whore;
    public GameObject thisWhoreButton;
    public bool isOccupied = false;
    public GameObject MyClient;

    public void MoveWhoreToClient () {
        GetComponent<CharacterMover> ().MoveToTarget (ClientHolder.instance.clientClone.GetComponent<ClientGenerator> ());
    }

    public void MoveWhore (Vector3 point) {
        GetComponent<CharacterMover> ().MoveToPoint (point);
    }

    public void GiveInfoToTheRoom () {
        //get client and some data from him
        //give it to room with stamina needed to reduce
        //disable whore and client and start coroutine, time is gathered from whore and calculated depending on stats
        //after coroutine end spawn both of them again
        //whore goes to default position, client goes to cashbox, then leaves
    }
}
