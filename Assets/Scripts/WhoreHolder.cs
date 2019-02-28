using System.Collections;
using System.Collections.Generic;
using UnityEngine;

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

    public List<Whore> listOfWhores = new List<Whore> ();

    private void Start () {
        foreach (GameObject whoreObj in GameObject.FindGameObjectsWithTag ("Whore")) {

            listOfWhores.Add (whoreObj.GetComponent<WhoreGenerator> ().whore);
        }
    }

    public void AddWhore (Whore incomingWhore) {
        listOfWhores.Add (incomingWhore);
    }
    public void RemoveWhore (Whore incomingWhore) {
        listOfWhores.Remove (incomingWhore);
    }
}
