using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Ebac.core.Singleton;
using UnityEngine.UI;

public class ItemsManager : Singleton<ItemsManager>
{
    public int coins;
    public Text coinsConterText;

    private void Update() {
        coinsConterText.text = "x" + coins.ToString();
    }

    private void Start()
    {
        Reset();
    }

    private void Reset()
    {
        coins = 0;
    }

    public void AddCoins(int amount = 1)
    {
        coins += amount;
    }
}
