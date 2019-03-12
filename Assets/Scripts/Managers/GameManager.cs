using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviourSingleton<GameManager> {

    
    
    void Update() {
        if (Input.GetKeyDown(KeyCode.Space)) {
            ClientManager.Instance.SpawnClient();
        }
    }

//
//    void SpawnClient() {
//        ClientHolder.Instance.Spawn();
//    }
//
//    public List<WhoreData> CompareClient() {
//        int clientNum = ClientHolder.Instance.clientClone.GetComponent<Client>().ClientData.fitsToWhore;
//        List<WhoreData> fittingWhores = new List<WhoreData>();
//        for (int i = 0; i < WhoreHolder.instance.listOfWhores.Count; i++) {
//            if (clientNum == WhoreHolder.instance.listOfWhores[i].GetComponent<Whore>().WhoreData.fitsToClient) {
//                fittingWhores.Add(WhoreHolder.instance.listOfWhores[i].GetComponent<Whore>().WhoreData);
//            }
//        }
//
//        return fittingWhores;
//    }
//
//    public void CancelButton() {
//        confirmCancelButtons.SetActive(false);
//        infoHolder.text = null;
//        WhoreHolder.instance.activeWhore = null;
//    }
//
//    public void ConfirmButton() {
////        WhoreHolder.instance.activeWhore.MoveClientToRoom(ClientHolder.Instance.clientClone);
//    }
//
//    public void ShowInfo(string info, bool genericInfo) {
//        infoHolder.text = info;
//        if (genericInfo == false) {
//            confirmCancelButtons.SetActive(true);
//        }
//    }
}