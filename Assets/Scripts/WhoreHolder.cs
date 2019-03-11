using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class WhoreHolder : MonoBehaviour {

    #region Singleton

    public static WhoreHolder instance;

    private void Awake () {
        if (instance != null) {
            Debug.LogWarning ("More than one instance found");
            return;
        }
        instance = this;
    }
    #endregion
    [SerializeField]
    GameObject whereToSpawnButtons;
    [SerializeField]
    GameObject buttonPrefab;
    public WhoreGenerator activeWhore;

    public List<GameObject> listOfWhores = new List<GameObject> ();
    public TextMeshProUGUI whoreInfoHolder;

    private void Start () {
        listOfWhores.AddRange (GameObject.FindGameObjectsWithTag ("Whore"));
    }

    public void SurroundClient (ClientGenerator clientToSurround) {
        StartCoroutine (MeetTheClient (clientToSurround));
    }
    IEnumerator MeetTheClient (ClientGenerator clientToSurround) {
        foreach (GameObject whore in listOfWhores) {
            WhoreGenerator whoreGen = whore.GetComponent<WhoreGenerator> ();
            if (whoreGen.isOccupied == false) {
                whore.GetComponent<CharacterMover> ().MoveToTarget (clientToSurround);
                if (whoreGen.thisWhoreButton == null) {
                    GameObject buttonToSpawn = Instantiate (buttonPrefab, transform.position, transform.rotation);
                    buttonToSpawn.transform.SetParent (whereToSpawnButtons.transform);
                    buttonToSpawn.GetComponent<WhoreUIButton> ().AssignWhore (whore);
                    yield return null;
                } else if (whoreGen.thisWhoreButton != null) {
                    whoreGen.thisWhoreButton.SetActive (true);
                    yield return null;
                }
                yield return null;
            }
        }

    }
}
