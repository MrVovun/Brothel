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

    [SerializeField]
    private Canvas canvas;

    private void Start () {
        myText = textHolder.GetComponentInChildren<TextMeshProUGUI> ();
    }

    public void Say (GameObject speaker, string message, Sprite speakerSprite, bool isClient, System.Action nextAction) {
        GameManager.Instance.isPaused = true;
        if (isClient == true) {
            speakerSprite = currentRightPic;
        } else {
            speakerSprite = currentLeftPic;
        }
        fullString = message;
        textHolder.SetActive (true);
        StartCoroutine (ShowText (nextAction));
    }

    public void BubbleSpeech (GameObject speaker, string message) {

    }

    IEnumerator ShowText (System.Action nextAction) {
        if (nextAction == null) {
            //nextAction = StopSpeaking ();
        }
        myText.text = string.Empty;
        foreach (char c in fullString) {
            if (Input.GetKeyDown (KeyCode.Mouse0)) {
                myText.text = fullString;
                yield break;
            }
            myText.text += c;
            yield return new WaitForSeconds (charTime);
        }
        if (Input.GetKeyDown (KeyCode.Mouse0) && myText.text == fullString) {
            nextAction.Invoke ();
        }
        //if right click is pressed and previous action is text
        //return to previous action
    }

    public void StopSpeaking () {
        textHolder.SetActive (false);
        myText.text = string.Empty;
        GameManager.Instance.isPaused = false;
    }
}
