using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Car : MonoBehaviour {

    const float ACCELERATION = 0.005f;//加速度
    const float DECELERATION = -0.003f;//減速度
    const float MAX_SPEED = 0.5f;//マックススピード
    const float MAX_BACK_SPEED = -0.3f;//バックの時のマックススピード
    const float ROT_SPEED = 0.2f;//回転スピード

    Rigidbody rb;
    float speed;//車のスピード
    float backSpeed;
    float rotSpeed;
    bool canControl;//コントロールできるかどうか

    // Use this for initialization
    void Start () {
        speed = 0;
        rb = GetComponent<Rigidbody>();
    }
	
	// Update is called once per frame
	void Update () {

        //コントローラーがオフだったらUpdateを抜けるようにする
        if (canControl == false){
            return;
        }

        //上キーが押されたときかつ、車のスピードがマックススピードより遅かったら
        if (Input.GetKey(KeyCode.UpArrow))  {
            if (speed < MAX_SPEED) {
                speed += ACCELERATION;
            }
        }
        else {//上キーが押されていなかったら減速していく
            if (speed > 0) {
                speed += DECELERATION;
            }
            else {
                speed = 0;
            }
        }

        //上キーと同様
        if (Input.GetKey(KeyCode.DownArrow)){
            if (backSpeed > MAX_BACK_SPEED) {
                backSpeed += DECELERATION;
            }
        }
        else {
            if (backSpeed < 0){
                backSpeed += ACCELERATION;
            }
            else {
                backSpeed = 0;
            }
        }

        Vector3 move = transform.forward * (speed + backSpeed);//青軸にスピードを掛けている
        rb.MovePosition(rb.position + move);//計算して出したスピードを実際に反映させる

        //左右押しているときだけ回転するようにする
        if (Input.GetKey(KeyCode.RightArrow)) {
            Quaternion turnRotation = Quaternion.Euler(0f, ROT_SPEED, 0f);
            rb.MoveRotation(rb.rotation * turnRotation);
        }

        if (Input.GetKey(KeyCode.LeftArrow)) {
            Quaternion turnRotation = Quaternion.Euler(0f, -ROT_SPEED, 0f);
            rb.MoveRotation(rb.rotation * turnRotation);
        }
    }

    public void SetControl(bool setCanControl){
        canControl = setCanControl;
    }
}
