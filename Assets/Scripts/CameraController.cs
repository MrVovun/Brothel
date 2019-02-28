using UnityEngine;

public class CameraController : MonoBehaviour {
    public Vector3 offset;
    public float pitch = 2f;
    public float camSpeed = 20f;
    public float edgeThickness = 2f;

    public void Focus (Transform target) {
        transform.position = target.position - offset;
        Debug.Log ("Camera focused on: " + target);
    }
    private void Update () {
        Vector3 pos = transform.position;
        if (Input.mousePosition.y >= Screen.height - edgeThickness) {
            pos.z += camSpeed * Time.deltaTime;
        }
        if (Input.mousePosition.y <= edgeThickness) {
            pos.z -= camSpeed * Time.deltaTime;
        }
        if (Input.mousePosition.x >= Screen.width - edgeThickness) {
            pos.x += camSpeed * Time.deltaTime;
        }
        if (Input.mousePosition.x <= edgeThickness) {
            pos.x -= camSpeed * Time.deltaTime;
        }
        transform.position = pos;
    }
}
