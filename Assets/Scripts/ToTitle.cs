using System;
using System.Collections;
using System.Collections.Generic;
using UniRx;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ToTitle : MonoBehaviour {

	public void Execute()
	{		
		Observable.Return(Unit.Default).Delay(TimeSpan.FromSeconds(0.1f)).Subscribe(_ =>
		{
			Star.ResetValue();		
			SceneManager.LoadScene("title");
		});
	}
}
