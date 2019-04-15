using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WhoreManager : MonoBehaviourSingleton<WhoreManager> {
    List<Whore> Whores = new List<Whore> ();

    public WhoreSelectionUI SelectionUI;
    public int maximumWhoreListSize = 3;

    public void MeetClient (Client client) {
        Whore[] freeWhores = GetUnoccupiedWhores ();
        foreach (Whore whore in freeWhores) {
            whore.MeetNewClient (client);
        }

        Walker.OnAllArrive (freeWhores, delegate {
            SelectionUI.ShowSelectionUI (client, freeWhores);
        });
    }

    public Whore[] GetUnoccupiedWhores () {
        List<Whore> freeWhores = new List<Whore> ();
        foreach (Whore whore in Whores) {
            if (!whore.IsBusy ()) {
                freeWhores.Add (whore);
            }
        }

        return freeWhores.ToArray ();
    }

    public List<Whore> FindWhoresThatFit (Client client) {
        List<Whore> whoresThatFits = new List<Whore> ();
        foreach (Whore whore in Whores) {
            int fittingTraits = 0;
            for (int i = 0; i < whore.Personality.whoreTraits.Count; i++) {
                if (!whore.IsBusy () && client.Personality.clientPreferences.Contains (whore.Personality.whoreTraits[i])) {
                    fittingTraits += 1;
                    whoresThatFits.Add (whore);
                }
            }
            whore.fittingPreferencesForCurrentClient = fittingTraits;
        }
        return whoresThatFits;
    }

    public void OnWhoreConfirmed (Whore whore, Client client) {
        whore.HandleClient (client);
        foreach (Whore w in GetUnoccupiedWhores ()) {
            w.GoBack ();
        }
    }

    public void AddNewWhore (Whore whore) {
        if (Whores.Count < maximumWhoreListSize) {
            Whores.Add (whore);
        } else {
            Debug.Log ("Not enough space for whores");
            //probably write to player that he doesn't have enough space
            //save this whore somewhere to call her later?
        }

    }
}
