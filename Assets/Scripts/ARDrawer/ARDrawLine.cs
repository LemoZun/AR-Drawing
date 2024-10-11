using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ARDrawLine : MonoBehaviour
{
    public Transform pivotPoint;
    public GameObject lineRendererPrefabs;
    private LineRenderer lineRenderer;
    public List<LineRenderer> lineList = new List<LineRenderer>();
    public Transform linePool;

    private Color[] colors = new Color[] {Color.red, Color.green, Color.blue};
    private int currentColorIndex = 0;
    [SerializeField] Image colorDisplayUI;
    [SerializeField] Slider lineScaleController;
    private float scaleOffest = 0.01f;

    public bool onUsing;
    public bool startingLine;

    private float initialLineScale = 0.3f;

    private void Start()
    {
        colorDisplayUI.color = colors[currentColorIndex];
        lineScaleController.value = initialLineScale;
    }


    private void Update()
    {
        if(onUsing)
        {
            if(startingLine)
            {
                DrawLineContinue();
            }
        }
    }

    public void MakeLineRenderer()
    {
        GameObject tLine = Instantiate(lineRendererPrefabs);
        tLine.transform.SetParent(linePool);
        tLine.transform.position = Vector3.zero;
        tLine.transform.localScale = new Vector3(1, 1, 1); // 스케일 조정

        lineRenderer = tLine.GetComponent<LineRenderer>();
        lineRenderer.positionCount = 1;
        lineRenderer.SetPosition(0,pivotPoint.position);


        lineRenderer.startColor = colors[currentColorIndex];
        lineRenderer.endColor = colors[currentColorIndex];

        UpdateLineScale();

        startingLine = true;
        lineList.Add(lineRenderer);
    }

    public void DrawLineContinue()
    {
        lineRenderer.positionCount = lineRenderer.positionCount + 1;
        lineRenderer.SetPosition(lineRenderer.positionCount - 1, pivotPoint.position);
    }

    public void StartDrawLine()
    {
        onUsing = true;
        if(!startingLine)
        {
            MakeLineRenderer();
        }

    }

    public void StopDrawLine()
    {
        onUsing = false;
        startingLine = false;
        lineRenderer = null;
    }

    public void ChangeColor()
    {
        // OnClick 시 호출됨
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
            Debug.Log("lineRenderer가 null 입니다.");

    }

    public void EraseAllLine()
    {
        foreach(LineRenderer line in lineList)
        {
            if(line != null)
                Destroy(line.gameObject);
        }

        lineList.Clear();
    }

    public void Undo()
    {
        if (lineList.Count > 0)
        {
            Destroy(lineList[lineList.Count - 1].gameObject);
            lineList.RemoveAt(lineList.Count - 1);
        }
    }
}
