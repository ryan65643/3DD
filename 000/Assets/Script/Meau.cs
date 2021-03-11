using UnityEngine;
using UnityEngine.UI;

public class Meau : MonoBehaviour
{
    public GameObject Backpage;
    public GameObject Skill;
    public GameObject Mea;
    public CanvasGroup CanSkill;
    public CanvasGroup CanBackpage;
    public CanvasGroup CanMeau;

    private void Awake()
    {
        Skill = GameObject.Find("技能層");
        Backpage = GameObject.Find("背包層");
        Mea = GameObject.Find("介面層");
        CanSkill = GameObject.Find("技能層").GetComponent<CanvasGroup>();
        CanBackpage = GameObject.Find("背包層").GetComponent<CanvasGroup>();
        CanMeau = GameObject.Find("介面層").GetComponent<CanvasGroup>();
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
}
