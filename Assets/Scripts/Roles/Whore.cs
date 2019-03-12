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
        returnPoint = transform.position;
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
        
        Room room = RoomManager.Instance.FindRoom();
        if (room) {
            Walker walker = GetComponent<Walker>();
            walker.GoToPoint(room.GetBedPostition());
            room.Occupy(this, client);
            
            client.DoWhore(this);
            
            yield return new WaitUntil(() => walker.HasArrived());
            Debug.Log("Hello Darling! (couple arrived to room)");
            yield return new WaitForSeconds(30);
            client.Handled(this);
            Handled(client);  
        } else {
            Debug.LogWarning("There is no free room!");
        }
    }

    public void Handled(Client client) {
        isBusy = false;
        GoBack();
        handlingClientProcess = null;
    }

    public void GoBack() {
        walker.GoToPoint(returnPoint);
    }
}