using UnityEngine;

public class Prop : MonoBehaviour
{
    [Header("左線條的長度")]
    public float Length0 = 0.376f;
    [Header("上線條的長度")]
    public float Length90 = 0.376f;

    private void OnDrawGizmos()
    {
        Gizmos.color = new Color(1, 0, 0, 0.3f);
        Gizmos.DrawRay(transform.position,Vector3.left*Length0);
        Gizmos.color = new Color(0, 1, 0, 0.3f);
        Gizmos.DrawRay(transform.position, Vector3.up * Length90);
    }

}
