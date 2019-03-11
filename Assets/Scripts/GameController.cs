using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameController : MonoBehaviour {

    #region Singleton

    public static GameController instance;

    private void Awake () {
        if (instance != null) {
            Debug.LogWarning ("More than one instance found");
            return;
        }
        instance = this;
    }
    #endregion

    Camera cam;
    public GameObject confirmCancelButtons;

    void Start () {
        cam = Camera.main;
        confirmCancelButtons.SetActive (false);
    }

    void Update () {
        if (Input.GetMouseButtonDown (0)) {
            Interact ();
        }
        if (Input.GetKeyDown (KeyCode.Space)) {
            SpawnClient ();
        }
    }

    void Interact () {
        Ray ray = cam.ScreenPointToRay (Input.mousePosition);
        RaycastHit hit;

        if (Physics.Raycast (ray, out hit, 100)) {
            Interactable interactable = hit.collider.GetComponent<Interactable> ();
            if (interactable != null) {
                cam.GetComponent<CameraController> ().Focus (interactable.transform);
            }
        }
    }
    void SpawnClient () {
        ClientHolder.instance.Spawn ();
    }
    public List<Whore> CompareClient () {
        int clientNum = ClientHolder.instance.clientClone.GetComponent<ClientGenerator> ().client.fitsToWhore;
        List<Whore> fittingWhores = new List<Whore> ();
        for (int i = 0; i < WhoreHolder.instance.listOfWhores.Count; i++) {
            if (clientNum == WhoreHolder.instance.listOfWhores[i].GetComponent<WhoreGenerator> ().whore.fitsToClient) {
                fittingWhores.Add (WhoreHolder.instance.listOfWhores[i].GetComponent<WhoreGenerator> ().whore);
            }
        }
        return fittingWhores;
    }

    public void CancelButton () {
        confirmCancelButtons.SetActive (false);
        WhoreHolder.instance.whoreInfoHolder.text = null;
        WhoreHolder.instance.activeWhore = null;
    }
    public void ConfirmButton () {
        WhoreHolder.instance.activeWhore.MoveClientToRoom (ClientHolder.instance.clientClone);
    }
}
