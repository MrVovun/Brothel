using System.Collections;
using UnityEngine;

[RequireComponent (typeof (Walker))]
public class Client : Interactable {
    public ClientData Personality;
    public int staminaRequired;

    private bool isBusy;
    private Walker walker;

    private void Start () {
        walker = GetComponent<Walker> ();
    }

    private void OnEnable () {
        RandomizeStats ();
    }

    public bool IsBusy () {
        return isBusy;
    }

    public void DoWhore (Whore whore) {
        isBusy = true;
        walker.Follow (whore);
    }

    public void RandomizeStats () {
        //randomize client info here
    }

    public void Handled (Whore whore) {
        isBusy = false;
        Debug.Log ("Client has been handled");
        Destroy (gameObject);
    }
}
