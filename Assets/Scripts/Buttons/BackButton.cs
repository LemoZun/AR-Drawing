using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class BackButton : MonoBehaviour
{

    private void Awake()
    {
        
    }
    private void Start()
    {
        Button button = GetComponent<Button>();
        if(button != null )
        {
            button.onClick.AddListener(() => SceneChanger.Instance.ChageScene(0));
            //button.onClick += SceneChanger.Instance.ChageScene(0);
        }

    }
}
