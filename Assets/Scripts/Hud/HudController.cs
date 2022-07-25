using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Ebac.core.Singleton;
using UnityEngine.UI;
using TMPro; //usado para declarar o TextMeshProUGUI

public class HudController : MonoBehaviour {

    public ItemsManager itensManager;

    [SerializeField] private TextMeshProUGUI coinCounter;
    
    private void Update() {
        
    }
}
