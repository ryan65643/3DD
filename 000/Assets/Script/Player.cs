using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class Player : MonoBehaviour
{
    [Header("生命"), Range(0, 999)]
    public float HP = 100;
    public float Hpmax = 100;
    public Text HPT;
    public Text MAXHPT;
    [Header("魔力"), Range(0, 999)]
    public float MP = 100;
    public float Mpmax = 100;
    public Text MPT;
    public Text MAXMPT;
    [Header("經驗"), Range(0, 999)]
    public float EXP = 0;
    public float Expmax = 100;
    public Text EXPT;
    public Text MAXEXPT;
    [Header("等級"), Range(0, 999)]
    public float LV = 1;
    public Text LVT;
    [Header("攻擊傷害"), Range(0, 1000)]
    public float Atk = 15;
    public GameObject Talk;
    public GameObject MeauDead;
    public GameObject Meau;
    public CanvasGroup CanDead;
    public GameObject BronPropD;

    private void Start()
    {
        Talk.SetActive(false);
        MeauDead.SetActive(false);
    }

    private void Awake()
    {
        HPT = GameObject.Find("血量值").GetComponent<Text>();
        MAXHPT = GameObject.Find("最大血量值").GetComponent<Text>();
        MPT = GameObject.Find("魔力值").GetComponent<Text>();
        MAXMPT = GameObject.Find("最大魔力值").GetComponent<Text>();
        EXPT = GameObject.Find("經驗值").GetComponent<Text>();
        LVT = GameObject.Find("等級").GetComponent<Text>();
        MeauDead = GameObject.Find("結束畫面");
        Meau = GameObject.Find("場景控制器");
        CanDead = GameObject.Find("結束畫面").GetComponent<CanvasGroup>();
        Talk = GameObject.Find("對話框");
        LVT.text = LV.ToString("LV: "+LV);
        BronPropD = GameObject.Find("判斷區域底層");

        HP = Hpmax;
        MP = Mpmax;

    }
    private void Update()
    {

    }

    /// <summary>
    /// 受傷
    /// </summary>
    /// <param name="Damge"></param>
    public void Perfect(float GetDamge)
    {
        HP -= GetDamge*0.5f;
        HP = (int)HP;
        HPT.text = HP.ToString();
        if (HP <= 0) dead();


    }

    public void Good(float GetDamge)
    {

        HP -= GetDamge;
        HPT.text = HP.ToString();
        if (HP <= 0) dead();

    }

    public void Bad(float GetDamge)
    {

        HP -= GetDamge*2;
        HPT.text = HP.ToString();
        if (HP <= 0) dead();

    }

    private void dead()
    {
        HP = 0;
        MeauDead.SetActive(true);
        CanDead.alpha = 1;
        CanDead.interactable = true;
        CanDead.blocksRaycasts = true;
        enabled = false;

    }

    public void GetLv(int Exp)
    {
        EXP += Exp;
        if (EXP>=100)
        {
            EXP = EXP-100;
            EXPT.text = EXP.ToString();
            LV += 1;
            LVT.text = LV.ToString("LV: " + LV);
        }
        EXPT.text = EXP.ToString();
    }

    public void exit()
    {
        StartCoroutine(DelayTalk());
        HP -= HP*0.2f;
        HP = (int)HP;
        HP = Mathf.Clamp(HP,1, 100);
        HPT.text = HP.ToString();
        if (HP <= 0) dead();
    }

    private IEnumerator DelayTalk()
    {
        Talk.SetActive(true);
        BronPropD.SetActive(false);
        yield return new WaitForSeconds(1);
        Talk.SetActive(false);
        BronPropD.SetActive(true);
    }

}
