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
    [SerializeField]
    private BallColor color;

    public void OnPointerClick(PointerEventData eventData)
    {
        Debug.Log(point);
        GameManager.instance.PlayerScore += point;
        Destroy(gameObject);
    }

    private void Start()
    {
        
    }

    private void Update()
    {
        
    }
}