using System.Collections.Generic;
using UnityEngine;

public class WhoreManager : MonoBehaviour {
    public Whore[] Whores;

    public void MeetClient(Client client) {
        foreach (Whore whore in Whores) {
            if (!whore.IsBusy()) {
                whore.MeetNewClient(client);
            }
        }
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
}
