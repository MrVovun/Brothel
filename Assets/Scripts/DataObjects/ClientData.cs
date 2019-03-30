using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu (fileName = "Client", menuName = "Brothel/Client")]
public class ClientData : ScriptableObject {
    public Sprite portrait;
    public string clientName;
    public int fitsToWhore;
    public List<string> clientPreferences = new List<string> ();
    public List<string> clientTraits = new List<string> ();

}
