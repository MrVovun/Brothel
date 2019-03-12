using UnityEngine;

public class Interactable : MonoBehaviour {
    public float radius = 3f;
    public string myInfo;
    public bool isGenericInfo = false;

    public virtual void Interact () {
        Debug.Log ("Interacted with + " + transform.name);
    }
    private void Start () {
        //depending on the interactible type (room, whore, client), get and assign myInfo
    }
}
