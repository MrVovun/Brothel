using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class WhoreUIButton : MonoBehaviour {
    private Whore whoreGen;
    private string thisWhoreInfo;
    private bool isGenericInfo = false;

    private void Awake() {
        GetComponent<Button>().onClick.AddListener(delegate {
//            GameController.Instance.ShowInfo(thisWhoreInfo, isGenericInfo);
        });
    }

    public void FitsToClient() {
        GetComponentInChildren<TextMeshProUGUI>().text = GetComponentInChildren<TextMeshProUGUI>().text + "\nFits!";
    }

    public void AssignWhore(GameObject whorePrefab) {
        whoreGen = whorePrefab.GetComponent<Whore>();
//        whoreGen.thisWhoreButton = gameObject;
        GetComponent<Image>().sprite = whoreGen.Personality.whorePortrait;
        GetComponentInChildren<TextMeshProUGUI>().text = whoreGen.Personality.whoreName;
//        if (GameController.Instance.CompareClient().Contains(whoreGen.WhoreData) == true) {
//            FitsToClient();
//        }

        thisWhoreInfo = "Name: " + whoreGen.Personality.whoreName + "\n" + "Description: " + whoreGen.Personality.whoreDesc + "\n" +
                        "Fits to client: " + whoreGen.Personality.fitsToClient;
    }
}