using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    private Vector2 PlayerStartPos;
    private Vector2 PlayerEndPos;
    private Vector2 MouseStartPos;
    private Vector2 MouseEndPos;
    private float xDiff;
    private float yDiff;
    public bool IsPlayerControllable;
    public float Scalar;
    // Start is called before the first frame update
    void Start()
    {
        IsPlayerControllable = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            IsPlayerControllable = true;
            MouseStartPos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            PlayerStartPos = transform.position;
            
        }else if (Input.GetMouseButtonUp(0))
        {
            IsPlayerControllable = false;
        }
        if(IsPlayerControllable)
        {
            MouseEndPos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            xDiff = (MouseEndPos.x - MouseStartPos.x) * Scalar;
            yDiff = (MouseEndPos.y - MouseStartPos.y) * Scalar;
            PlayerEndPos = new Vector2(PlayerStartPos.x + xDiff, PlayerStartPos.y + yDiff);
            transform.position = Vector2.Lerp(transform.position, PlayerEndPos, 0.2f);
        }
        float xPos = Mathf.Clamp(transform.position.x, -4f, 4f);
        float yPos = Mathf.Clamp(transform.position.y, -2f, 2f);
        transform.position = new Vector3(xPos, yPos, 0);
    }
}
