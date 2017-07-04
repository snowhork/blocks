
using System;
using System.Collections.Generic;
using UniRx;
using UnityEngine;

public class Star : MonoBehaviour
{
    private float _timer = 0f;
    private int _isBounded = 0;
    private static FloatReactiveProperty _maxHeights = new FloatReactiveProperty(0f);
    public static UniRx.IObservable<float> OnMaxHeightsChanged{ get { return _maxHeights; }}
    private StarDeadLine _deadLine;
    [SerializeField] private int _boundNum;

    public StarDeadLine StarDeadLine
    {
        get { return _deadLine; }
        set { _deadLine = value; }
    }

    public static void ResetValue()
    {
        _maxHeights.Value = 0;
    }
        

    [SerializeField] private Sprite _redStarSprite;
    // Update is called once per frame
    void Update ()
    {
        if(_deadLine.transform.position.y > transform.position.y) Destroy(gameObject);
        if(! (_isBounded < _boundNum)) return;
        _timer += Time.deltaTime;
//        if (_timer > 0.2f)
//        {
//            GetComponent<Rigidbody2D>().constraints = RigidbodyConstraints2D.FreezePositionX;
//            GetComponent<Rigidbody2D>().bodyType = RigidbodyType2D.Static;
//        }
//        
//        if (_timer > Random.Range(100f, 101f))
//        {
//            GetComponent<SpriteRenderer>().sprite = _redStarSprite;
//        }
//
    }

    private void OnCollisionEnter2D(Collision2D other)
    {
        if(_isBounded >= _boundNum) return;
        var player = other.collider.GetComponent<Player>();
        if (player)
        {
            player.Death();
            return;
        }
        
        
        if(other.collider.GetComponent<Player>() != null) return;
        
        _isBounded += 1;

        if (_isBounded >= _boundNum)
        {
            GetComponent<Rigidbody2D>().bodyType = RigidbodyType2D.Static;
            GetComponent<Rigidbody2D>().angularDrag = 10f;

            var height = transform.position.y;
            _maxHeights.Value = Mathf.Max(height, _maxHeights.Value);
        }
        //print(_maxHeights);


//        GetComponent<Rigidbody2D>().bodyType = RigidbodyType2D.Static;

    }
}
