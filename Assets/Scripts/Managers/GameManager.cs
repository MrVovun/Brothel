using UnityEngine;

public class GameManager : MonoBehaviourSingleton<GameManager> {
    
    void Update() {
        if (Input.GetKeyDown(KeyCode.Space)) {
            ClientManager.Instance.SpawnClient();
        }
    }
}