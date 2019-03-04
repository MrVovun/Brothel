using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class WhoreUIButton : MonoBehaviour {
    void Awake () {
        foreach (GameObject whore in GameController.instance.whoresOnTheField) {
            WhoreGenerator whorePrefab = whore.GetComponent<WhoreGenerator> ();
            if (whorePrefab.thisWhoreButton == null) {
                whorePrefab.thisWhoreButton = gameObject;
                GetComponent<Image> ().sprite = whorePrefab.whore.whorePortrait;
                GetComponentInChildren<TextMeshProUGUI> ().text = whorePrefab.whore.whoreName;
                GetComponent<Button> ().onClick.AddListener (whorePrefab.MoveWhoreToClient);
                if (GameController.instance.CompareClient ().Contains (whorePrefab.whore) == true) {
                    FitsToClient ();
                }
                break;
            }
        }
    }
    public void FitsToClient () {
        GetComponentInChildren<TextMeshProUGUI> ().text = GetComponentInChildren<TextMeshProUGUI> ().text + "\nFits!";
    }

    public void FollowClient () {

    }
}
