using System.Collections;
using System.Collections.Generic;
using DefaultNamespace;
using UnityEngine;
using UnityEngine.UI;
using UniRx;
using UnityEngine.SceneManagement;

public class GameOver : MonoBehaviour
{

	[SerializeField] private Player _player;
	[SerializeField] private PlayerScore _playerScore;
	[SerializeField] private Reset _reset;
	
	private bool _gameover;

	private float _timer;
	// Use this for initialization
	void Start ()
	{
		_player.OnDeath.Subscribe(_ =>
		{
			_gameover = true;
			RankingManager.Instance.LoadRanking();
		
		});

	}

	void Update()
	{
		if(!_gameover) return;
		_timer += Time.deltaTime;
		if(_timer < 0.4f) return;
		

		if(!Input.GetKeyDown(KeyCode.Space)) return;
		int lowerScore = RankingManager.Instance.Rankings[DifficultyManager.Instance.Current, 9].Score;
		if (_playerScore.Score > lowerScore)
		{
				return;
		}
		
		_reset.Execute();

	}
}
