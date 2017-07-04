using UnityEngine;
using GSSA;

namespace DefaultNamespace
{
    public class RankingManager : MonoBehaviour
    {
        public struct Ranking
        {
            public Ranking(int score, string name)
            {
                Score = score;
                Name = name;
            }

            public int Score;
            public string Name;
        }
        
        
        private static RankingManager _instance;
        private Ranking[,] _rankings;

        public Ranking[,] Rankings
        {
            get { return _rankings; }
        }

        public static RankingManager Instance
        {
            get { return _instance; }
        }        

        // Use this for initialization
        void Awake ()
        {
            _rankings = new Ranking[3,10];
            if (_instance == null)
            {
                _instance = this;
                DontDestroyOnLoad(this);
                RankingManager.Instance.LoadRanking();
        
            }                       
        }        

        public void LoadRanking()
        {
            Debug.Log("Loading...");
            for (int i = 0; i < 3; i++)
            {

                var query = new SpreadSheetQuery("Lv" + i);
                query.OrderByDescending("score").Limit(10);
                var i1 = i;
                query.FindAsync(list =>
                {
                    for(int j =0; j < list.Count; j++)
                    {
                        _rankings[i1, j] = new Ranking(list[j].ParseInt("score"), list[j].ParseString("name"));
                    }
                    Debug.Log("Load Finish");
                });
            }
        }

        public void Register(int score, string playerName, int difficulty)
        {
            var so = new SpreadSheetObject("Lv" + difficulty);
            so["name"] = playerName;
            so["score"] = score.ToString();
            so.SaveAsync();
        }
    }
}