using UnityEngine;

[CreateAssetMenu(fileName = "Client", menuName = "Brothel/Client")]
public class Client : ScriptableObject {
    public Sprite portrait;
    public string clientName;
    public int fitsToWhore;
}