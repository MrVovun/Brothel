using System.Collections;
using UnityEngine;

[RequireComponent(typeof(Walker))]
public class Whore : Interactable {
    [Space]
    public WhoreData Personality;
    public int stamina = 100;

    private Vector3 returnPoint;
    private Walker walker;
    private Coroutine handlingClientProcess;
    private bool isBusy;

    private void OnEnable() {
        walker = GetComponent<Walker>();
    }

    public void MeetNewClient(Client client) {
        GetComponent<Walker>().WalkToTarget(client);
    }

    public bool IsBusy() {
        return isBusy;
    }

    public void HandleClient(Client client) {
        handlingClientProcess = StartCoroutine(handlingClient(client));
    }

    private IEnumerator handlingClient(Client client) {
        isBusy = true;
        returnPoint = transform.position;
//        client.BeHandledBy(this);
        
        Room room = RoomManager.Instance.FindRoom();
        Walker walker = GetComponent<Walker>();
        walker.GoToPoint(room.GetBedPostition());
        
        yield return new WaitUntil(() => walker.HasArrived());
        Debug.Log("Hello Darling! (couple arrived to room)");
        yield return new WaitForSeconds(30);
        client.Handled(this);
        Handled(client);
    }

    public void Handled(Client client) {
        isBusy = false;
        walker.GoToPoint(returnPoint);
        handlingClientProcess = null;
    }
}