using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

public class ObjectInformationUI : MonoBehaviourSingleton<ObjectInformationUI> {

    public void ShowCurrentInfo (string info) {
        GetComponent<TextMeshProUGUI> ().text = info;
    }

    public void ClearInfo () {
        GetComponent<TextMeshProUGUI> ().text = null;
    }

}
