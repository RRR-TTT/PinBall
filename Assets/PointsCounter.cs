using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PointsCounter : MonoBehaviour {
	Material myMaterial;
	// 得点対応表
	Dictionary<string,int> targetPoints = new Dictionary<string,int>(){
		{"SmallStarTag",10},
		{"LargeStarTag",20},
		{"SmallCloudTag",50},
		{"LargeCloudTag",100}
	};

	// 得点
	private int currentPoints = 0;

	// 得点を表示するテキスト
	private GameObject pointsText;

	// Use this for initialization
	void Start () {
		// シーン中の得点textオブジェクトを取得
		this.pointsText = GameObject.Find ("PointsText");
		this.pointsText.GetComponent<Text> ().text = "得点：" + currentPoints.ToString() + "点";
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	// 衝突時に呼ばれる関数
	void OnCollisionEnter(Collision other){
		if (targetPoints.ContainsKey (other.gameObject.tag)) {
			currentPoints += targetPoints [other.gameObject.tag];
			this.pointsText.GetComponent<Text> ().text = "得点：" + currentPoints.ToString() + "点";
		}
	}
}
