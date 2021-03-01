using UnityEngine;
using UnityEngine.UI;

public class Meau : MonoBehaviour
{
    public GameObject Backpage;
    public GameObject Skill;
    public GameObject Mea;

    private void Awake()
    {
        Skill = GameObject.Find("技能層");
        Backpage = GameObject.Find("背包層");
        Mea = GameObject.Find("介面層");
    }

    public void openskill()
    {
        if (Input.GetKeyDown(KeyCode.Mouse0))
        {
            print("123");
            Mea.SetActive(false);
            Skill.SetActive(true);
        }
    }
}
