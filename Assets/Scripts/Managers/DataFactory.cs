using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DataFactory : MonoBehaviourSingleton<DataFactory> {

    public List<string> names = new List<string> ();
    public List<string> preferences = new List<string> ();
    public List<string> traits = new List<string> ();
    public List<string> fetishes = new List<string> ();

    public float firstPrefChance = 0.5f;
    public float secondPrefChance = 0.33f;
    public float thirdPrefChance = 0.25f;
    public float additionalTraitChance = 0.5f;

    public void GatherNames () {
        //names should be gathered from some kind of library
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
        fetishes.Add ("BDSM");
        fetishes.Add ("oral");
        fetishes.Add ("anal");
        fetishes.Add ("paizuri");
        fetishes.Add ("foot");
    }

    public void GenerateClientData (ClientData client) {
        client.clientName = names[Random.Range (0, names.Count)];
        //check if this name is already occupied by saved client
        client.clientPreferences.Add (preferences[Random.Range (0, preferences.Count)]);
        // if (Random.value >= firstPrefChance) {
        //     client.clientPreferences.Add (preferences[Random.Range (0, preferences.Count)]);
        //     if (Random.value >= secondPrefChance) {
        //         client.clientPreferences.Add (preferences[Random.Range (0, preferences.Count)]);
        //         //check if client already has that pref
        //         if (Random.value >= thirdPrefChance) {
        //             client.clientPreferences.Add (preferences[Random.Range (0, preferences.Count)]);
        //             //check if client already has that pref
        //         }
        //     }
        // }
        client.clientTraits.Add (traits[Random.Range (0, traits.Count)]);
        if (Random.value >= additionalTraitChance) {
            client.clientTraits.Add (traits[Random.Range (0, traits.Count)]);
            //check if client already has that trait
        }
    }

}
