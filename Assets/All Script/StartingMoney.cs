using UnityEngine;
using UnityEngine.UI;
using System.Collections;


public class StartingMoney : MonoBehaviour {

    public Text startingMoneyText;
	
	
	void Update () {
        startingMoneyText.text = "V"+PLayerStats.Money.ToString();
	}
}
