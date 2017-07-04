using UnityEngine;
using UnityEngine.UI;

namespace DefaultNamespace
{
    public class RankRegister : MonoBehaviour
    {
        [SerializeField] private Text _text;
        [SerializeField] private PlayerScore _playerScore;

        public void Register()
        {
            RankingManager.Instance.Register(_playerScore.Score, _text.text, DifficultyManager.Instance.Current);
            RankingManager.Instance.LoadRanking();
        }
    }
}