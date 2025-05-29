using System;
using Platformer.Core;
using Platformer.Mechanics;
using Platformer.Model;
using UnityEngine;

public class Player : KinematicObject
{
    public float speedX = 3;
    public float maxSpeed = 7;
    public float jumpTakeOffSpeed = 7;

    public JumpState jumpState = JumpState.Grounded;
    private bool stopJump;
    public Collider2D collider2d;
    public bool isActive = true;

    bool jump;
    Vector2 move;
    SpriteRenderer spriteRenderer;
    readonly PlatformerModel model = Simulation.GetModel<PlatformerModel>();

    public Bounds Bounds => collider2d.bounds;

    void Awake()
    {
        collider2d = GetComponent<Collider2D>();
        spriteRenderer = GetComponent<SpriteRenderer>();
    }

    public void Jump()
    {
        //if (jumpState == JumpState.Grounded && Input.GetButtonDown("Jump"))
        //    jumpState = JumpState.PrepareToJump;

        jumpState = JumpState.PrepareToJump;
    }

    public void ChangeSpeed(float speedMove)
    {
        speedX = speedMove;
    }

    public void StartRun()
    {
        isActive = true;
    }

    public void StopRun()
    {
        isActive = false;
    }

    #region Base

    protected override void Update()
    {
        if (isActive)
        {
            move.x = speedX;
        }
        else
        {
            move.x = 0;
        }
        UpdateJumpState();
        base.Update();
    }

    private void UpdateJumpState()
    {
        jump = false;
        switch (jumpState)
        {
            case JumpState.PrepareToJump:
                jumpState = JumpState.Jumping;
                jump = true;
                stopJump = false;
                break;
            case JumpState.Jumping:
                if (!IsGrounded)
                {
                    jumpState = JumpState.InFlight;
                }
                break;
            case JumpState.InFlight:
                if (IsGrounded)
                {
                    jumpState = JumpState.Landed;
                }
                break;
            case JumpState.Landed:
                jumpState = JumpState.Grounded;
                break;
        }

        OnChangeJumpState?.Invoke(jumpState);
    }

    protected override void ComputeVelocity()
    {
        if (jump && IsGrounded)
        {
            velocity.y = jumpTakeOffSpeed * model.jumpModifier;
            jump = false;
        }
        else if (stopJump)
        {
            stopJump = false;
            if (velocity.y > 0)
            {
                velocity.y = velocity.y * model.jumpDeceleration;
            }
        }

        if (move.x > 0.01f)
            spriteRenderer.flipX = false;
        else if (move.x < -0.01f)
            spriteRenderer.flipX = true;

        targetVelocity = move * maxSpeed;
    }

    #endregion

    #region Output

    public event Action<JumpState> OnChangeJumpState;

    #endregion
}

public enum JumpState
{
    Grounded,
    PrepareToJump,
    Jumping,
    InFlight,
    Landed
}
