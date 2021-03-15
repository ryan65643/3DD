using UnityEngine;
using UnityEngine.AI;
using System.Collections;

public class Enemy : MonoBehaviour
{
    [Header("攻擊CD"), Range(0, 1000)]
    public float AttackCD = 1.5f;
    [Header("攻擊傷害"), Range(0, 1000)]
    public float Atk = 99;
    [Header("血量"), Range(0, 10000)]
    public float hp = 1500;

    private void Awake()
    {
     
    }

 

    private void Update()
    {
    }

    public void Damge(float GetDamge)
    {
        hp -= GetDamge;
        if (hp <= 0) dead();

    }

    private void dead()
    {
        hp = 0;
        Destroy(this);
        enabled = false;
    }

}
