using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;


public class Meau : MonoBehaviour
{
    public GameObject Backpage;
    public GameObject Skill;
    public GameObject Mea;
    public GameObject Judgmentarea;
    public Transform Ju;
    public GameObject[] Gam;
    public GameObject CA;
    public Transform[] Gams;
    [Header("生成點")]
    public GameObject BronProp;
    public GameObject BronPropD;
    [Header("間隔時間"), Range(0f, 10f)]
    public float bye;
    public CanvasGroup CanSkill;
    public CanvasGroup CanBackpage;
    public CanvasGroup CanMeau;
    public GameObject Prop;
    private float Speed = 10;
    private float cc;
    private bool StarGame = false;
    private bool S = false;
    private GameObject Player;
    private GameObject Enemy;
    private bool ATKT = false;
    private bool ATKTs = false;
    private bool ASCAL = false;
    public GameObject Per;
    public GameObject GOOD;
    public GameObject BAD;
    public List<GameObject> Arrows;

    private void Start()
    {
        Judgmentarea.SetActive(false);
        Per.SetActive(false);
        GOOD.SetActive(false);
        BAD.SetActive(false);
        BronPropD.SetActive(false);

    }
    private void Update()
    {
        OpenCkeck();
        CAl();
        Egame();
    }
    private void Awake()
    {
        Judgmentarea = GameObject.Find("判斷區域");
        BronPropD = GameObject.Find("判斷區域底層");
        Player = GameObject.Find("Piayer");
        Skill = GameObject.Find("技能層");
        Backpage = GameObject.Find("背包層");
        Mea = GameObject.Find("介面層");
        CanSkill = GameObject.Find("技能層").GetComponent<CanvasGroup>();
        CanBackpage = GameObject.Find("背包層").GetComponent<CanvasGroup>();
        CanMeau = GameObject.Find("介面層").GetComponent<CanvasGroup>();
        BronProp = GameObject.Find("生成區域");
        Gam = Resources.LoadAll<GameObject>("Prop");
        CA = Resources.Load<GameObject>("Prop/上");
        Gams = Resources.LoadAll<Transform>("Prop");
        Enemy = GameObject.Find("Enemy");
        Ju = Judgmentarea.GetComponent<Transform>();
        Per = GameObject.Find("Perfect");
        GOOD = GameObject.Find("Good");
        BAD = GameObject.Find("BAD");



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
        BronPropD.SetActive(true);
        bye = Random.Range(1f, 3f);
        int r = Random.Range(0, Gam.Length);
        Transform point = BronProp.transform;
        Prop = Instantiate(Gam[r], point.position, point.rotation).gameObject;
        Arrows.Add(Prop);
        ASCAL = true;

    }

    private void CAl()
    {
        if (ASCAL)
        {

            cc = Arrows[0].transform.position.x - Judgmentarea.transform.position.x;
            print(cc);
        }

    }


    private void OpenCkeck()
    {

        if (cc <= -0.35f && cc != 0)
        {
            StartCoroutine(DelayBAD());
            Player.GetComponent<Player>().Bad(Enemy.GetComponent<Enemy>().Atk);
            Enemy.GetComponent<Enemy>().Bad(Player.GetComponent<Player>().Atk);
            Destroy(Arrows[0]);
            Arrows.RemoveAt(0);

        }
        if (Input.GetKeyDown(KeyCode.DownArrow))
        {
            Judgmentarea.SetActive(true);
            che();
        }
        else Judgmentarea.SetActive(false);
    }

    private void che()
    {
        if (cc == 0)
        {
            StartCoroutine(DelayPer());
            Player.GetComponent<Player>().Perfect(Enemy.GetComponent<Enemy>().Atk);
            Enemy.GetComponent<Enemy>().Perfect(Player.GetComponent<Player>().Atk);
            Destroy(Arrows[0]);
            Arrows.RemoveAt(0);


        }
        else if (cc <= 0.35 && cc > 0)
        {
            StartCoroutine(DelayGOOD());
            Player.GetComponent<Player>().Good(Enemy.GetComponent<Enemy>().Atk);
            Enemy.GetComponent<Enemy>().Good(Player.GetComponent<Player>().Atk);
            Destroy(Arrows[0]);
            Arrows.RemoveAt(0);


        }
 
    }

    public void stargame()
    {
        if (!ATKT)
        {
            ATKT = true;
            InvokeRepeating("born", 0, bye);

        }
    }

    public void Egame()
    {
        if (Player.GetComponent<Player>().HP<=0)
        {
        CancelInvoke("born");
            enabled = false;
        }
    }

    public void restgame()
    { SceneManager.LoadScene("遊戲場景"); }

    public void quit()
    {
        Application.Quit();
    }

    private IEnumerator DelayPer()
    {
        Per.SetActive(true);
        yield return new WaitForSeconds(0.5f);
        Per.SetActive(false);
    }
    private IEnumerator DelayGOOD()
    {
        GOOD.SetActive(true);
        yield return new WaitForSeconds(0.5f);
        GOOD.SetActive(false);
    }
    private IEnumerator DelayBAD()
    {
        BAD.SetActive(true);
        yield return new WaitForSeconds(0.5f);
        BAD.SetActive(false);
    }

}
