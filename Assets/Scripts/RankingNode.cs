using DefaultNamespace;
using UnityEngine;
using UnityEngine.UI;


public class RankingNode : MonoBehaviour
{
    [SerializeField] private Text _name, _score;

    public void SetText(RankingManager.Ranking ranking)
    {
        _name.text = ranking.Name;
        _score.text = ranking.Score + " cm";
    }
}
