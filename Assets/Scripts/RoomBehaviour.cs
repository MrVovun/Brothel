using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RoomBehaviour : Interactable {
    #region Singleton

    public static RoomBehaviour instance;

    private void Awake () {
        if (instance != null) {
            Debug.LogWarning ("More than one instance found");
            return;
        }
        instance = this;
    }
    #endregion
    public GameObject entrance;

    public void SomeoneEnteredTheRoom (GameObject whore, GameObject client) {
        whore.GetComponent<WhoreGenerator> ().stamina -= client.GetComponent<ClientGenerator> ().staminaRequired;
        whore.SetActive (false);
        client.SetActive (false);
        //start coroutine, time is gathered from whore and calculated depending on stats
        whore.SetActive (true);
        client.SetActive (true);
        //whore goes to default position, client goes to cashbox, then leaves
    }
}
