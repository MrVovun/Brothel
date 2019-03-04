using UnityEngine;
using UnityEngine.AI;
[RequireComponent (typeof (NavMeshAgent))]
public class WhoreGenerator : Interactable {
    public Whore whore;
    public GameObject thisWhoreButton;

    public void MoveWhoreToClient () {
        GetComponent<CharacterMover> ().MoveToPoint (ClientHolder.instance.clientClone.transform.position);

    }
}
