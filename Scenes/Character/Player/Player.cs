using Godot;
using System;

public partial class Player : Character
{
	public enum ControlScheme { P1, P2, CPU };

	
	public float NormalSpeed = 100.0f;
	public float SprintSpeed = 150.0f;

	private PlayerState _currentState;
	private PlayerStateFactroy _stateFactroy = new();

	public enum State
	{
		IDLE,
		MOVING,
		JUMPING,
		ATTACKING
	}

	public override void _Ready()
	{
		SwitchState(State.IDLE, null);
	}

	private void ProcessGravity()
	{

	}

	public override void _PhysicsProcess(double delta)
	{
		MoveAndSlide();
	}
	
	public void SwitchState(State state, PlayerStateData stateData)
	{
		if (_currentState != null)
		{
			_currentState.OnStateTransitionRequest -= SwitchState;
			_currentState.QueueFree();
		}
		_currentState = _stateFactroy.GetNewState(state);
		_currentState.Setup(this);
		_currentState.OnStateTransitionRequest += SwitchState;
		_currentState.Name = "PlayerStateMachine:" + state.ToString();
		GD.Print(_currentState.Name);
		CallDeferred("add_child", _currentState);
	}
}
