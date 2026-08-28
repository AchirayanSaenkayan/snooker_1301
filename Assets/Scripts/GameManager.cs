using UnityEngine;

public class GameManager : MonoBehaviour
{
    [SerializeField]
    private int playerScore;
    public int PlayerScore { get { return playerScore; } set { playerScore = value; } }

        [SerializeField]
        private GameObject[] ballPositions;

        [SerializeField]
        private GameObject ballPrefab;

    public static GameManager instance;

    void Awake()
    {
        instance = this;
    }

    void Start()
    {
        SetBall(BallColor.Red, 1);
        SetBall(BallColor.Yellow, 2);
        SetBall(BallColor.Green, 3);
        SetBall(BallColor.Brown, 4);
        SetBall(BallColor.Blue, 5);
        SetBall(BallColor.Pink, 6);
        SetBall(BallColor.Black, 7);
    }

    void Update()
    {

    }

    private void SetBall(BallColor col, int i)
    {
        GameObject obj = Instantiate(ballPrefab, ballPositions[i].transform.position, Quaternion.identity);
        Ball b = obj.GetComponent<Ball>();
        b.SetColorAndPoint(col);
    }
}