using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class RaycastDrawer : MonoBehaviour
{
    [SerializeField] GameObject linePrefab;

    
    private float rayDistance = 10f;
    LayerMask planeLayer;
    private LineRenderer lineRenderer;
    public List<LineRenderer> lineList = new List<LineRenderer>();
    public Transform linePool;
    [SerializeField] Image colorDisplayUI;
    [SerializeField] Slider lineScaleController;

    private Color[] colors = new Color[] { Color.red, Color.green, Color.blue };
    private int currentColorIndex = 2;
    private float lineOffset = 0.01f; // plane�� ���� �������� �󸶸�ŭ ��� line�� ������ �� �� ������ offset �� 
    public Vector3 pivotPoint;
    private float scaleOffest = 0.01f;

    private void Start()
    {
        planeLayer = LayerMask.GetMask("Plane");

    }
    private void Update()
    {
        if (Input.touchCount <= 0) 
            return;
        Touch touch = Input.touches[0];

        if (IsTouchingUI(touch))
            return;

        switch (touch.phase)
        {
            case TouchPhase.Began:
            {
                if (Camera.main != null)
                {
                    Ray ray = Camera.main.ScreenPointToRay(touch.position);

                    if(Physics.Raycast(ray, out RaycastHit hitInfo, rayDistance, planeLayer))
                    {
                        pivotPoint = hitInfo.point;
                        DrawStart();
                    }
                }

                break;
            }
            case TouchPhase.Moved:
            case TouchPhase.Stationary:
                DrawStay();
                break;
            case TouchPhase.Ended:
                // ��ġ�� ��������
                break;
            case TouchPhase.Canceled:
                break;
            default:
                throw new ArgumentOutOfRangeException();
        }
    }

    private void DrawStart()
    {
        GameObject line = Instantiate(linePrefab, linePool, true);
        line.transform.position = Vector3.zero;
        line.transform.localScale = new Vector3(1, 1, 1);

        lineRenderer = line.GetComponent<LineRenderer>();
        lineRenderer.positionCount = 1;
        lineRenderer.SetPosition(0, pivotPoint);

        lineRenderer.startColor = colors[currentColorIndex];
        lineRenderer.endColor = colors[currentColorIndex];

        UpdateLineScale();

        lineList.Add(lineRenderer);
    }

    private void DrawStay()
    {
        Ray ray = Camera.main.ScreenPointToRay(Input.touches[0].position);

        if (!Physics.Raycast(ray, out RaycastHit hitInfo, rayDistance, planeLayer)) 
            return;
        Vector3 offsetPosition = hitInfo.point + hitInfo.normal * lineOffset;

        lineRenderer.positionCount++;
        lineRenderer.SetPosition(lineRenderer.positionCount - 1, offsetPosition);
    }

    private bool IsTouchingUI(Touch touch)
    {
        return EventSystem.current.IsPointerOverGameObject(touch.fingerId);
    }


    // �������� ��ɵ�
    public void ChangeColor()
    {
        // OnClick �� ȣ���
        currentColorIndex = (currentColorIndex + 1) % colors.Length;
        colorDisplayUI.color = colors[currentColorIndex];
    }
    public void UpdateLineScale()
    {
        if (lineRenderer != null)
        {
            lineRenderer.startWidth = lineScaleController.value * scaleOffest;
            lineRenderer.endWidth = lineScaleController.value * scaleOffest;
        }
        else
            Debug.Log("lineRenderer�� null �Դϴ�.");
    }

    public void EraseAllLine()
    {
        foreach (LineRenderer line in lineList)
        {
            if (line != null)
                Destroy(line.gameObject);
        }

        lineList.Clear();
    }

    public void Undo()
    {
        if (lineList.Count <= 0)
            return;
        Destroy(lineList[^1].gameObject);
        lineList.RemoveAt(lineList.Count - 1);
    }
}
