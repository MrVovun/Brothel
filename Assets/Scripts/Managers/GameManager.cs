using UnityEngine;

public class GameManager : MonoBehaviourSingleton<GameManager> {

    public int money;
    public bool isPaused = false;
    private void Start () {
        DataFactory.Instance.GatherNames ();
    }
    void Update () {
        if (Input.GetKeyDown (KeyCode.Space)) {
            ClientManager.Instance.SpawnClient ();
        }
        if (Input.GetKeyDown (KeyCode.Q)) {
            TextManager.Instance.Say (null, "Do you suck dicks?", null, true, null);
        }
        if (Input.GetKeyDown (KeyCode.P)) {
            if (isPaused == true) {
                isPaused = false;
            } else {
                isPaused = true;
            }

        }
    }
}
