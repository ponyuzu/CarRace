using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CheckPoint : MonoBehaviour {
    [SerializeField]
    int myNumber;//自分が何番目かを入れる

    ReverseRun reversRun;

    void Start () {
        GameObject checkPoints = GameObject.Find("CheckPoints");//Hierarchyにある「CheckPoints」オブジェクトを探す
        reversRun = checkPoints.GetComponent<ReverseRun>();//「CheckPoints」オブジェクトにある「ReverseRun」クラスを取得する
    }

    //何かに当たった時反応する関数
    void OnTriggerEnter(Collider other) {
        reversRun.GetCheckPointNumber(myNumber);//先ほど作った数字を更新していく関数に自分の数字を入れる
    }
}
