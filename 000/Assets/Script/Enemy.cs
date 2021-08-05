using UnityEngine;
using UnityEngine.AI;
using System.Collections;

public class Enemy : MonoBehaviour
{
    [Header("攻擊CD"), Range(0, 1000)]
    public float AttackCD = 1.5f;
    [Header("攻擊傷害"), Range(0, 1000)]
    public float Atk = 1;
    [Header("血量"), Range(0, 10000)]
    public float HP = 150;
    [Header("經驗"), Range(0, 10000)]
    public int Exp = 30;
    private GameObject Player;


    private void Awake()
    {
        Player = GameObject.Find("Piayer");

    }



    private void Update()
    {
    }

    public void Perfect(float GetDamge)
    {

        HP -= GetDamge * 2;
        if (HP <= 0) dead();

    }

    public void Good(float GetDamge)
    {

        HP -= GetDamge;
        if (HP <= 0) dead();

    }

    public void Bad(float GetDamge)
    {
        HP -= GetDamge * 0.5f;
        if (HP <= 0) dead();
        Destroy(this);
    }

    private void dead()
    {
        Player.GetComponent<Player>().GetLv(Exp);
        Destroy(this);
        enabled = false;
    }



}
