using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAnimation : MonoBehaviour
{
    PlayerActionManager playerActionManager;
    PlayerManager playerManager;
    SpriteRenderer sprite;
    Animator playerAnimator;
    public string currentAnimation = "PlayerIdle";
    string[] directions = { "Left", "Right" };
    public string currentDirection = "Right";
    void Awake()
    {
        playerActionManager = GetComponent<PlayerActionManager>();
        playerManager = GetComponent<PlayerManager>();
        sprite = GetComponentInChildren<SpriteRenderer>();
        playerAnimator = GetComponentInChildren<Animator>();
    }

    void PlayAnimation(string newAnimation)
    {
        if (currentAnimation == newAnimation) { return; }
        currentAnimation = newAnimation;
        playerAnimator.Play(currentAnimation);
    }

    public void SetDirection(string direction) 
    { 
        currentDirection = direction; 
        if(direction == "Right") { sprite.flipX = false; }
        else { sprite.flipX = true; }
    }
    public void SetAnimation(string animation) { playerAnimator.Play(animation); }

    public void HandlePlayerMoveAnimation()
    {
        if(Mathf.Abs(playerActionManager.moveValue.x) > 0) { SetAnimationMove(); }
        else { SetAnimationIdle(); }
    }

    public void SetAnimationMove()
    {
            if (playerActionManager.moveValue.x > 0) {  SetAnimationMoveRight(); }
            else { SetAnimationMoveLeft(); }
    }
    public void SetAnimationIdle()
    {
            if(currentDirection == "Left") { SetAnimationIdleLeft(); }
            else { SetAnimationIdleRight(); }
    }

    public void SetAnimationMoveRight()
    {
        if (playerActionManager.moveValue.x > 0) { sprite.flipX = false; }
        currentDirection = directions[1];
        PlayAnimation("PlayerMove");
    }

    public void SetAnimationMoveLeft()
    {
        if (playerActionManager.moveValue.x < 0) { sprite.flipX = true; }
        currentDirection = directions[0];
        PlayAnimation("PlayerMove");
    }

    public void SetAnimationIdleRight()
    {
        if (playerActionManager.moveValue.x == 0 && currentDirection == directions[1]) 
        { 
            sprite.flipX = false;         
            currentDirection = directions[1];
            PlayAnimation("PlayerIdle");
        }

    }
    public void SetAnimationIdleLeft()
    {
        if (playerActionManager.moveValue.x == 0 && currentDirection == directions[0]) 
        { 
            sprite.flipX = true;
            currentDirection = directions[0];
            PlayAnimation("PlayerIdle"); 
        }

    }

}
