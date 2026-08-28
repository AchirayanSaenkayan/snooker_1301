using UnityEngine;

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

public class Ball : MonoBehaviour
{
    [SerializeField] private int point;
    [SerializeField] private BallColor color;

    private void Start()
    {
        
    }

    private void Update()
    {
        
    }
}