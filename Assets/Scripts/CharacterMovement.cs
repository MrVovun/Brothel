using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

[RequireComponent (typeof (NavMeshAgent))]

public class CharacterMovement : MonoBehaviour {

    Transform target;
    NavMeshAgent agent;

    void Start () {
        agent = GetComponent<NavMeshAgent> ();
    }

    public void MoveToPoint (Vector3 point) {
        if (target != null) {
            StopFollowingTarget ();
        }
        agent.SetDestination (point);
    }

    public void FollowTarget (Interactable newTarget) {
        agent.stoppingDistance = newTarget.interactionRadius;
        target = newTarget.transform;
    }

    public void StopFollowingTarget () {
        target = null;
        agent.stoppingDistance = 0;
    }

    void Update () {
        if (target != null) {

            agent.SetDestination (target.position);
        }
    }
}
