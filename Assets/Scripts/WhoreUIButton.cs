﻿using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class WhoreUIButton : MonoBehaviour {

    private TextMeshProUGUI whoreInfo;
    private WhoreGenerator whoreGen;

    private void Awake () {
        GetComponent<Button> ().onClick.AddListener (ShowWhoreInfo);
    }

    public void FitsToClient () {
        GetComponentInChildren<TextMeshProUGUI> ().text = GetComponentInChildren<TextMeshProUGUI> ().text + "\nFits!";
    }

    public void AssignWhore (GameObject whorePrefab) {
        whoreGen = whorePrefab.GetComponent<WhoreGenerator> ();
        whoreGen.thisWhoreButton = gameObject;
        GetComponent<Image> ().sprite = whoreGen.whore.whorePortrait;
        GetComponentInChildren<TextMeshProUGUI> ().text = whoreGen.whore.whoreName;
        if (GameController.instance.CompareClient ().Contains (whoreGen.whore) == true) {
            FitsToClient ();
        }
    }

    public void ShowWhoreInfo () {
        whoreInfo = WhoreHolder.instance.whoreInfoHolder;
        WhoreHolder.instance.activeWhore = whoreGen;
        whoreInfo.text = "Name: " + whoreGen.whore.whoreName + "\n" + "Description: " + whoreGen.whore.whoreDesc + "\n" + "Fits to client: " + whoreGen.whore.fitsToClient;
        GameController.instance.confirmCancelButtons.SetActive (true);
    }

}
