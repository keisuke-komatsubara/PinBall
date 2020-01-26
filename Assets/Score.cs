using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Score : MonoBehaviour {

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

    // Use this for initialization
    void Start () {
        this.ScoreText = GameObject.Find("ScoreText");
    }
	
	// Update is called once per frame
	void Update () {
        //Scoreを表示する
        this.ScoreText.GetComponent<Text>().text = "SCOORE:" + scorenum;
	}
}
