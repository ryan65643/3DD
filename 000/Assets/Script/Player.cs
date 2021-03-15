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
    public GameObject Talk;
    public GameObject MeauDead;
    public CanvasGroup CanDead;

    private void Start()
    {
        Talk.SetActive(false);
        MeauDead.SetActive(false);
    }

    private void Awake()
    {
        MeauDead = GameObject.Find("結束畫面");
        Talk = GameObject.Find("對話框");
        LVT.text = LV.ToString("LV: "+LV);
        HP = Hpmax;
        MP = Mpmax;

    }

    /// <summary>
    /// 受傷
    /// </summary>
    /// <param name="Damge"></param>
    public void Perfect(float GetDamge)
    {

        HP -= GetDamge;
        HPT.text = HP.ToString();
        if (HP <= 0) dead();

    }

    private void dead()
    {
        HP = 0;
        CanDead.alpha = 1;
        CanDead.interactable = true;
        CanDead.blocksRaycasts = true;
        enabled = false;

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
        yield return new WaitForSeconds(1);
        Talk.SetActive(false);
    }

}
