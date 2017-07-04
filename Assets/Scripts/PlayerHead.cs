using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHead : MonoBehaviour
{
	// Use this for initialization
	public void Death()
	{
		Destroy(transform.parent.gameObject);
	}
}
