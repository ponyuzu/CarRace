using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour {
    [SerializeField]
    Transform target;

    const float DISTANCE = 5.2f;//車との距離
    const float FOLLOWRATE = 0.1f;
    Vector3 offset = new Vector3(0f, 2.3f, - DISTANCE);//カメラの場所設定
    Vector3 lookDown = new Vector3(-10f, 0f, 0f);//カメラの見る角度設定

    void Start(){
        transform.position = target.TransformPoint(offset);//カメラの初期位置設定
        transform.LookAt(target, Vector3.up);//設定した方向を見る(向かせる場所、上ベクトル)
    }

    void Update(){
        Vector3 desiredPosition = target.TransformPoint(offset);
        Vector3 lerp = Vector3.Lerp(transform.position, desiredPosition, DISTANCE);
        Vector3 toTarget = target.position - lerp;
        toTarget.Normalize();
        toTarget *= DISTANCE;
        transform.position = target.position - toTarget;
        transform.LookAt(target, Vector3.up);
        transform.Rotate(lookDown);
    }
}
