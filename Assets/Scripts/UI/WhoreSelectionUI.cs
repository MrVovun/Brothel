﻿using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

[System.Serializable]
public class WhoreClientEvent : UnityEvent<Whore, Client> {

}

public class WhoreSelectionUI : MonoBehaviour {
    public GameObject WhoreButtonPrefab;
    public GameObject WhoreButtonsContainer;
    public GameObject ConfirmationUI;

    public WhoreClientEvent WhoreConfirmed;

    private Client client;
    private Whore preSelectedWhore;
    private List<GameObject> buttons = new List<GameObject> ();

    public void ShowSelectionUI (Client client, Whore[] whores) {
        clearButtons ();
        this.client = client;
        foreach (Whore whore in whores) {
            GameObject button = Instantiate (WhoreButtonPrefab, Vector3.zero, Quaternion.identity);
            buttons.Add (button);
            button.GetComponent<Image> ().sprite = whore.Personality.whorePortrait;
            button.GetComponentInChildren<TextMeshProUGUI> ().text = whore.Personality.whoreName;
            button.transform.SetParent (WhoreButtonsContainer.transform);
            button.GetComponent<Button> ().onClick.AddListener (delegate { preSelectedWhore = whore; });
            if (whore.level == client.level) {
                button.GetComponent<Button> ().onClick.AddListener (delegate { ShowConfirmationUI (); });
            } else if (whore.level > client.level) {
                //requires less stamina from whore
                button.GetComponent<Button> ().onClick.AddListener (delegate { ShowConfirmationUI (); });
            } else {
                Debug.Log (whore.Personality.whoreName + "'s level doesn't fit");
            }
        }

        gameObject.SetActive (true);
    }

    public void ShowConfirmationUI () {
        ConfirmationUI.gameObject.SetActive (true);
    }

    public void OnWhoreConfirmed () {
        WhoreConfirmed.Invoke (preSelectedWhore, client);
        resetState ();
        gameObject.SetActive (false);
    }

    public void OnWhoreCanceled () {
        resetState ();
        gameObject.SetActive (false);
    }

    private void resetState () {
        client = null;
        preSelectedWhore = null;
        ConfirmationUI.gameObject.SetActive (false);
    }

    private void clearButtons () {
        foreach (GameObject button in buttons) {
            Destroy (button);
        }
        buttons.Clear ();
    }
    //
    //    private void Awake() {
    //        GetComponent<Button>().onClick.AddListener(delegate {
    ////            GameController.Instance.ShowInfo(thisWhoreInfo, isGenericInfo);
    //        });
    //    }
    //
    //    public void FitsToClient() {
    //        GetComponentInChildren<TextMeshProUGUI>().text = GetComponentInChildren<TextMeshProUGUI>().text + "\nFits!";
    //    }

    //
    //    public void AssignWhore(GameObject whorePrefab) {
    //        whoreGen = whorePrefab.GetComponent<Whore>();
    ////        whoreGen.thisWhoreButton = gameObject;
    //        GetComponent<Image>().sprite = whoreGen.Personality.whorePortrait;
    //        GetComponentInChildren<TextMeshProUGUI>().text = whoreGen.Personality.whoreName;
    ////        if (GameController.Instance.CompareClient().Contains(whoreGen.WhoreData) == true) {
    ////            FitsToClient();
    ////        }
    //
    //        thisWhoreInfo = "Name: " + whoreGen.Personality.whoreName + "\n" + "Description: " + whoreGen.Personality.whoreDesc + "\n" +
    //                        "Fits to client: " + whoreGen.Personality.fitsToClient;
    //    }
}
