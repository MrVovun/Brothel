using UnityEngine;

public class GameManager : MonoBehaviourSingleton<GameManager> {

    void Update () {
        if (Input.GetKeyDown (KeyCode.Space)) {
            ClientDataFactory.Instance.GatherNames ();
            ClientManager.Instance.SpawnClient ();
        }
    }
}
