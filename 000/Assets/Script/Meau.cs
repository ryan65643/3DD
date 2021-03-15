using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using UnityEngine.SceneManagement;


public class Meau : MonoBehaviour
{
    public GameObject Backpage;
    public GameObject Skill;
    public GameObject Mea;
    public GameObject Judgmentarea;
    public GameObject[] Gam;
    public Transform[] Gams;
    [Header("生成點")]
    public GameObject BronProp;
    [Header("間隔時間"), Range(0f, 10f)]
    public float bye ;
    public CanvasGroup CanSkill;
    public CanvasGroup CanBackpage;
    public CanvasGroup CanMeau;
    public GameObject Prop;
    private float Speed = 10;
    private float cc;
    private bool StarGame =false;
    // private bool ATKT;

    private void Start()
    {
        // ATKT = true;
        Judgmentarea.SetActive(false);
    }
    private void Update()
    {
        a();
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
        Gams = Resources.LoadAll<Transform>("");


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
        bye = Random.Range(1f, 5000f);
        int r = Random.Range(0, Gam.Length);
        Transform point = BronProp.transform;
        Prop = Instantiate(Gam[r], point.position, point.rotation).gameObject;
        InvokeRepeating("born", 1, bye);
        //cc = Gams.transform.position.x - Judgmentarea.transform.position.x;
        cc = Vector3.Distance(Prop.transform.position, BronProp.transform.position);
        print(cc);

       

    }

 
    private void OpenCkeck()
    {


        if (Input.GetKeyDown(KeyCode.DownArrow)&&cc<=1)
        {
        print("goo");
            Judgmentarea.SetActive(true);
            che();
        }
        else Judgmentarea.SetActive(false);
    }

    private void che()
    {
        if (cc == 0)
        {
            print("Perfect");

        }
        else if (cc <= 1 && cc != 0)
        {
            print("GOOD");
        }
        else if (cc < -0.5f && cc != 0)
        {
            print("BAD");
        }
    }

    public void stargame()
    {
        born();
    }
    //private void Perfert()
    //{

    // }

    public void restgame()
    { SceneManager.LoadScene("遊戲場景"); }

    public void quit()
    {
        Application.Quit();
    }
}
