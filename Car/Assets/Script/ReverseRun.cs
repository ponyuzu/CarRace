using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ReverseRun : MonoBehaviour {
    [SerializeField]
    GameObject Text;
	[SerializeField]
	Goal goal;

    int pointNumber;//触ったチェックポイントのナンバー
    int oldPointNumber;//さっき触ったポイントのナンバー

	void Start () {
        pointNumber = -1;
        oldPointNumber = -1;
        Text.SetActive(false);
    }
	
	void Update () {
        //もし今触った数字が、前に触った数字より小さかったら逆走している
        if (pointNumber < oldPointNumber || (pointNumber == 6 && oldPointNumber == 0)) {
            Debug.Log("逆走してるよ！！");
            Text.SetActive(true);
			goal.IsReversRun (true);
        }
        else if(pointNumber > oldPointNumber || (pointNumber == 0 && oldPointNumber == 6))
        {
            Text.SetActive(false);
			goal.IsReversRun (false);
        }

        //色々な処理をした後oldを更新する
        oldPointNumber = pointNumber;
    }

    //触った時に呼ぶ関数
    //数字を更新していく
    public void GetCheckPointNumber(int num){
        pointNumber = num;

		if (num == 3) {//今回は直値を入れたけど、本来は全体の個数を管理して計算して出すよ！
			goal.TouchedMidelePoint ();
		}
    }
}
