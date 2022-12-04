using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class SOUiIntUpdate : MonoBehaviour
{
    public SOInt soInt;
    public TextMeshProUGUI uiTextValue;


    private void Start()
    {
        uiTextValue.text = soInt.value.ToString();
    }


    private void Update()
    {
        uiTextValue.text = soInt.value.ToString();
    }
}
