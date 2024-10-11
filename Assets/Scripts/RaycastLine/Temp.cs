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

        splatObject.transform.position = point; // 페인트할 위치로 오브젝트의 위치 설정

        // 표면과 수직한 방향을 계산
        Vector3 leftVec = Vector3.Cross(normal, Vector3.up);
        if (leftVec.magnitude > 0.001f) // leftVec의 크기가 유효할 정도로 크면
            splatObject.transform.rotation = Quaternion.LookRotation(leftVec, normal); // 오브젝트의 회전을 설정
        else
            splatObject.transform.rotation = Quaternion.identity; // 그렇지 않으면 회전을 기본값으로 설정

        // 랜덤한 스케일을 설정합니다.
        float randScale = Random.Range(brush.splatRandomScaleMin, brush.splatRandomScaleMax); // 랜덤한 스케일을 설정
        splatObject.transform.RotateAround(point, normal, brush.splatRotation); // 주어진 회전값으로 회전
        splatObject.transform.RotateAround(point, normal, Random.Range(-brush.splatRandomRotation, brush.splatRandomRotation)); // 랜덤회전을 한번 더?
        splatObject.transform.localScale = new Vector3(randScale, randScale, randScale) * brush.splatScale; // 스케일 설정

        // 새로운 Paint 객체를 생성합니다.
        Paint newPaint = new Paint();
        newPaint.paintMatrix = splatObject.transform.worldToLocalMatrix; // ???
        newPaint.channelMask = brush.getMask(); // 브러시 getmask
        newPaint.scaleBias = brush.getTile(); // 브러시 getTile
        newPaint.brush = brush; // 사용된 브러시를 설정

        target.PaintSplat(newPaint); // PaintTarget에 Paint를 적용
    }
    */
    }
}
