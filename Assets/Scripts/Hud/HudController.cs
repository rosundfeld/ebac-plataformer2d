using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Ebac.core.Singleton;
using UnityEngine.UI;
using TMPro; //usado para declarar o TextMeshProUGUI

public class HudController : Singleton<HudController> {

    public TextMeshProUGUI coinCounter;

    public static void UpdateTextCoins(string s) { //Statico não está no mesmo contexto da Classe, ou seja vamos acessar o CoinCounter com o proprio Singleton, assim a função vai aparecer nas outras classes
        Instance.coinCounter.text = s;
    }
}
