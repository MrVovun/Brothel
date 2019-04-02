using UnityEngine;

public class GameManager : MonoBehaviourSingleton<GameManager> {

    public int money;

    void Update () {
        if (Input.GetKeyDown (KeyCode.Space)) {
            ClientDataFactory.Instance.GatherNames ();
            ClientManager.Instance.SpawnClient ();
        }
    }
}
