using System;
using UnityEngine;
using UnityEngine.AI;

[RequireComponent(typeof(NavMeshAgent))]
public class Walker : MonoBehaviour {
    Transform target;
    NavMeshAgent agent;

    private void OnEnable() {
        agent = GetComponent<NavMeshAgent>();
    }

    private void Update() {
        if (target != null) {
            FaceTarget();
        }
    }

    public bool HasArrived() {
        return !agent.pathPending && 
               agent.remainingDistance <= agent.stoppingDistance &&
               (!agent.hasPath || Math.Abs(agent.velocity.sqrMagnitude) < 0.1f);
    }

    public void GoToPoint(Vector3 point) {
        agent.SetDestination(point);
    }

    public void WalkToTarget(Interactable newTarget) {
        agent.stoppingDistance = newTarget.radius;
        agent.SetDestination(newTarget.transform.position);
    }

    public void Follow(Interactable newTarget) {
        agent.stoppingDistance = newTarget.radius;
        target = newTarget.transform;
    }

    public void Unfollow() {
        agent.stoppingDistance = 0f;
        agent.updateRotation = true;
        target = null;
    }

    private void FaceTarget() {
        Vector3 direction = (target.position - transform.position).normalized;
        Quaternion lookRotation = Quaternion.LookRotation(new Vector3(direction.x, 0f, direction.z));
        transform.rotation = Quaternion.Slerp(transform.rotation, lookRotation, Time.deltaTime * 5f);
    }
}