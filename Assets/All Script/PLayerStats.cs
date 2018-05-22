using UnityEngine;
using System.Collections;



public class PLayerStats : MonoBehaviour {

    public static int Money;
    public int startMoney = 100;

    public static int Life;
    public int startLife = 3;

    void Start()
    {
        Money = startMoney;
        Life = startLife;
    }
}
