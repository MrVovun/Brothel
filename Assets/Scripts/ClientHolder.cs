using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ClientHolder : MonoBehaviourSingleton<ClientHolder> {


    [SerializeField]
    private GameObject defaultClient;
    public GameObject clientClone;
    public int clientQueue = 0;

    public void Spawn () {
        clientClone = Instantiate (defaultClient, transform.position, transform.rotation);
        clientClone.GetComponent<ClientGenerator> ().GenerateClient ();
        clientQueue += 1;
    }
}
