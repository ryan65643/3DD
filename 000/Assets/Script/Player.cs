using UnityEngine;
using UnityEngine.UI;

public class Player : MonoBehaviour
{
    [Header("生命"),Range(0,999)]
    public float HP =100;
    public float Hpmax;
    [Header("魔力"), Range(0, 999)]
    public float MP =100;
    public float Mpmax;
    [Header("經驗"),Range(0,999)]
    public float EXP =100;
    public float Expmax;
    [Header("等級"),Range(0,999)]
    public float LV =1;

    /// <summary>
    /// 受傷
    /// </summary>
    /// <param name="Damge"></param>
    public void hit(float Damge)
    {

    }

}
