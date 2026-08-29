using UnityEngine;
using UnityEngine.EventSystems;

public enum BallColor
{
    White,
    Red,
    Yellow,
    Green,
    Brown,
    Blue,
    Pink,
    Black
}

public class Ball : MonoBehaviour, IPointerClickHandler
{
    [SerializeField]
    private int point;
    public int Point { get { return point; } }

    [SerializeField]
    private BallColor color;
    [SerializeField]
    private MeshRenderer rd;

    public void OnPointerClick(PointerEventData eventData)
    {
        Debug.Log(point);
        GameManager.instance.PlayerScore += point;
        Destroy(gameObject);
    }

    void Awake()
    {
        rd = GetComponent<MeshRenderer>();
    }

    private void Start()
    {
        
    }

    private void Update()
    {
        
    }

    public void SetColorAndPoint(BallColor col)
    {
        switch (col)
        {
            case BallColor.White:
                rd.material.color = Color.white;
                point = 0;
                break;
            case BallColor.Red:
                rd.material.color = Color.red;
                point = 1;
                break;
            case BallColor.Yellow:
                rd.material.color = Color.yellow;
                point = 2;
                break;
            case BallColor.Green:
                rd.material.color = Color.green;
                point = 3;
                break;
            case BallColor.Brown:
                rd.material.color = new Color(0.6f, 0.3f, 0f); // แก้สีน้ำตาล
                point = 4;
                break;
            case BallColor.Blue:
                rd.material.color = Color.blue;
                point = 5;
                break;
            case BallColor.Pink:
                rd.material.color = new Color(1f, 0.4f, 0.7f); // แก้สีชมพู
                point = 6;
                break;
            case BallColor.Black:
                rd.material.color = Color.black;
                point = 7;
                break;
        }
    }
}