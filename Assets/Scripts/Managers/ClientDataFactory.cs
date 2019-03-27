using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ClientDataFactory : MonoBehaviourSingleton<ClientDataFactory> {

    public List<string> names = new List<string> ();
    public List<string> preferences = new List<string> ();
    public List<string> traits = new List<string> ();

    public void GatherNames () {
        names.Add ("John");
        names.Add ("Jack");
        names.Add ("James");
        preferences.Add ("classic");
        preferences.Add ("asian");
        preferences.Add ("black");
        preferences.Add ("redhead");
        preferences.Add ("slim");
        preferences.Add ("meaty");
        preferences.Add ("muscular");
        traits.Add ("young");
        traits.Add ("old");
        traits.Add ("virgin");
    }

    public void GenerateClientData (ClientData client) {
        client.clientName = names[Random.Range (0, names.Count)];
        //check if this name is already occupied by saved client
        if (Random.value >= 0.5) {
            client.preferences.Add (preferences[Random.Range (0, preferences.Count)]);
            if (Random.value >= 0.5) {
                client.preferences.Add (preferences[Random.Range (0, preferences.Count)]);
                //check if client already has that pref
                if (Random.value >= 0.5) {
                    client.preferences.Add (preferences[Random.Range (0, preferences.Count)]);
                    //check if client already has that pref
                }
            }
        }
        client.traits.Add (traits[Random.Range (0, traits.Count)]);
    }

}
