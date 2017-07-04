using System.Collections;
using System.Collections.Generic;
using System.Security.Cryptography.X509Certificates;
using DefaultNamespace;
using UnityEngine;

public class StarManager : MonoBehaviour
{
	[SerializeField] private Star[] _stars;
	[SerializeField] private Transform _starSpawnUpperPosition, _starSpawnRightPosition, _starSpawnLeftPosition;
	[SerializeField] private StarDeadLine _stardeadLine;
	[SerializeField] private PlayerScore _score;

	private float _timer = 1.0f;
	// Update is called once per frame
	void Update ()
	{
		_timer -= Time.deltaTime;
		if (_timer < 0f)
		{
			Star star = Instantiate(_stars[0]);
			var speed = Random.Range(DifficultyManager.Parameter.SpeedMin, DifficultyManager.Parameter.SpeedMax) + _score.Score/500f;
			

			star.transform.position = new Vector3(Random.Range(_starSpawnLeftPosition.transform.position.x, _starSpawnRightPosition.position.x),
				_starSpawnUpperPosition.transform.position.y, 0f);
			star.transform.Rotate(Vector3.forward, Random.Range(-180f, 180f));
			star.transform.localScale *= Random.Range(DifficultyManager.Parameter.SizeMin, DifficultyManager.Parameter.SizeMax);
			//star.GetComponent<Rigidbody2D>().AddTorque(Random.Range(5f, 6f)*RandomUnit(), ForceMode2D.Force);
			star.GetComponent<Rigidbody2D>().AddForce(new Vector3(Random.Range(0.1f, 0.2f)*RandomUnit(), 
				-speed, 0f), ForceMode2D.Impulse);
			star.StarDeadLine = _stardeadLine;
			//star.transform.parent = transform;
			_timer = Random.Range(DifficultyManager.Parameter.FreqencyMin, DifficultyManager.Parameter.FreqencyMax);
		}

	}

	int RandomUnit()
	{
		var i = Random.Range(0, 2);
		if (i == 0) return 1;
		return -1;
	}
}
