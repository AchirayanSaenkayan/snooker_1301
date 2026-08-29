using UnityEngine;
using UnityEngine.InputSystem;

public class GameManager : MonoBehaviour
{
    [SerializeField]
    private int playerScore;
    public int PlayerScore { get { return playerScore; } set { playerScore = value; } }

    [SerializeField]
    private GameObject[] ballPositions;

    [SerializeField]
    private GameObject ballPrefab;

    [SerializeField]
    private GameObject cueBall;

    [SerializeField]
    private float xInput = 0f;

    [SerializeField]
    private GameObject ballLine;

    [SerializeField]
    private GameObject cam;

    public static GameManager instance;

    void Awake()
    {
        instance = this;
    }

    void Start()
    {
        CameraBehindCueBall();

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
        if (Keyboard.current.spaceKey.wasPressedThisFrame)
            ShootBall();

        // เช็กการกดปุ่มเล็งซ้าย-ขวา
        if (Keyboard.current.aKey.isPressed || Keyboard.current.leftArrowKey.isPressed)
            xInput = -1f;
        else if (Keyboard.current.dKey.isPressed || Keyboard.current.rightArrowKey.isPressed)
            xInput = 1f;
        else
            xInput = 0f;

        if (Keyboard.current.sKey.wasPressedThisFrame || Keyboard.current.backspaceKey.wasPressedThisFrame)
            StopBall();

        RotateBall();
    }

    private void SetBall(BallColor col, int i)
    {
        GameObject obj = Instantiate(ballPrefab, ballPositions[i].transform.position, Quaternion.identity);
        Ball b = obj.GetComponent<Ball>();
        b.SetColorAndPoint(col);
    }

    private void ShootBall()
    {
        Rigidbody rd = cueBall.GetComponent<Rigidbody>();
        rd.AddRelativeForce(Vector3.forward * 50, ForceMode.Impulse);

        if (ballLine != null)
            ballLine.SetActive(false);

        cam.transform.parent = null;
        cam.transform.position = new Vector3(0f, 30f, -42f);
        cam.transform.eulerAngles = new Vector3(45f, 0f, 0f);
    }

    private void RotateBall()
    {
        if (cueBall != null && xInput != 0f)
        {
            cueBall.transform.Rotate(0f, xInput * 50f * Time.deltaTime, 0f);
        }
    }

    private void StopBall()
    {
        Rigidbody rd = cueBall.GetComponent<Rigidbody>();
        
        rd.linearVelocity = Vector3.zero;
        rd.angularVelocity = Vector3.zero;
        cueBall.transform.eulerAngles = new Vector3(0f, 0f, 0f);

        if (ballLine != null)
            ballLine.SetActive(true);

        CameraBehindCueBall();
    }

    private void CameraBehindCueBall()
    {
        if (cam != null && cueBall != null)
        {
            cam.transform.parent = cueBall.transform;
            cam.transform.position = cueBall.transform.position + new Vector3(0f, 7f, -15f);
            cam.transform.eulerAngles = new Vector3(30f, 0f, 0f);
        }
    }
}