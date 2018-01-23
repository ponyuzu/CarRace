using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CarAI : MonoBehaviour {
    const float ACCELERATION = 0.005f;//加速度
    const float DECELERATION = -0.003f;//減速度
    const float MAX_SPEED = 0.5f;//マックススピード

    float speed;//車のスピード
    float backSpeed;
    Rigidbody rb;
    // Use this for initialization
    void Start () {
        speed = 0;
        rb = GetComponent<Rigidbody>();
    }
	
	// Update is called once per frame
	void Update () {
        if (speed < MAX_SPEED)
        {
            speed += ACCELERATION;
        }

        Vector3 move = transform.forward * (speed + backSpeed);//青軸にスピードを掛けている
        rb.MovePosition(rb.position + move);//計算して出したスピードを実際に反映させる
    }
}
