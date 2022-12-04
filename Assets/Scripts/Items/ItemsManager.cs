using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Ebac.core.Singleton;
using UnityEngine.UI;
using TMPro;

public class ItemsManager : Singleton<ItemsManager>
{
    public SOInt coins;
    public TextMeshProUGUI uiTextCoins;

    private void Start()
    {
        Reset();
    }

    private void Reset()
    {
        coins.value = 0;
        UpdateUI();
    }

    public void AddCoins(int amount = 1)
    {
        coins.value += amount;
        UpdateUI();
    }

    private void UpdateUI()
    {
        //HudController.UpdateTextCoins(coins.value.ToString());
    }
}
