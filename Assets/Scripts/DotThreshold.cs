using System;
using UnityEngine;

public class DotThreshold : MonoBehaviour
{
    [SerializeField] private Transform targetTransform;
    [Range(-1f, 1f)] 
    [SerializeField] private float threshold;
    [SerializeField] private bool angleThresholdOverride;
    [Range(0f, 180f)]
    [SerializeField] private float angleThreshold;

    private bool _isInThreshold;
    
    private void OnDrawGizmos()
    {
        if (!targetTransform) { return; }

        var watcherPosition = transform.position;
        var vectorToTarget = (targetTransform.position - watcherPosition).normalized;
        var lookVector = transform.right;

        if (angleThresholdOverride)
        {
            // Vector3.Dot
            var dotProduct = vectorToTarget.x * lookVector.x + vectorToTarget.y * lookVector.y;
            // var angle = Mathf.Acos(dotProduct / (vectorToTarget.magnitude * lookAtVector.magnitude)) * Mathf.Rad2Deg;
            var angle = Mathf.Acos(dotProduct) * Mathf.Rad2Deg;

            _isInThreshold = Mathf.Abs(angle) <= Mathf.Abs(angleThreshold) ? true : false;
        }
        else
        {
            var dotProduct = vectorToTarget.x * lookVector.x + vectorToTarget.y * lookVector.y;
            _isInThreshold = dotProduct >= threshold ? true : false;
        }

        Gizmos.color = _isInThreshold ? Color.green : Color.red; 

        Gizmos.DrawRay(watcherPosition, lookVector);
    }
}
