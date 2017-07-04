using System.Collections;
using System.Collections.Generic;
using DefaultNamespace;
using UnityEngine;
using UniRx;
using UnityEngine.UI;

public class ScoreUI : MonoBehaviour
{

	[SerializeField] private PlayerScore _score;

	[SerializeField] private Text _text;
	// Use this for initialization
	void Start ()
	{
		_score.OnMaxHeightChanged.Subscribe(score => _text.text = score + " cm");
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
