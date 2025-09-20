using Godot;
using System;

public partial class Player : CharacterBody2D
{
	public PlayerState CurrentState;

	public PlayerStateMove MoveState;
	public PlayerStateJump JumpState;
	public PlayerStateIdle IdleState;
	public PlayerStateBrake BrakeState;
	public PlayerStateFall FallState;
	public PlayerStateJumpPreparation JumpPreparationState;

	public enum ControlScheme { P1, P2, CPU };

	public AnimationPlayer PlayerAnimation;
	private Sprite2D _playeSprite;
	private Node2D _stateMachine;

	public ControlScheme CurrentControlScheme;
	public Vector2 Heading = Vector2.Right;

	public float NormalSpeed = 100.0f;
    private float _gravity = 500.0f;

	public override void _Ready()
	{
		CurrentControlScheme = ControlScheme.P1;
		PlayerAnimation = GetNode<AnimationPlayer>("AnimationPlayer");
		_playeSprite = GetNode<Sprite2D>("PlayerSprite");
		_stateMachine = GetNode<Node2D>("PlayerStateMachine");

		MoveState = new PlayerStateMove();
		JumpState = new PlayerStateJump();
		IdleState = new PlayerStateIdle();
		BrakeState = new PlayerStateBrake();
		FallState = new PlayerStateFall();
		JumpPreparationState = new PlayerStateJumpPreparation();

		_stateMachine.AddChild(MoveState);
		_stateMachine.AddChild(JumpState);
		_stateMachine.AddChild(IdleState);
		_stateMachine.AddChild(BrakeState);
		_stateMachine.AddChild(FallState);
		_stateMachine.AddChild(JumpPreparationState);

		ChangeState(IdleState);
	}

	public void SetHeading()
	{
		if (Velocity.X > 0)
		{
			Heading = Vector2.Right;
		}
		else if (Velocity.X < 0)
		{
			Heading = Vector2.Left;
		}
	}
	
	public override void _Process(double delta)
    {
        CurrentState?.Update(delta);
    }

    public override void _PhysicsProcess(double delta)
    {
        CurrentState?.FixedUpdate(delta);
        if (Velocity.Y > 0)
        {
            ChangeState(FallState);
        }
        ProcessFlipSprites();
        ProcessGravity(delta);
        MoveAndSlide();
    }

    public void ChangeState(PlayerState newState, PlayerData data = null)
    {
        if (CurrentState == newState)
            return;

        // 通知旧状态退出
        CurrentState?.Exit();

        // 切换到新状态
        CurrentState = newState;
        CurrentState.Init(this);

        // 通知新状态进入，并传入上下文数据
        CurrentState.Enter(data);
    }

    private void ProcessGravity(double delta)
    {
        if (!IsOnFloor())
        {
            Velocity = new Vector2(Velocity.X, Velocity.Y + _gravity * (float)delta);
        }
    }

    private void ProcessFlipSprites()
    {
        if (Heading == Vector2.Right)
        {
            _playeSprite.FlipH = false;
        }
        else
        {
            _playeSprite.FlipH = true;
        }
    }

    public void OnAnimationCompelete()
	{
		if (CurrentState != null)
		{
			CurrentState.OnAnimationCompelete();
		}
	}


}
