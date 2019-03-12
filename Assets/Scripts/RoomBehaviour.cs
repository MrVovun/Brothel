using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RoomBehaviour : Interactable {
    #region Singleton

    public static RoomBehaviour Instance;

    private void Awake() {
        if (Instance != null) {
            Debug.LogWarning("More than one instance found");
            return;
        }

        Instance = this;
    }

    #endregion

    public GameObject entrance;

    public void SomeoneEnteredTheRoom(GameObject whore, GameObject client) {
        whore.GetComponent<WhoreGenerator>().stamina -= client.GetComponent<ClientGenerator>().staminaRequired;
        whore.SetActive(false);
        client.SetActive(false);
        //start coroutine, time is gathered from whore and calculated depending on stats
        whore.SetActive(true);
        client.SetActive(true);
        //whore goes to default position, client goes to cashbox, then leaves
    }
}