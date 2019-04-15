using System.Collections;
using UnityEngine;

[RequireComponent (typeof (Walker))]
public class Client : Interactable {
    public ClientData Personality;
    public int level;
    public int expForMe;
    public int amountClientWillPay;
    public int reqTime;
    public int payPerNeed = 20;
    public int payPerFetish = 50;

    private bool isBusy;
    private Walker walker;

    private void Start () {
        reqTime = Random.Range (10, 30);
        walker = GetComponent<Walker> ();
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
        Personality = ScriptableObject.CreateInstance<ClientData> ();
        DataFactory.Instance.GenerateClientData (Personality);
    }

    public void Handled (Whore whore) {
        isBusy = false;
        Debug.Log ("Client has been handled");
        GeneratePayment (whore);
        GameManager.Instance.money += amountClientWillPay;
        Destroy (gameObject);
    }

    public void Interrupted (Whore whore) {
        isBusy = false;
        Debug.Log ("Sex was interrupted");
        Destroy (gameObject);
    }

    public void GeneratePayment (Whore whore) {
        amountClientWillPay = reqTime + payPerNeed * whore.fittingPreferencesForCurrentClient + payPerFetish;
    }

}
