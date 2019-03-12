using System;
using System.Collections;
using System.Collections.Generic;
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
            GoToPoint(target.position);
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
    
    public static void OnAllArrive(Component[] walkers, Action callback) {
        GameManager.Instance.StartCoroutine(allArrivingProcess(walkers, callback));
    }

    private static IEnumerator allArrivingProcess(Component[] walkers, Action callback) {
        yield return new WaitUntil(delegate {
            foreach (Component component in walkers) {
                Walker walker = component.gameObject.GetComponent<Walker>();
                if (walker && !walker.HasArrived()) {
                    return false;
                }
            }

            return true;
        });
        callback.Invoke();
    }
    
    public void OnArrive(Action callback) {
        StartCoroutine(arrivingProcess(callback));
    }
    
    private IEnumerator arrivingProcess(Action callback) {
        yield return new WaitUntil(delegate {
            return HasArrived();
        });
        callback.Invoke();
    }
}