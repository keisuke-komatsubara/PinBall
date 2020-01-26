﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FripperTouchcontroller : MonoBehaviour
{
    //HingeJointコンポーネントを入れる
    private HingeJoint myHingeJoint;

    //初期の傾き
    private float defaultAngle = 20;
    //弾いた時の傾き
    private float flickAngle = -20;

    // Use this for initialization
    void Start()
    {
        //HingeJointコンポーネント取得
        this.myHingeJoint = GetComponent<HingeJoint>();

        //フリッパーの傾きを設定
        SetAngle(this.defaultAngle);

    }

    // Update is called once per frame
    void Update()
    {
        if (Input.touchCount > 0)
        {
            for (int i = 0; i < Input.touchCount; i++)
            {
                //タッチ情報を取得
                Touch touch = Input.GetTouch(i);
                //タッチ座標を取得
                float x = touch.position.x;
                float y = touch.position.y;

                if (x <= Screen.width / 2)
                {
                    //左半分をタッチしたとき左フリッパーを動かす
                    if (touch.phase == TouchPhase.Began && tag == "LeftFripperTag")
                    {
                        SetAngle(this.flickAngle);
                    }
                    //左半分を離したとき左フリッパーを元に戻す
                    if (touch.phase == TouchPhase.Ended && tag == "LeftFripperTag")
                    {
                        SetAngle(this.defaultAngle);
                    }
                }
                else if (x >= Screen.width / 2)
                {
                    //右半分をタッチしたとき右フリッパーを動かす
                    if (touch.phase == TouchPhase.Began && tag == "RightFripperTag")
                    {
                        SetAngle(this.flickAngle);
                    }
                    //右半分を離したとき右フリッパーを元に戻す
                    if (touch.phase == TouchPhase.Ended && tag == "RightFripperTag")
                    {
                        SetAngle(this.defaultAngle);
                    }
                }
            }
        }
    }

    //フリッパーの傾きを設定
    public void SetAngle(float angle)
    {
        JointSpring JointSpr = this.myHingeJoint.spring;
        JointSpr.targetPosition = angle;
        this.myHingeJoint.spring = JointSpr;
    }
}

