using NaughtyAttributes;
using UnityEngine;

public class Interactable : MonoBehaviour {
    public float radius = 3f;
    public string myInfo;

    public virtual void Interact () {
        Debug.Log ("Interacted with + " + transform.name);
        GetMyInfo ();
        ObjectInformationUI.Instance.ShowCurrentInfo (myInfo);
    }

    private void GetMyInfo () {
        if (gameObject.GetComponent<Whore> () != null) {
            Whore thisObject = gameObject.GetComponent<Whore> ();
            myInfo = "Name: " + thisObject.Personality.whoreName + "\n" + "Description: " + thisObject.Personality.whoreDesc + "\n" + "Fits to client: " + thisObject.Personality.fitsToClient;
        } else if (gameObject.GetComponent<Client> () != null) {
            Client thisObject = gameObject.GetComponent<Client> ();
            myInfo = "Name: " + thisObject.Personality.clientName + "\n" + "Fits to whore: " + thisObject.Personality.fitsToWhore;
        } else if (gameObject.GetComponent<Room> () != null) {
            Room thisObject = gameObject.GetComponent<Room> ();
            myInfo = "Name: " + this.name + "\n" + "Room is occupied: " + thisObject.isOccupied;
        }
    }
}
