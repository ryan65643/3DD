using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;

public class BornEnemy : MonoBehaviour
{
    [Header("生成點")]
    public GameObject bornA_1;
    public GameObject bornA_2;
    public GameObject bornA_3;
    public GameObject bornB;
    public GameObject bornC_1;
    public GameObject bornC_2;
    public GameObject[] Enemy;
    public GameObject Enemy0;
    public List<GameObject> EL;



    private void Awake()
    {
        bornA_1 = GameObject.Find("模式A/生成區域A_1");
        bornA_2 = GameObject.Find("模式A生成區域A_2");
        bornA_3 = GameObject.Find("模式A生成區域A_3");
        bornB = GameObject.Find("模式B/生成區域B_1");
        bornC_1 = GameObject.Find("模式C/生成區域C_1");
        bornC_2 = GameObject.Find("模式C/生成區域C_2");
        Enemy = Resources.LoadAll<GameObject>("Enemy");
    }

    private void Update()
    {
        
    }
    /// <summary>
    /// 生成怪物
    /// </summary>
    public void BORNENEMY()
    {
        float a = Random.Range(0, 2);
        int b = Random.Range(0, Enemy.Length);
        if (a==0)
        {
            Instantiate(Enemy[b], bornA_1.transform);
            Instantiate(Enemy[b], bornA_2.transform);
            Instantiate(Enemy[b], bornA_3.transform);
            print("A");

        }
        if (a == 1)
        {
            Enemy0=Instantiate(Enemy[b], bornB.transform).gameObject;
            print("B");


        }
        if (a == 2)
        {
            Instantiate(Enemy[b], bornC_1.transform);
            Instantiate(Enemy[b], bornC_2.transform);
            print("C");

        }
    }
}


