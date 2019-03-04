using UnityEngine;

public class WhoreGenerator : Interactable {
    public Whore whore;
    public GameObject thisWhoreButton;

    public void MoveWhoreToClient () {
        GetComponent<CharacterMover> ().MoveToTarget (ClientHolder.instance.clientClone.GetComponent<ClientGenerator> ());

    }

    public void MoveWhore (Vector3 point) {
        GetComponent<CharacterMover> ().MoveToPoint (point);
    }
}
