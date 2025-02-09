using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class BackButton : MonoBehaviour
{
    private void Start()
    {
        Button button = GetComponent<Button>();
        if(button != null )
        {
            button.onClick.AddListener(() => SceneChanger.Instance.ChangeScene(0));
        }

    }
}
