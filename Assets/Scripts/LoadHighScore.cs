using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using GSSA;

public class LoadHighScore : MonoBehaviour {
	// Use this for initialization
	void Start () {
		var query = new SpreadSheetQuery("Lv0");
		query.OrderByDescending("score").Limit(10);
		query.FindAsync(list => {
			foreach (var so in list)
			{
				Debug.Log(so["name"] + ">" + so["score"]);
			}
		});
	}
}
