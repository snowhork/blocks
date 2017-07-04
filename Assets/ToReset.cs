using System;
using System.Collections;
using System.Collections.Generic;
using UniRx;
using UnityEngine;

public class ToReset : MonoBehaviour
{

	[SerializeField] private Reset _reset;

	public void DoReset()
	{
		Observable.Return(Unit.Default).Delay(TimeSpan.FromSeconds(0.3f)).Subscribe(_ => _reset.Execute());
	}
}
