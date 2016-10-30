using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System;

public class GameManeger : MonoBehaviour {

	List<int> ageList = new List<int>(); //平均を求める年齢のリスト
	float averageAge = 0; // 平均年齢
	float averageInAguri = 0; //アグリを入れた平均年齢
	int aguriAge = 27; //アグリの年齢


	public static GameManeger instance = null;
	// シングルトン+シーン遷移をしても消さない処理
	void Awake(){
		if (instance == null) {
			instance = this;
			DontDestroyOnLoad (this.gameObject);
		} else {
			Destroy (this.gameObject);
		}
	}

	// 誕生日と現在の日付から年齢を計算する
	public int AguriAge{
		get{
			DateTime dtToday = DateTime.Today;
			aguriAge = dtToday.Year - AGURIBIRTHDAY.YEAR;
			if (dtToday.Month < AGURIBIRTHDAY.MONTH) {
				aguriAge -= 1;
				return aguriAge;
			} else if (dtToday.Month > AGURIBIRTHDAY.MONTH) {
				return aguriAge;
			} else {
				if (dtToday.Day >= AGURIBIRTHDAY.DAY) {
					return aguriAge;
				} else {
					aguriAge -= 1;
					return aguriAge;
				}
			}
			return aguriAge;
		}

	}
		
	public float AverageAge{
		get{
			CalculateAverage ();
			return averageAge;
		}
	}
	public float AverageInAguri{
		get{
			CalculateAverage ();
			return averageInAguri;
		}
	}
		
	public void AddAge(int input){
		ageList.Add (input);
	}

	public void FinishInput(){
		CalculateAverage ();
	}

	public void ClearResult(){
		averageAge = 0;
		averageInAguri = 0;
		ageList.Clear ();
	}

	// 平均年齢を計算する
	void CalculateAverage(){
		int count = ageList.Count;
		if (count <= 0) {
			return;
		}
		int sum = 0;
		foreach (int age in ageList) {
			sum += age;
		}
		averageAge = ((float)sum) / count;
		int sumInAguri = sum + AguriAge;
		averageInAguri = ((float)sumInAguri) / (count + 1);
	}
}
