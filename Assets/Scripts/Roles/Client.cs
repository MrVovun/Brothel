using System.Collections;
using UnityEngine;

[RequireComponent (typeof (Walker))]
public class Client : Interactable {
    public ClientData Personality;
    public int staminaRequired;
    public int level;
    public int expForMe;
    public int amountClientWillPay;

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
        //payment
        Destroy (gameObject);
    }

    public void Interrupted (Whore whore) {
        isBusy = false;
        Debug.Log ("Sex was interrupted");
        Destroy (gameObject);
    }

    public int GeneratePayment (Whore whore) {
        int reqTime = 50;
        int needsSatisfied = 50;
        int payPerNeed = 50;
        int payPerFetish = 50;
        amountClientWillPay = reqTime + payPerNeed * needsSatisfied + payPerFetish;
        return amountClientWillPay;
    }

}
