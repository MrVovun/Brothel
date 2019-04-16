using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent (typeof (Walker))]
public class Whore : Interactable {
    [Space]
    public WhoreData Personality;
    public int stamina = 100;
    public int maxStamina = 100;
    public int staminaRaisePerLevel;
    public int level;
    public int clientLevelModifier = 2;
    public int fittingPreferencesForCurrentClient;
    public int fittingPreferencesOfCurrentClient;
    public int selfWill;
    public int compilance;
    public int standartStatCoeffecient = 10;
    public int stamiSpendPerFetish = 5;
    public List<string> whoreFetishes = new List<string> ();

    public float fetishChance = 0.5f;

    private bool isDoll = false;
    private int exp;
    private int level1Cap = 1000;
    private int level2Cap = 2500;
    private int level3Cap = 5000;

    private Vector3 returnPoint;
    private Walker walker;
    private Coroutine handlingClientProcess;
    private bool isBusy;

    private void OnEnable () {
        walker = GetComponent<Walker> ();
        returnPoint = transform.position;
    }

    private void Update () {

    }

    public void MeetNewClient (Client client) {
        fittingPreferencesForCurrentClient = 0;
        fittingPreferencesOfCurrentClient = 0;
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
            int reqStamina;

            int staminaOnSexStart = stamina;
            Walker walker = GetComponent<Walker> ();
            walker.GoToPoint (room.GetBedPostition ());
            room.Occupy (this, client);

            client.DoWhore (this);

            yield return new WaitUntil (() => walker.HasArrived ());
            Debug.Log ("Hello Darling! (couple arrived to room)");
            yield return new WaitForSeconds (client.reqTime);
            if (stamina >= maxStamina / 2) {
                reqStamina = (client.reqTime * (client.level / level) + stamiSpendPerFetish);
            } else if (stamina < maxStamina / 2) {
                reqStamina = (client.reqTime * (client.level / level) / (staminaOnSexStart / 50) + stamiSpendPerFetish);
            } else {
                reqStamina = 0;
                //interrupt sex and send whore to sleep
            }
            for (int i = 0; i < fittingPreferencesOfCurrentClient; i++) {
                reqStamina = reqStamina / 2;
            }
            for (int i = 0; i < reqStamina; i++) {
                stamina -= 1;
            }
            //sex interruption on click
            client.Handled (this);
            Handled (client);
            room.Unoccupy ();
        } else {
            Debug.LogWarning ("There is no free room!");
        }
    }

    public void Handled (Client client) {
        isBusy = false;
        if (isDoll == false) {
            if (level == client.level) {
                exp += client.expForMe;
            } else {
                exp += client.expForMe / clientLevelModifier;
            }
        } else {
            Debug.Log ("Dolls don't gather exp");
        }
        if (level == 1 && exp >= level1Cap) {
            level = 2;
            maxStamina += staminaRaisePerLevel;
            GetFetish ();
        }
        if (level == 2 && exp >= level2Cap) {
            level = 3;
            maxStamina += staminaRaisePerLevel;
            GetFetish ();
        }
        if (level == 3 && exp >= level3Cap) {
            level = 4;
            maxStamina += staminaRaisePerLevel;
            GetFetish ();
        }

        GoBack ();
        handlingClientProcess = null;
    }

    public void GoBack () {
        walker.GoToPoint (returnPoint);
    }

    public void GetFetish () {
        if (Random.value >= fetishChance) {
            whoreFetishes.Add (DataFactory.Instance.fetishes[Random.Range (0, DataFactory.Instance.fetishes.Count)]);
        }
    }

    public void Rest () {
        //we send whore to rest and regen stamina
        //we regen slower, if her stamina is <= 0
    }

    public void RaiseStat (string stat) {
        if (stat == "compilance") {
            compilance += standartStatCoeffecient * fittingPreferencesForCurrentClient;
            Debug.Log ("Whore's compliance = " + compilance);
            if (compilance >= 100) {
                isDoll = true;
                Personality = WhoreManager.Instance.dollTemplate;
                stamina = 0;
                maxStamina = 100;
                exp = 0;
                level = 1;
                //start notification that says that she became a doll
                //she shouldn't get any text segments
                //she shouldn't get any room bonuses
                //she couldn't use any special rooms to raise her skills
            }
        } else if (stat == "selfWill") {
            selfWill += standartStatCoeffecient * fittingPreferencesOfCurrentClient;
            Debug.Log ("Whore's self-will = " + selfWill);
            if (selfWill >= 100) {
                //start text segment with girl leaving the brothel
                //maybe add her to some kind of memorial
                //mark her whoredata so that she wouldn't generate on that playthrough
                Destroy (this.gameObject);
            }
        } else {
            Debug.Log ("Wrong stat!");
        }
    }
}
