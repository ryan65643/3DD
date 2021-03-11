using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class Meau : MonoBehaviour
{
    public GameObject Backpage;
    public GameObject Skill;
    public GameObject Mea;
    public GameObject Judgmentarea;
    public GameObject[] Gam;
    [Header("生成點")]
    public GameObject BronProp;
    [Header("間隔時間"), Range(0f, 10f)]
    public float bye = 10f;
    public CanvasGroup CanSkill;
    public CanvasGroup CanBackpage;
    public CanvasGroup CanMeau;
    public Transform Prop;
    private float Speed = 10;
    private bool a;

    private void Start()
    {
        a = true;
        Judgmentarea.SetActive(false);
        InvokeRepeating("born", 0, bye);
    }
    private void Update()
    {
        OpenCkeck();
    }
    private void Awake()
    {
        Judgmentarea = GameObject.Find("判斷區域");
        Skill = GameObject.Find("技能層");
        Backpage = GameObject.Find("背包層");
        Mea = GameObject.Find("介面層");
        CanSkill = GameObject.Find("技能層").GetComponent<CanvasGroup>();
        CanBackpage = GameObject.Find("背包層").GetComponent<CanvasGroup>();
        CanMeau = GameObject.Find("介面層").GetComponent<CanvasGroup>();
        BronProp = GameObject.Find("生成區域");
        Gam = Resources.LoadAll<GameObject>("");


    }
    #region 介面按鈕切換
    public void openmeau()
    {
        CanMeau.alpha = 1;
        CanMeau.interactable = true;
        CanMeau.blocksRaycasts = true;
    }

    public void closemeau()
    {
        CanMeau.alpha = 0;
        CanMeau.interactable = false;
        CanMeau.blocksRaycasts = false;
    }

    public void openskill()
    {
        CanSkill.alpha = 1;
        CanSkill.interactable = true;
        CanSkill.blocksRaycasts = true;
    }

    public void closeskill()
    {
        CanSkill.alpha = 0;
        CanSkill.interactable = false;
        CanSkill.blocksRaycasts = false;

    }

    public void quitskill()
    {
        closeskill();
        openmeau();
    }

    public void openBackpage()
    {
        CanBackpage.alpha = 1;
        CanBackpage.interactable = true;
        CanBackpage.blocksRaycasts = true;
    }

    public void closeBackpage()
    {
        CanBackpage.alpha = 0;
        CanBackpage.interactable = false;
        CanBackpage.blocksRaycasts = false;
    }

    public void quitBackpage()
    {
        closeBackpage();
        openmeau();
    }
    #endregion
    /// <summary>
    /// 生成方塊
    /// </summary>
    private void born()
    {
        int r = Random.Range(0, Gam.Length);
        Transform point = BronProp.transform;
        if (a)
        {
            GameObject temp = Instantiate(Gam[r], point.position, point.rotation).gameObject;
        }

    }
    private void OpenCkeck()
    {
        if (Input.GetKeyDown(KeyCode.DownArrow))
        {
            Judgmentarea.SetActive(true);
            che();
        }
        else Judgmentarea.SetActive(false);

    }

    private void che()
    {
        RaycastHit2D Hit = Physics2D.Raycast(transform.position, Vector2.left, 1 << 8);
        if (Hit && Hit.transform.name == "判斷區域")
        {
            print("123");
        }
    }


}
