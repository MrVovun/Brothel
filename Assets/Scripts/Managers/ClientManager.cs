using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

[System.Serializable]
public class ClientEvent : UnityEvent<Client> {
}

public class ClientManager : MonoBehaviourSingleton<ClientManager> {
    
    [Header("Spawn")]
    public Transform SpawnPoint;
    public Transform InitialWalkDestination;
    public Client Prefab;

    [Header("Current Clients")]
    public List<Client> Clients;

    public ClientEvent ClientArrived; 

    public Client[] GetIdleClients() {
        List<Client> clients = new List<Client>();
        foreach (Client client in Clients) {
            if (!client.IsBusy()) {
                clients.Add(client);
            }
        }
        return clients.ToArray();
    }
    
    public Client SpawnClient() {
        Client client = Instantiate(Prefab, SpawnPoint.position, SpawnPoint.rotation);
        Clients.Add(client);
        StartCoroutine(animateClientArriving(client));
        return client;
    }

    private IEnumerator animateClientArriving(Client client) {
        Walker walker = client.GetComponent<Walker>();
        walker.GoToPoint(InitialWalkDestination.position);
        yield return new WaitUntil(delegate { return walker.HasArrived(); });
        ClientArrived.Invoke(client);
    }
    
}
