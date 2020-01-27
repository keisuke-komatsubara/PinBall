using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Ballcontroller : MonoBehaviour {

    //SmallStarの得点
    public int smallstarpoint = 10;
    //LargeStarの得点
    public int largestarpoint = 20;
    //SmallCloudの得点
    public int smallcloudpoint = 30;
    //LargeCloudの得点
    public int largecloudpoint = 50;

    private GameObject ScoreText;
    private int scorenum = 0;

    //衝突時に呼び出される関数
    void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "SmallStarTag")
        {
            scorenum += this.smallstarpoint;
        }
        else if (collision.gameObject.tag == "LargeStarTag")
        {
            scorenum += this.largestarpoint;
        }
        else if (collision.gameObject.tag == "SmallCloudTag")
        {
            scorenum += this.smallcloudpoint;
        }
        else if (collision.gameObject.tag == "LargeCloudTag")
        {
            scorenum += this.largecloudpoint;
        }
    }
    
    //ボールが見える可能性のあるz軸の最大値
    private float visiblePosZ = -6.5f;

    //ゲームオーバを表示するテキスト
    private GameObject gameoverText;

    // Use this for initialization
    void Start()
    {
        //シーン中のGameOvertextオブジェクトを取得
        this.gameoverText = GameObject.Find("GameOverText");

        //シーン中のScoreTextオブジェクトを取得
        this.ScoreText = GameObject.Find("ScoreText");
    }
    // Update is called once per frame
    void Update()
    {
        //Scoreを表示する
        this.ScoreText.GetComponent<Text>().text = "SCOORE:" + scorenum;

        //ボールが画面外に出た場合
        if (this.transform.position.z < this.visiblePosZ)
        {
            //GameoverTextにゲームオーバーを表示
            this.gameoverText.GetComponent<Text>().text = "Game Over";
        }
    }
}



