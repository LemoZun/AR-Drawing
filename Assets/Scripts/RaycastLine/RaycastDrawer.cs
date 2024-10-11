using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RaycastDrawer : MonoBehaviour
{
    [SerializeField] LineRenderer linePrefab;
    private LineRenderer line;
    private float rayDistance = 10f;
    LayerMask planeLayer;

    private Color[] colors = new Color[] { Color.red, Color.green, Color.blue };
    private int currentColorIndex = 2;
    private float lineOffset = 0.01f; // plane과 수직 방향으로 얼마만큼 띄워 line을 생성해 줄 지 결정할 offset 값 

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
                DrawStart();
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
        line = Instantiate(linePrefab, Vector3.zero, Quaternion.identity);
        line.positionCount = 0;

        line.startColor = colors[currentColorIndex];
        line.endColor = colors[currentColorIndex];
    }

    private void DrawStay()
    {
        Ray ray = Camera.main.ScreenPointToRay(Input.touches[0].position);

        if (Physics.Raycast(ray, out RaycastHit hitInfo, rayDistance, planeLayer))
        {
            Vector3 offsetPosition = hitInfo.point + hitInfo.normal * lineOffset;

            line.positionCount++;
            line.SetPosition(line.positionCount - 1, offsetPosition);
        }
    }
}
