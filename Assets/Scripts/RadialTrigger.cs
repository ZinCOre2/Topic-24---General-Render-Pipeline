using UnityEditor;
using UnityEngine;

public class RadialTrigger : MonoBehaviour
{
    [SerializeField] private Transform targetPoint;
    [SerializeField] private float triggerRadius;

    private void OnDrawGizmos()
    {
        if (!targetPoint) { return; }

        var triggerPosition = transform.position;
        var vectorToTarget = targetPoint.position - triggerPosition;
        var sqrMagnitude = vectorToTarget.x * vectorToTarget.x + vectorToTarget.y * vectorToTarget.y + vectorToTarget.z * vectorToTarget.z;
        var isInRadius = sqrMagnitude < triggerRadius * triggerRadius ? true : false;
        
        Handles.color = isInRadius ? Color.green : Color.red;

        Handles.DrawWireDisc(triggerPosition, Vector3.forward, triggerRadius);
    }
}
