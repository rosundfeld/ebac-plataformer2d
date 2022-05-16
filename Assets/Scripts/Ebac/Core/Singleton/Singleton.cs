using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Ebac.core.Singleton
{

    public class Singleton<T> : MonoBehaviour where T : MonoBehaviour //<T> Significa um tipo que a classe ira receber ;; Irá receber apenas parametro MonoBehavior
{
    public static T Instance; //precisa ser static para o gamemanager, Instance é um padrao para static
   
    private void Awake() {
        if(Instance == null)
            Instance = GetComponent<T>(); // necessario alterar
        else
            Destroy(gameObject);
    }
}

}

