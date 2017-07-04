using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SelectDifficulties : MonoBehaviour
{

	[SerializeField] private int _difficulty;
	
	public void Execute()
	{
		DifficultyManager.Instance.Current = _difficulty;
		SceneManager.LoadScene("main");
	}
}
