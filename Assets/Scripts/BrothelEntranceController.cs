using UnityEngine;

public class BrothelEntranceController : MonoBehaviour {
    #region Singleton

    public static BrothelEntranceController instance;

    private void Awake () {
        if (instance != null) {
            Debug.LogWarning ("More than one instance found");
            return;
        }
        instance = this;
    }
    #endregion
    public bool isOccupied = false;
    public ClientGenerator currentClient;

    private void Update () {
        if (isOccupied == true) {
            WhoreHolder.instance.SurroundClient (currentClient);
        }
    }
}
