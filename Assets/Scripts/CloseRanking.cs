using UnityEngine;


public class CloseRanking : MonoBehaviour
{
    [SerializeField] private GameObject _scrollView;
    public void Close()
    {
        _scrollView.SetActive(false);
    }
        
}
