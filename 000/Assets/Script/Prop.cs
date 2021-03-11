using UnityEngine;

public class Prop : MonoBehaviour
{
    [Header("一般條的長度")]
    public float Length0 = 0.443f;
    [Header("完美條的長度")]
    public float Length90 = 0.02f;
    [Header("糟糕條的長度")]
    public float Length180 = -0.443f;
    private void OnDrawGizmos()
    {
        Gizmos.color = new Color(1, 0, 0, 0.3f);
        Gizmos.DrawRay(transform.position,Vector3.left*Length0);
        Gizmos.color = new Color(0, 1, 0, 0.3f);
        Gizmos.DrawRay(transform.position, Vector3.left * Length90);
        Gizmos.color = new Color(0, 0, 1, 0.3f);
        Gizmos.DrawRay(transform.position, Vector3.left * Length180);
    }

}
