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
        ClientDataFactory.Instance.GenerateClientData (Personality);
    }

    public void Handled (Whore whore) {
        isBusy = false;
        Debug.Log ("Client has been handled");
        GeneratePayment (whore);
        GameManager.Instance.money += amountClientWillPay;
        Debug.Log (GameManager.Instance.money);
        Destroy (gameObject);
    }

    public void Interrupted (Whore whore) {
        isBusy = false;
        Debug.Log ("Sex was interrupted");
        Destroy (gameObject);
    }

    public void GeneratePayment (Whore whore) {
        int reqTime = Random.Range (10, 30);
        staminaRequired = reqTime;
        int payPerNeed = 20;
        int payPerFetish = 50;
        amountClientWillPay = reqTime + payPerNeed * whore.fittingPreferencesForCurrentClient + payPerFetish;
    }

}
