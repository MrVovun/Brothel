using UnityEngine;

public class GameManager : MonoBehaviourSingleton<GameManager> {

    public int money;
    private void Start () {
        DataFactory.Instance.GatherNames ();
    }
    void Update () {
        if (Input.GetKeyDown (KeyCode.Space)) {
            ClientManager.Instance.SpawnClient ();
        }
    }
}
