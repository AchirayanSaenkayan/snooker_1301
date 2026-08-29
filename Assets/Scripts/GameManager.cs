using UnityEngine;
using UnityEngine.InputSystem;
using TMPro;

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

    [SerializeField] private GameObject redBall;
    [SerializeField] private GameObject yellowBall;
    [SerializeField] private GameObject greenBall;
    [SerializeField] private GameObject brownBall;
    [SerializeField] private GameObject blueBall;
    [SerializeField] private GameObject pinkBall;
    [SerializeField] private GameObject blackBall;

    [SerializeField]
    private float xInput = 0f;

    [SerializeField]
    private GameObject ballLine;

    [SerializeField]
    private GameObject cam;

    [SerializeField]
    private TMP_Text notiText;

    public static GameManager instance;

    void Awake()
    {
        instance = this;
    }

    void Start()
    {
        CameraBehindCueBall();

        if (Settings.fromSave)
        {
            LoadGame();
        }
        else
        {
            SpawnAllDefaultBalls();
        }
    }

    void Update()
    {
        if (Keyboard.current.spaceKey.wasPressedThisFrame)
            ShootBall();

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

    private void SpawnAllDefaultBalls()
    {
        redBall = SetBall(BallColor.Red, 1);
        yellowBall = SetBall(BallColor.Yellow, 2);
        greenBall = SetBall(BallColor.Green, 3);
        brownBall = SetBall(BallColor.Brown, 4);
        blueBall = SetBall(BallColor.Blue, 5);
        pinkBall = SetBall(BallColor.Pink, 6);
        blackBall = SetBall(BallColor.Black, 7);
    }

    private GameObject SetBall(BallColor col, int i)
    {
        GameObject obj = Instantiate(ballPrefab, ballPositions[i].transform.position, Quaternion.identity);
        Ball b = obj.GetComponent<Ball>();
        b.SetColorAndPoint(col);
        return obj;
    }

    private GameObject SetBallAtPos(BallColor col, Vector3 pos)
    {
        GameObject obj = Instantiate(ballPrefab, pos, Quaternion.identity);
        Ball b = obj.GetComponent<Ball>();
        b.SetColorAndPoint(col);
        return obj;
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

    public void ShowScore(int n)
    {
        playerScore += n;
        if (notiText != null)
            notiText.text = $"Ball Point: {n}\nTotal Score: {playerScore}";
    }

    public void ShowString(string s)
    {
        if (notiText != null)
            notiText.text = s;
    }

    public void SaveGame()
    {
        StopBall();

        if (cueBall != null)
        {
            PlayerPrefs.SetFloat("cueBallPosX", cueBall.transform.position.x);
            PlayerPrefs.SetFloat("cueBallPosY", cueBall.transform.position.y);
            PlayerPrefs.SetFloat("cueBallPosZ", cueBall.transform.position.z);
        }

        if (redBall != null)
        {
            PlayerPrefs.SetFloat("redBallPosX", redBall.transform.position.x);
            PlayerPrefs.SetFloat("redBallPosY", redBall.transform.position.y);
            PlayerPrefs.SetFloat("redBallPosZ", redBall.transform.position.z);
        }

        if (yellowBall != null)
        {
            PlayerPrefs.SetFloat("yellowBallPosX", yellowBall.transform.position.x);
            PlayerPrefs.SetFloat("yellowBallPosY", yellowBall.transform.position.y);
            PlayerPrefs.SetFloat("yellowBallPosZ", yellowBall.transform.position.z);
        }

        if (greenBall != null)
        {
            PlayerPrefs.SetFloat("greenBallPosX", greenBall.transform.position.x);
            PlayerPrefs.SetFloat("greenBallPosY", greenBall.transform.position.y);
            PlayerPrefs.SetFloat("greenBallPosZ", greenBall.transform.position.z);
        }

        if (brownBall != null)
        {
            PlayerPrefs.SetFloat("brownBallPosX", brownBall.transform.position.x);
            PlayerPrefs.SetFloat("brownBallPosY", brownBall.transform.position.y);
            PlayerPrefs.SetFloat("brownBallPosZ", brownBall.transform.position.z);
        }

        if (blueBall != null)
        {
            PlayerPrefs.SetFloat("blueBallPosX", blueBall.transform.position.x);
            PlayerPrefs.SetFloat("blueBallPosY", blueBall.transform.position.y);
            PlayerPrefs.SetFloat("blueBallPosZ", blueBall.transform.position.z);
        }

        if (pinkBall != null)
        {
            PlayerPrefs.SetFloat("pinkBallPosX", pinkBall.transform.position.x);
            PlayerPrefs.SetFloat("pinkBallPosY", pinkBall.transform.position.y);
            PlayerPrefs.SetFloat("pinkBallPosZ", pinkBall.transform.position.z);
        }

        if (blackBall != null)
        {
            PlayerPrefs.SetFloat("blackBallPosX", blackBall.transform.position.x);
            PlayerPrefs.SetFloat("blackBallPosY", blackBall.transform.position.y);
            PlayerPrefs.SetFloat("blackBallPosZ", blackBall.transform.position.z);
        }

        PlayerPrefs.Save();
        Debug.Log("Saved Successfully!");
    }

    private void LoadGame()
    {
        // เช็กถ้าไม่มีข้อมูลเซฟเดิมเลย ให้สร้างตามค่าตั้งต้นแทน
        if (!PlayerPrefs.HasKey("cueBallPosX"))
        {
            SpawnAllDefaultBalls();
            return;
        }

        if (cueBall != null)
        {
            float x = PlayerPrefs.GetFloat("cueBallPosX");
            float y = PlayerPrefs.GetFloat("cueBallPosY");
            float z = PlayerPrefs.GetFloat("cueBallPosZ");
            cueBall.transform.position = new Vector3(x, y, z);
        }

        if (PlayerPrefs.HasKey("redBallPosX"))
            redBall = SetBallAtPos(BallColor.Red, new Vector3(PlayerPrefs.GetFloat("redBallPosX"), PlayerPrefs.GetFloat("redBallPosY"), PlayerPrefs.GetFloat("redBallPosZ")));

        if (PlayerPrefs.HasKey("yellowBallPosX"))
            yellowBall = SetBallAtPos(BallColor.Yellow, new Vector3(PlayerPrefs.GetFloat("yellowBallPosX"), PlayerPrefs.GetFloat("yellowBallPosY"), PlayerPrefs.GetFloat("yellowBallPosZ")));

        if (PlayerPrefs.HasKey("greenBallPosX"))
            greenBall = SetBallAtPos(BallColor.Green, new Vector3(PlayerPrefs.GetFloat("greenBallPosX"), PlayerPrefs.GetFloat("greenBallPosY"), PlayerPrefs.GetFloat("greenBallPosZ")));

        if (PlayerPrefs.HasKey("brownBallPosX"))
            brownBall = SetBallAtPos(BallColor.Brown, new Vector3(PlayerPrefs.GetFloat("brownBallPosX"), PlayerPrefs.GetFloat("brownBallPosY"), PlayerPrefs.GetFloat("brownBallPosZ")));

        if (PlayerPrefs.HasKey("blueBallPosX"))
            blueBall = SetBallAtPos(BallColor.Blue, new Vector3(PlayerPrefs.GetFloat("blueBallPosX"), PlayerPrefs.GetFloat("blueBallPosY"), PlayerPrefs.GetFloat("blueBallPosZ")));

        if (PlayerPrefs.HasKey("pinkBallPosX"))
            pinkBall = SetBallAtPos(BallColor.Pink, new Vector3(PlayerPrefs.GetFloat("pinkBallPosX"), PlayerPrefs.GetFloat("pinkBallPosY"), PlayerPrefs.GetFloat("pinkBallPosZ")));

        if (PlayerPrefs.HasKey("blackBallPosX"))
            blackBall = SetBallAtPos(BallColor.Black, new Vector3(PlayerPrefs.GetFloat("blackBallPosX"), PlayerPrefs.GetFloat("blackBallPosY"), PlayerPrefs.GetFloat("blackBallPosZ")));
    }   
}