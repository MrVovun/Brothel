using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
[RequireComponent (typeof (NavMeshAgent))]
public class CharacterMover : MonoBehaviour {

    Transform target;
    NavMeshAgent agent;

    void Start () {
        agent = GetComponent<NavMeshAgent> ();
    }
    private void Update () {
        if (target != null) {
            FaceTarget ();
        }
    }

    public void MoveToPoint (Vector3 point) {
        agent.SetDestination (point);
    }

    public void MoveToTarget (Interactable newTarget) {
        agent.stoppingDistance = newTarget.radius;
        agent.SetDestination (newTarget.transform.position);
    }
    public void FollowTarget (Interactable newTarget) {
        agent.stoppingDistance = newTarget.radius;
        target = newTarget.transform;
    }
    public void StopFollowing () {
        agent.stoppingDistance = 0f;
        agent.updateRotation = true;
        target = null;
    }
    void FaceTarget () {
        Vector3 direction = (target.position - transform.position).normalized;
        Quaternion lookRotation = Quaternion.LookRotation (new Vector3 (direction.x, 0f, direction.z));
        transform.rotation = Quaternion.Slerp (transform.rotation, lookRotation, Time.deltaTime * 5f);
    }
}
