using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;

    [SerializeField] private int playerScore;

    public int PlayerScore
    {
        get { return playerScore; }
        set { playerScore = value; }
    }

    private void Awake()
    {
        instance = this;
    }

    private void Start()
    {

    }
}