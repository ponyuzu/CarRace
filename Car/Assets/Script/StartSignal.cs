using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class StartSignal : MonoBehaviour {
    [SerializeField]
    GameObject[] signals;
    [SerializeField]
    Car car;

	// Use this for initialization
	void Start () {
        //全て非表示にするよ
        signals[0].SetActive(false);
        signals[1].SetActive(false);
        signals[2].SetActive(false);

        //最初はスタート前なので、コントローラーは切っておく
        car.SetControl(false);

        //1秒待ってから表示
        StartCoroutine(WaitSignal(1, () =>
        {
            signals[2].SetActive(true);
        }));
        //2秒待ってから表示
        StartCoroutine(WaitSignal(2, () =>
        {
            signals[1].SetActive(true);
        }));
        //3秒待ってから表示
        StartCoroutine(WaitSignal(3, () =>
        {
            signals[0].SetActive(true);
            //スタートになったので、コントローラーを使えるようにする
            car.SetControl(true);
        }));

        //表示しっぱなしだと邪魔なので消す
        StartCoroutine(WaitSignal(3.5f, () =>
        {
            //全て非表示にするよ
            signals[0].SetActive(false);
            signals[1].SetActive(false);
            signals[2].SetActive(false);
        }));
    }

    private IEnumerator WaitSignal(float waitTime, Action action) {
        yield return new WaitForSeconds(waitTime);
        action();
    }
}
