using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class WhoreUIButton : MonoBehaviour {

    public void FitsToClient () {
        GetComponentInChildren<TextMeshProUGUI> ().text = GetComponentInChildren<TextMeshProUGUI> ().text + "\nFits!";
    }

    public void AssignWhore (GameObject whorePrefab) {
        WhoreGenerator whoreGen = whorePrefab.GetComponent<WhoreGenerator> ();
        whoreGen.thisWhoreButton = gameObject;
        GetComponent<Image> ().sprite = whoreGen.whore.whorePortrait;
        GetComponentInChildren<TextMeshProUGUI> ().text = whoreGen.whore.whoreName;
        if (GameController.instance.CompareClient ().Contains (whoreGen.whore) == true) {
            FitsToClient ();
        }
    }

    public void MoveClientToRoom () {
        //get whore assigned to this buttongg
        //get current client
        //unassign client from clientholder, make queue -1
        //make client follow whore
        //make whore move to room

    }
}
