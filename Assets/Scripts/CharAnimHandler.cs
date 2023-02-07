using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharAnimHandler : MonoBehaviour
{

    [Header("Handles Sprites")]
    [SerializeField] public Sprite[] playerSprites;
    [HideInInspector] public Sprite playerIdle;
    [HideInInspector] public Sprite playerRunning;
    [HideInInspector] public Sprite playerJumping;
    [HideInInspector] public Sprite playerAttack;

    [SerializeField] public PlayerType player;

    [HideInInspector] public SpriteRenderer currentSprite;

    void Start()
    {
        currentSprite = GetComponent<SpriteRenderer>();
        SetSpritesAndAnimations();
        SetIdle();
    }

    public void SetIdle()
    {
        currentSprite.sprite = playerIdle;
    }

    public void SetRunning()
    {
        currentSprite.sprite = playerRunning;
    }

    public void SetJumping()
    {
        currentSprite.sprite = playerJumping;
    }

    public void SetAttack()
    {
        currentSprite.sprite = playerAttack;
    }

    public void SetSpritesAndAnimations()
    {
        switch (player.charType)
        {
            case Char.CARROT:
                playerIdle = playerSprites[0]; 
                playerRunning = playerSprites[1]; 
                playerJumping = playerSprites[0]; 
                playerAttack = playerSprites[2]; 
                break;
            case Char.POTATO:
                playerIdle = playerSprites[3]; 
                playerRunning = playerSprites[4]; 
                playerJumping = playerSprites[5]; 
                playerAttack = playerSprites[6]; 
                break;
            case Char.TURNIP:
                playerIdle = playerSprites[7]; 
                playerRunning = playerSprites[8]; 
                playerJumping = playerSprites[7]; 
                playerAttack = playerSprites[9]; 
                break;
        }
    }


}
