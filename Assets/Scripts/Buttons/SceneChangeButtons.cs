using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SceneChangeButtons : MonoBehaviour
{
    [SerializeField] private int sceneIndex;

    private void Start()
    {
        Button button = GetComponent<Button>();
        if (button != null)
        {
            button.onClick.AddListener(ChangeScene);
        }
    }

    private void ChangeScene()
    {
        SceneChanger.Instance.ChangeScene(sceneIndex);
    }
}
