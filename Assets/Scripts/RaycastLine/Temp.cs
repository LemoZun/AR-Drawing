using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Temp
{
    public static void PaintObject(PaintTarget target, Vector3 point, Vector3 normal, Brush brush)
    {
        /*
        if (!target) return; 
        if (!target.validTarget) return; 

        if (splatObject == null)
        {
            splatObject = new GameObject(); 
            splatObject.name = "splatObject"; 
                                             
        }

        splatObject.transform.position = point; // ����Ʈ�� ��ġ�� ������Ʈ�� ��ġ ����

        // ǥ��� ������ ������ ���
        Vector3 leftVec = Vector3.Cross(normal, Vector3.up);
        if (leftVec.magnitude > 0.001f) // leftVec�� ũ�Ⱑ ��ȿ�� ������ ũ��
            splatObject.transform.rotation = Quaternion.LookRotation(leftVec, normal); // ������Ʈ�� ȸ���� ����
        else
            splatObject.transform.rotation = Quaternion.identity; // �׷��� ������ ȸ���� �⺻������ ����

        // ������ �������� �����մϴ�.
        float randScale = Random.Range(brush.splatRandomScaleMin, brush.splatRandomScaleMax); // ������ �������� ����
        splatObject.transform.RotateAround(point, normal, brush.splatRotation); // �־��� ȸ�������� ȸ��
        splatObject.transform.RotateAround(point, normal, Random.Range(-brush.splatRandomRotation, brush.splatRandomRotation)); // ����ȸ���� �ѹ� ��?
        splatObject.transform.localScale = new Vector3(randScale, randScale, randScale) * brush.splatScale; // ������ ����

        // ���ο� Paint ��ü�� �����մϴ�.
        Paint newPaint = new Paint();
        newPaint.paintMatrix = splatObject.transform.worldToLocalMatrix; // ???
        newPaint.channelMask = brush.getMask(); // �귯�� getmask
        newPaint.scaleBias = brush.getTile(); // �귯�� getTile
        newPaint.brush = brush; // ���� �귯�ø� ����

        target.PaintSplat(newPaint); // PaintTarget�� Paint�� ����
    }
    */
    }
}
