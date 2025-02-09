using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ARDrawLine : MonoBehaviour
{
    public Transform pivotPoint;
    public GameObject linePrefabs;
    private LineRenderer lineRenderer;
    public List<LineRenderer> lineList = new List<LineRenderer>();
    public Transform linePool;

    private readonly Color[] colors = {Color.red, Color.green, Color.blue};
    private int currentColorIndex = 0;
    [SerializeField] private Image colorDisplayUI;
    [SerializeField] private Slider lineScaleController;
    private const float ScaleOffset = 0.01f;

    public bool onUsing;
    public bool startingLine;

    private const float InitialLineScale = 0.3f;

    private void Start()
    {
        colorDisplayUI.color = colors[currentColorIndex];
        lineScaleController.value = InitialLineScale;
    }


    private void Update()
    {
        if (!onUsing) 
            return;
        if(startingLine)
        {
            DrawLineContinue();
        }
    }

    public void MakeLineRenderer()
    {
        GameObject tLine = Instantiate(linePrefabs, linePool, true);
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
        lineRenderer.positionCount += 1;
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
            lineRenderer.startWidth = lineScaleController.value * ScaleOffset;
            lineRenderer.endWidth = lineScaleController.value * ScaleOffset;
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
        if (lineList.Count <= 0) 
            return;
        Destroy(lineList[^1].gameObject);
        lineList.Remove(lineList[^1]);
    }
}
