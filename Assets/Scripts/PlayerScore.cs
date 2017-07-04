using UnityEngine;
using UniRx;

namespace DefaultNamespace
{
    public class PlayerScore : MonoBehaviour
    {
        [SerializeField] private Player _player;
        [SerializeField] private Renderer _backGround;
        private IntReactiveProperty _maxHeight;

        public int BestScore
        {
            get { return _bestScore; }
        }
        
        
        public int Score
        {
            get { return _maxHeight.Value; }
        }


        private int _bestScore;
        
        public IObservable<int> OnMaxHeightChanged
        {
            get { return _maxHeight; }
        }

        private void Awake()
        {
            _maxHeight = new IntReactiveProperty();
            _bestScore = PlayerPrefs.GetInt("bestScore" + DifficultyManager.Instance.Current, 0);                
        }

        private void Start()
        {
            _player.OnDeath.Subscribe(_ =>
            {                
                PlayerPrefs.SetInt("bestScore" + DifficultyManager.Instance.Current, _bestScore);
            });
        }

        private void Update()
        {
            if (_player.Grounded)
            {
                _maxHeight.Value = Mathf.Max(_maxHeight.Value, (int)(transform.position.y*100));
                _bestScore = Mathf.Max(_maxHeight.Value, _bestScore);
                
            }
        }
    }
}