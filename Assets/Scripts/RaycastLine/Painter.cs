using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.ARFoundation;
using UnityEngine.XR.ARSubsystems;

public class Painter : MonoBehaviour
{
    [SerializeField] public GameObject paintPrefab;
    private ARRaycastManager raycastManager;
    private List<ARRaycastHit> hits = new List<ARRaycastHit>();

    private void Awake()
    {
        raycastManager = GetComponent<ARRaycastManager>();
        if (raycastManager == null)
        {
            Debug.LogError("ARRaycastManager 찾지 못함");
        }
    }

    private void Update()
    {
        CreatePrefab();
    }

    private void CreatePrefab()
    {
        if (Input.touchCount > 0)
        {
            Touch touch = Input.GetTouch(0);
            Debug.Log($"Touch phase : {touch.phase}");
            if (touch.phase == TouchPhase.Began || touch.phase == TouchPhase.Moved)
            {
                Vector2 screenPos = touch.position;
                Ray ray = Camera.main.ScreenPointToRay(screenPos);

                if (raycastManager.Raycast(ray, hits))
                {
                    Vector3 pos = hits[0].pose.position;
                    Quaternion rot = hits[0].pose.rotation;
                    Instantiate(paintPrefab, pos, rot);
                }
            }
        }
    }
}
