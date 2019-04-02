using System.Collections;
using UnityEngine;

[RequireComponent (typeof (Walker))]
public class Whore : Interactable {
    [Space]
    public WhoreData Personality;
    public int stamina = 100;
    public int level;
    public int clientLevelModifier = 2;
    public int fittingPreferencesForCurrentClient;
    private int exp;
    private int level1Cap;
    private int level2Cap;
    private int level3Cap;

    private Vector3 returnPoint;
    private Walker walker;
    private Coroutine handlingClientProcess;
    private bool isBusy;

    private void OnEnable () {
        walker = GetComponent<Walker> ();
        returnPoint = transform.position;
    }

    private void Update () {
        if (level == 1 && exp >= level1Cap) {
            level = 2;
            //chance to get random fetish
        }
        if (level == 2 && exp >= level2Cap) {
            level = 3;
            //chance to get random fetish
        }
        if (level == 3 && exp >= level3Cap) {
            level = 4;
            //chance to get random fetish
        }
    }

    public void MeetNewClient (Client client) {
        fittingPreferencesForCurrentClient = 0;
        GetComponent<Walker> ().WalkToTarget (client);
    }

    public bool IsBusy () {
        return isBusy;
    }

    public void HandleClient (Client client) {
        handlingClientProcess = StartCoroutine (handlingClient (client));
    }

    private IEnumerator handlingClient (Client client) {
        isBusy = true;

        Room room = RoomManager.Instance.FindRoom ();
        if (room) {
            Walker walker = GetComponent<Walker> ();
            walker.GoToPoint (room.GetBedPostition ());
            room.Occupy (this, client);

            client.DoWhore (this);

            yield return new WaitUntil (() => walker.HasArrived ());
            Debug.Log ("Hello Darling! (couple arrived to room)");
            yield return new WaitForSeconds (30);
            //sex interruption here
            client.Handled (this);
            Handled (client);
            room.Unoccupy ();
        } else {
            Debug.LogWarning ("There is no free room!");
        }
    }

    public void Handled (Client client) {
        isBusy = false;
        if (level == client.level) {
            exp += client.expForMe;
        } else {
            exp += client.expForMe / clientLevelModifier;
        }
        GoBack ();
        handlingClientProcess = null;
    }

    public void GoBack () {
        walker.GoToPoint (returnPoint);
    }
}
