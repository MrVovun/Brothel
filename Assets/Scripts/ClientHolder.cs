using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ClientHolder : MonoBehaviour {

    #region Singleton

    public static ClientHolder instance;

    private void Awake () {
        if (instance != null) {
            Debug.LogWarning ("More than one instance found");
            return;
        }
        instance = this;
    }
    #endregion

    [SerializeField]
    private GameObject defaultClient;
    public GameObject clientClone;

    public void Spawn () {
        clientClone = Instantiate (defaultClient, transform.position, transform.rotation);
        clientClone.GetComponent<ClientGenerator> ().GenerateClient ();
    }

    public void MoveClient (Vector3 point) {
        clientClone.GetComponent<CharacterMover> ().MoveToPoint (point);
    }

}
