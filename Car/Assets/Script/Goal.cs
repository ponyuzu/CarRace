using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Goal : MonoBehaviour {
	[SerializeField]
	GameObject Text;

	bool touchedMiddle;
	bool isReversRun;

	// Use this for initialization
	void Start () {
		touchedMiddle = false;
		isReversRun = false;
	}

	//中間地点に触れたかどうか
	public void TouchedMidelePoint(){
		touchedMiddle = true;
	}

	//逆走しているかの判定を持ってくる
	public void IsReversRun(bool run){
		isReversRun = run;
	}

	//「中間地点に触れた」かつ「逆走してなかったら」ゴールにする
	void OnTriggerEnter(Collider other) {
		Debug.Log (isReversRun);
		Debug.Log (touchedMiddle);

		if (touchedMiddle == true && isReversRun == false) {
			Text.SetActive(true);
		}
	}
}
