using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SetDifficulty : MonoBehaviour
{

	[SerializeField] private OpenRanking _ranking;
	[SerializeField] private Sprite[] _sprites;
	// Use this for initialization
	void Start ()
	{
		_ranking.Difficulty = DifficultyManager.Instance.Current;
		_ranking.Sprite = _sprites[DifficultyManager.Instance.Current];
		
	}
	
}
