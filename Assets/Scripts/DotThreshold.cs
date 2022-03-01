using System;
using UnityEngine;

public class DotThreshold : MonoBehaviour
{
    [SerializeField] private Transform targetTransform;
    [SerializeField] private float angleThreshold;

    private void OnDrawGizmos()
    {
        var vectorToTarget = targetTransform.position - transform.position;
        var lookAtVector = transform.right;

        var dotProduct = vectorToTarget.x * lookAtVector.x + vectorToTarget.y * lookAtVector.y + vectorToTarget.z * lookAtVector.z;
        var angle = Mathf.Acos(dotProduct / (vectorToTarget.magnitude * lookAtVector.magnitude)) * Mathf.Rad2Deg;
        
        var isInThreshold = Mathf.Abs(angle) < Mathf.Abs(angleThreshold) ? true : false;
        Gizmos.color = isInThreshold ? Color.green : Color.red; 

        Gizmos.DrawRay(transform.position, lookAtVector);
    }
}
