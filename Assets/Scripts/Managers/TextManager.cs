using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

public class TextManager : MonoBehaviourSingleton<TextManager> {

    private string fullString;
    private TextMeshProUGUI myText;
    private Sprite currentLeftPic;
    private Sprite currentRightPic;

    [SerializeField]
    private float charTime = 0.1f;

    [SerializeField]
    private GameObject textHolder;

    private void Start () {
        myText = textHolder.GetComponentInChildren<TextMeshProUGUI> ();
    }

    public void Say (string message, Sprite speakerSprite, bool isClient) {
        if (isClient == true) {
            speakerSprite = currentRightPic;
        } else {
            speakerSprite = currentLeftPic;
        }
        fullString = message;
        textHolder.SetActive (true);
        StartCoroutine (ShowText ());
    }

    IEnumerator ShowText () {
        myText.text = string.Empty;
        foreach (char c in fullString) {
            if (Input.GetKeyDown (KeyCode.Mouse0)) {
                myText.text = fullString;
                yield break;
            }
            myText.text += c;
            yield return new WaitForSeconds (charTime);
        }
    }

    public void StopSpeaking () {
        textHolder.SetActive (false);
        myText.text = string.Empty;
    }

    //scroll back/forth the text
    //pause the game
}
