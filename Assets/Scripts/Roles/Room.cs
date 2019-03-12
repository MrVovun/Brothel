using UnityEngine;

public class Room : MonoBehaviour {
    public Transform Bed;
    
    private bool isOccupied;

    public Vector3 GetBedPostition() {
        return Bed.position;
    }

    public void Occupy(Whore whore, Client client) {
        isOccupied = true;
    }

    public bool IsOccupied() {
        return isOccupied;
    }
}
