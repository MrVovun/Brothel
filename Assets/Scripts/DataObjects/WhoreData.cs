using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[CreateAssetMenu (fileName = "Whore", menuName = "Brothel/Whore")]
public class WhoreData : ScriptableObject {
    public Sprite whorePortrait;
    public string whoreName;
    public string whoreDesc;
    public List<string> whorePreferences = new List<string> ();
    public List<string> whoreTraits = new List<string> ();
}
