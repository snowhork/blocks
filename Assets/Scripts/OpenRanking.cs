using DefaultNamespace;
using UnityEngine;
using UnityEngine.UI;

public class OpenRanking : MonoBehaviour
{
    [SerializeField] private GameObject _scrollView;
    [SerializeField] private RankingNode[] _nodes;
    [SerializeField] private Sprite _sprite;

    public Sprite Sprite
    {
        get { return _sprite; }
        set { _sprite = value; }
    }

    public int Difficulty
    {
        get { return _difficulty; }
        set { _difficulty = value; }
    }

    [SerializeField] private Image _image;
    
    [SerializeField] private int _difficulty;

    public void Open()
    {
        _scrollView.SetActive(true);
        var rankings = RankingManager.Instance.Rankings;
        _image.sprite = _sprite;

        for (int i = 0; i < 10; i++)
        {
            _nodes[i].SetText(rankings[_difficulty, i]);
        }
    }
    
}
