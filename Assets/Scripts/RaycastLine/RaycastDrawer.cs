using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RaycastDrawer : MonoBehaviour
{
    [SerializeField] GameObject linePrefab;

    
    private float rayDistance = 10f;
    LayerMask planeLayer;
    private LineRenderer lineRenderer;
    public List<LineRenderer> lineList = new List<LineRenderer>();
    public Transform linePool;

    private Color[] colors = new Color[] { Color.red, Color.green, Color.blue };
    private int currentColorIndex = 2;
    private float lineOffset = 0.01f; // plane과 수직 방향으로 얼마만큼 띄워 line을 생성해 줄 지 결정할 offset 값 
    public Vector3 pivotPoint;

    private void Start()
    {
        planeLayer = LayerMask.GetMask("Plane");

    }
    private void Update()
    {
        if(Input.touchCount > 0)
        {
            Touch touch = Input.touches[0];

            if (touch.phase == TouchPhase.Began)
            {
                //Vector3 touchPosition = touch.position;
                Ray ray = Camera.main.ScreenPointToRay(touch.position);

                if(Physics.Raycast(ray, out RaycastHit hitInfo, rayDistance, planeLayer))
                {
                    pivotPoint = hitInfo.point;
                    DrawStart();
                }
            }
            else if(touch.phase == TouchPhase.Moved || touch.phase == TouchPhase.Stationary)
            {
                DrawStay();
            }
            else if (touch.phase == TouchPhase.Ended)
            {
                // 터치가 끝났을때
            }
        }
    }

    private void DrawStart()
    {
        GameObject line = Instantiate(linePrefab);
        line.transform.SetParent(linePool);
        line.transform.position = Vector3.zero;
        line.transform.localScale = new Vector3(1, 1, 1);

        lineRenderer = line.GetComponent<LineRenderer>();
        lineRenderer.positionCount = 1;
        lineRenderer.SetPosition(0, pivotPoint);

        lineRenderer.startColor = colors[currentColorIndex];
        lineRenderer.endColor = colors[currentColorIndex];

        lineList.Add(lineRenderer);
    }

    private void DrawStay()
    {
        Ray ray = Camera.main.ScreenPointToRay(Input.touches[0].position);

        if (Physics.Raycast(ray, out RaycastHit hitInfo, rayDistance, planeLayer))
        {
            Vector3 offsetPosition = hitInfo.point + hitInfo.normal * lineOffset;

            lineRenderer.positionCount++;
            lineRenderer.SetPosition(lineRenderer.positionCount - 1, offsetPosition);
        }
    }
}
