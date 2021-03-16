using UnityEngine;

public class Prop : MonoBehaviour
{
    [Header("一般條的長度")]
    public float Length0 = 0.378f;
    [Header("完美條的長度")]
    public float Length90 = 0.02f;
    [Header("糟糕條的長度")]
    public float Length180 = -0.378f;
    private float Speed = 1;
    private float cc;
    public GameObject Judgmentarea;
    private bool Born;
    private void Start()
    {
        Born = true;
    }
    private void Awake()
    {

    }
    private void Update()
    {
        Judgmentarea = GameObject.Find("判斷區域");
        move();

    }

    private void OnDrawGizmos()
    {
        Gizmos.color = new Color(1, 0, 0, 0.3f);
        Gizmos.DrawRay(transform.position, Vector3.left * Length0);
        Gizmos.color = new Color(0, 1, 0, 0.3f);
        Gizmos.DrawRay(transform.position, Vector3.left * Length90);
        Gizmos.color = new Color(0, 0, 1, 0.3f);
        Gizmos.DrawRay(transform.position, Vector3.left * Length180);
    }
    /// <summary>
    /// 方塊移動
    /// </summary>
    private void move()
    {
        if (Born)
        {
            transform.Translate(Vector2.left * Time.deltaTime * Speed);
        }

    }
    public void Cal()
    {
       
            // cc = Vector3.Distance(Ju.position, Judgmentarea.transform.position);
            cc = transform.position.x - Judgmentarea.transform.position.x;
            print(cc);
        

    }
}

