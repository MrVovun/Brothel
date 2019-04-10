using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

[System.Serializable]
public class ClientEvent : UnityEvent<Client> { }

public class ClientManager : MonoBehaviourSingleton<ClientManager> {

    [Header ("Spawn")]
    public Transform SpawnPoint;
    public Transform InitialWalkDestination;
    public Client Prefab;

    [Header ("Current Clients")]
    public List<Client> Clients;

    public ClientEvent ClientArrived;

    public Client[] GetIdleClients () {
        List<Client> clients = new List<Client> ();
        foreach (Client client in Clients) {
            if (!client.IsBusy ()) {
                clients.Add (client);
            }
        }
        return clients.ToArray ();
    }

    public Client SpawnClient () {
        Client client = Instantiate (Prefab, SpawnPoint.position, SpawnPoint.rotation);
        Clients.Add (client);
        Walker walker = client.GetComponent<Walker> ();
        walker.GoToPoint (InitialWalkDestination.position);
        walker.OnArrive (delegate {
            ClientArrived.Invoke (client);
        });
        return client;
    }

    public List<Whore> FindWhoresThatPreferMe (Client client, Whore[] whores) {
        List<Whore> whoresThatPrefers = new List<Whore> ();
        foreach (Whore whore in whores) {
            int fittingPrefs = 0;
            for (int i = 0; i < whore.Personality.whorePreferences.Count; i++) {
                if (!whore.IsBusy () && client.Personality.clientTraits.Contains (whore.Personality.whorePreferences[i])) {
                    fittingPrefs += 1;
                    whoresThatPrefers.Add (whore);
                }
            }
            whore.fittingPreferencesOfCurrentClient = fittingPrefs;
        }
        return whoresThatPrefers;
    }
}
