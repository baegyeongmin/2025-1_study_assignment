using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Piece : MonoBehaviour
{
    public (int, int) MyPos;    // 자신의 좌표
    public int PlayerDirection = 1; // 자신의 방향 1 - 백, 2 - 흑
    
    public Sprite WhiteSprite;  // 백일 때의 sprite
    public Sprite BlackSprite;  // 흑일 때의 sprite
    
    protected GameManager MyGameManager;
    protected SpriteRenderer MySpriteRenderer;

    void Awake()
    {
        MyGameManager = GameObject.Find("GameManager").GetComponent<GameManager>();
        MySpriteRenderer = GetComponent<SpriteRenderer>();
    }

    // Piece의 초기 설정 함수
    public void initialize((int, int) targetPos, int direction)
    {
        PlayerDirection = direction;
        initSprite(PlayerDirection);
        MoveTo(targetPos);
    }

    // sprite 초기 설정 함수
    void initSprite(int direction)
    {
        // direction에 따라 sprite를 결정하고, 방향을 결정함
        // --- TODO ---
        
        // ------
    }

    // piece의 실제 이동 함수
    public void MoveTo((int, int) targetPos)
    {
        // MyPos를 업데이트하고, targetPos로 이동
        // MyGameManager.Pieces를 업데이트
        // --- TODO ---
        
        // ------
    }
    
    public abstract MoveInfo[] GetMoves();
}
