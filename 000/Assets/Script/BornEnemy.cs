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
    public GameObject Scenes;
    public GameObject[] Enemy;
    public GameObject Boss;
    public List<GameObject> EL;
    public int b;
    public int Count;



    private void Awake()
    {
        bornA_1 = GameObject.Find("模式A/生成區域A_1");
        bornA_2 = GameObject.Find("模式A生成區域A_2");
        bornA_3 = GameObject.Find("模式A生成區域A_3");
        bornB = GameObject.Find("模式B/生成區域B_1");
        bornC_1 = GameObject.Find("模式C/生成區域C_1");
        bornC_2 = GameObject.Find("模式C/生成區域C_2");
        Scenes = GameObject.Find("SunshineForest");
        Enemy = Resources.LoadAll<GameObject>("Enemy");
        Boss = Resources.Load<GameObject>("BOSS/BOSS_1");
        b = Random.Range(0, Enemy.Length);
        Count = 0;
    }

    private void Start()
    {
        BORNENEMY();
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
        if (a == 0 && Count < 5)
        {
            StartCoroutine(MoveA());
            Count = Count + 1;
        }
        if (a == 1 && Count < 5)
        {
            StartCoroutine(MoveB());
            Count = Count + 1;
            print(Count);
        }
        if (a == 2 && Count < 5)
        {
            StartCoroutine(MoveC());
            Count = Count + 1;
        }
        if (a >0 && Count >= 5)
        {
            StartCoroutine(BOSS());
            Count = 0;
        }

    }

    private IEnumerator MoveA()
    {

        for (int i = 0; i < 2; i++)
        {
            yield return new WaitForSeconds(0.01f);
            Scenes.transform.position = new Vector2(0, 0.22f);
            yield return new WaitForSeconds(0.01f);
            Scenes.transform.position = new Vector2(0, 0);
            yield return new WaitForSeconds(0.01f);
            Scenes.transform.position = new Vector2(0, -0.22f);
            yield return new WaitForSeconds(0.01f);
            Scenes.transform.position = new Vector2(0, 0);
        }
            Instantiate(Enemy[b], bornA_1.transform);
            Instantiate(Enemy[b], bornA_2.transform);
            Instantiate(Enemy[b], bornA_3.transform);
            print("A");
    }
    private IEnumerator MoveB()
    {
        for (int i = 0; i < 2; i++)
        {
            yield return new WaitForSeconds(0.01f);
            Scenes.transform.position = new Vector2(0, 0.22f);
            yield return new WaitForSeconds(0.01f);
            Scenes.transform.position = new Vector2(0, 0);
            yield return new WaitForSeconds(0.01f);
            Scenes.transform.position = new Vector2(0, -0.22f);
            yield return new WaitForSeconds(0.01f);
            Scenes.transform.position = new Vector2(0, 0);

        }
            Instantiate(Enemy[b], bornB.transform);
            print("B");
    }
    private IEnumerator MoveC()
    {
        for (int i = 0; i < 2; i++)
        {
            yield return new WaitForSeconds(0.01f);
            Scenes.transform.position = new Vector2(0, 0.22f);
            yield return new WaitForSeconds(0.01f);
            Scenes.transform.position = new Vector2(0, 0);
            yield return new WaitForSeconds(0.01f);
            Scenes.transform.position = new Vector2(0, -0.22f);
            yield return new WaitForSeconds(0.01f);
            Scenes.transform.position = new Vector2(0, 0);

        }
            Instantiate(Enemy[b], bornC_1.transform);
            Instantiate(Enemy[b], bornC_2.transform);
            print("C");
    }   
    private IEnumerator BOSS()
    {
        for (int i = 0; i < 2; i++)
        {
            yield return new WaitForSeconds(0.01f);
            Scenes.transform.position = new Vector2(0, 0.22f);
            yield return new WaitForSeconds(0.01f);
            Scenes.transform.position = new Vector2(0, 0);
            yield return new WaitForSeconds(0.01f);
            Scenes.transform.position = new Vector2(0, -0.22f);
            yield return new WaitForSeconds(0.01f);
            Scenes.transform.position = new Vector2(0, 0);
            yield return new WaitForSeconds(0.8f);
            print("BOSS");
        }
        Instantiate(Boss, bornB.transform);
    }
}


