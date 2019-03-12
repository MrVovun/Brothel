using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WhoreManager : MonoBehaviourSingleton<WhoreManager> {
    public Whore[] Whores;

    public WhoreSelectionUI SelectionUI;

    public void MeetClient(Client client) {
        Whore[] freeWhores = GetUnoccupiedWhores();
        foreach (Whore whore in freeWhores) {
            whore.MeetNewClient(client);
        }
        
        Walker.OnAllArrive(freeWhores, delegate {
            SelectionUI.ShowSelectionUI(client, freeWhores);
        });
    }

    public Whore[] GetUnoccupiedWhores() {
        List<Whore> freeWhores = new List<Whore>();
        foreach (Whore whore in Whores) {
            if (!whore.IsBusy()) {
                freeWhores.Add(whore);
            }
        }

        return freeWhores.ToArray();
    }

    public Whore[] FindWhoreThatFits(Client client) {
        List<Whore> whoresThatFits = new List<Whore>();
        foreach (Whore whore in Whores) {
            if (!whore.IsBusy() && whore.Personality.fitsToClient == client.Personality.fitsToWhore) {
                whoresThatFits.Add(whore);
            }
        }

        return whoresThatFits.ToArray();
    }

    public void OnWhoreConfirmed(Whore whore, Client client) {
        whore.HandleClient(client);
        foreach (Whore w in GetUnoccupiedWhores()) {
            w.GoBack();
        }
    }
}