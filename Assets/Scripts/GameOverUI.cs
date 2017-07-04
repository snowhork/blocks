using System.Collections;
using System.Collections.Generic;
using DefaultNamespace;
using UnityEngine;
using UnityEngine.UI;
using UniRx;

public class GameOverUI : MonoBehaviour
{

	[SerializeField]
	private Text[] _texts;
	[SerializeField] private Text _bestscore;
	[SerializeField] private Text _sentence;
	[SerializeField] private GameObject _rankin;
	[SerializeField] private GameObject _rankbtn;
	[SerializeField] private PlayerScore _playerScore;

	[SerializeField] private Player _player;
	// Use this for initialization
	void Start ()
	{
		_player.OnDeath.Subscribe(_ =>
		{
			OnGameOver();
		});

	}
	
	// Update is called once per frame
	void OnGameOver () {
		
		foreach (var text in _texts)
		{
			text.enabled = true;		
		}
		_sentence.enabled = true;
		_rankbtn.SetActive(true);
		int lowerScore = RankingManager.Instance.Rankings[DifficultyManager.Instance.Current, 9].Score;
		if (_playerScore.Score > lowerScore)
		{
			_rankin.SetActive(true);
			_sentence.text = " Rank IN !";
		}
		else
		{
			_sentence.text = "Press Space Key";
		}
		//_bestscore.text = _playerScore.BestScore + " cm";
	}
}
