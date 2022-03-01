using System;
using UnityEngine;

public class DotThreshold : MonoBehaviour
{
    [SerializeField] private Transform targetTransform;
    [Range(0f, 180f)]
    [SerializeField] private float angleThreshold;

    private void OnDrawGizmos()
    {
        if (!targetTransform) { return; }

        var watcherPosition = transform.position;
        var vectorToTarget = (targetTransform.position - watcherPosition).normalized;
        var lookVector = transform.right;

        // Vector3.Dot
        var dotProduct = vectorToTarget.x * lookVector.x + vectorToTarget.y * lookVector.y + vectorToTarget.z * lookVector.z;
        // var angle = Mathf.Acos(dotProduct / (vectorToTarget.magnitude * lookAtVector.magnitude)) * Mathf.Rad2Deg;
        var angle = Mathf.Acos(dotProduct) * Mathf.Rad2Deg;
        
        var isInThreshold = Mathf.Abs(angle) < Mathf.Abs(angleThreshold) ? true : false;
        Gizmos.color = isInThreshold ? Color.green : Color.red; 

        Gizmos.DrawRay(watcherPosition, lookVector);
    }
}
