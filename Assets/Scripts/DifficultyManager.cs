using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DifficultyManager : MonoBehaviour
{
	private static DifficultyManager _instance;

	public static DifficultyManager Instance
	{
		get { return _instance; }
	}

	[SerializeField] private DifficultyParameter[] _parameters;

	public int Current
	{
		get { return _current; }
		set { _current = value; }
	}

	[SerializeField] private int _current = 0;
	
	public static DifficultyParameter Parameter { get { return _instance._parameters[_instance._current]; }}
	// Use this for initialization
	void Start () {
		if(_instance != null) return;
		_instance = this;
		DontDestroyOnLoad(_instance);
	}
}
