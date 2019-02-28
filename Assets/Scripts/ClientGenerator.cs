using UnityEngine;

public class ClientGenerator : Interactable {

    public Client client;

    public void GenerateClient () {
        client = Resources.Load ("ScriptableObjects/Client") as Client;
    }

}
