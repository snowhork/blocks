using System.Collections;
using System.Collections.Generic;
using UniRx;
using UnityEngine;

public class Player : MonoBehaviour
{

	private float _inputForcePower = 0.1f;
	private float _jumpPower = 8f;
	
	private float _maxSpeed = 5f;
	private bool _grounded;

	public bool Grounded
	{
		get { return _grounded; }
	}

	[SerializeField] private Transform[] _lowerBoundsFrom;
	[SerializeField] private Transform[] _lowerBoundsTo;
	[SerializeField] private SpriteRenderer _renderer;
	private ISubject<Unit> _deathSubject;
	
	public IObservable<Unit> OnDeath { get { return _deathSubject; }}


	private void Awake()
	{
		_deathSubject = new Subject<Unit>().AddTo(this);
	}

	// Update is called once per frame
	void FixedUpdate ()
	{
		var rb = GetComponent<Rigidbody2D>();
		if (rb.velocity.magnitude > 10f)
		{
			rb.velocity = rb.velocity.normalized * 10f;
		};
		
//		rb.AddForce(new Vector2(Input.GetAxis("Horizontal")*_inputForcePower, 0), ForceMode2D.Impulse);
//		if (rb.velocity.magnitude >= _maxSpeed)
//		{
//			rb.velocity = rb.velocity.normalized*_maxSpeed;
//		}

		transform.position += Vector3.right*Input.GetAxis("Horizontal")*_inputForcePower;

		if (Input.GetAxis("Horizontal") > 0) transform.eulerAngles = new Vector3(0,180,0);
		if (Input.GetAxis("Horizontal") < 0) transform.eulerAngles = new Vector3(0,0,0);

		_grounded = false;

		for(int i=0; i < _lowerBoundsFrom.Length; i++)
		{
			if (Physics2D.Linecast(_lowerBoundsFrom[i].position, _lowerBoundsTo[i].position, 1 << 8))
			{				
				_grounded = true;
				break;
			};
		}
		//Debug.Log(_grounded);
		if(Input.GetKey(KeyCode.Space) && _grounded) {
			rb.AddForce(new Vector2(0f, _jumpPower), ForceMode2D.Impulse);
		}
	

	}

	public void Death()
	{
		_deathSubject.OnNext(Unit.Default);
		Destroy(gameObject);
		
	}
}
