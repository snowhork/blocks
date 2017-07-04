using UnityEngine;
using UniRx;

public class CameraMove : MonoBehaviour
{

	private float _targetY = 0f;
	private float _startY;

	[SerializeField] private Renderer _backGround;
	// Use this for initialization
	void Start ()
	{
		_startY = transform.position.y;
		transform.position = new Vector3(transform.position.x, _startY, transform.position.z);
		_targetY = _startY;
		
		Star.OnMaxHeightsChanged.Subscribe(height =>
		{
			_targetY = _startY + height;
		});
	}

	void Update()
	{
		transform.position = Vector3.Lerp(transform.position, new Vector3(transform.position.x, _targetY, transform.position.z), 0.0035f);
		_backGround.material.SetFloat("_Height", (transform.position.y-_startY)*100);
	}

}
