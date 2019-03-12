using UnityEngine;
using NaughtyAttributes;

public class CameraController : MonoBehaviourSingleton<CameraController> {
    public float CamSpeed = 20f;
    public float EdgeThickness = 2f;
    public float SmoothTime = 0.2f;

    [Space]
    [InfoBox("If X=5, then camera can move between -5 and 5. Same for Y")]
    public Vector2 CameraBoundaries;
    
    private Camera cam;
    private Vector3 targetPosition;
    private Vector3 currentVelocity;
    
    void Start() {
        cam = Camera.main;
    }

    public void Focus(Transform target) {
        targetPosition = clampIntoBoundaries(target.position);
    }

    private void LateUpdate() {
        handleInput();
        handleMovement();
        if (Input.GetMouseButtonDown(0)) {
            handleInteration();
        }
    }
    
    private void handleInteration() {
        Ray ray = cam.ScreenPointToRay(Input.mousePosition);
        RaycastHit hit;

        if (Physics.Raycast(ray, out hit, 100)) {
            Interactable interactable = hit.collider.GetComponent<Interactable>();
            if (interactable != null) {
                CameraController.Instance.Focus(interactable.transform);
                interactable.Interact();
            }
        }
    }

    private void handleInput() {
        Vector3 newPos = targetPosition;
        if (Input.mousePosition.y >= Screen.height - EdgeThickness) {
            newPos.z += CamSpeed * Time.deltaTime;
        }

        if (Input.mousePosition.y <= EdgeThickness) {
            newPos.z -= CamSpeed * Time.deltaTime;
        }

        if (Input.mousePosition.x >= Screen.width - EdgeThickness) {
            newPos.x += CamSpeed * Time.deltaTime;
        }

        if (Input.mousePosition.x <= EdgeThickness) {
            newPos.x -= CamSpeed * Time.deltaTime;
        }

        targetPosition = clampIntoBoundaries(newPos);
    }

    private void handleMovement() {
        transform.position = Vector3.SmoothDamp(transform.position, targetPosition, ref currentVelocity, SmoothTime);
    }
    
    private Vector3 clampIntoBoundaries(Vector3 pos) {
        return new Vector3(
            Mathf.Clamp(pos.x, -CameraBoundaries.x, CameraBoundaries.x),
            pos.y,
            Mathf.Clamp(pos.z, -CameraBoundaries.y, CameraBoundaries.y)
        );
    }
}