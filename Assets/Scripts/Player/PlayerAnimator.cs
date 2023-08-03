using UnityEngine;

[RequireComponent(typeof(PlayerMover))]
[RequireComponent(typeof(Player))]
public class PlayerAnimator : BaseAnimator
{
	[SerializeField] private float _attackFrequency;

	private PlayerMover _playerMover;
	private Player _playerScript;
	private float _lastAttackTime;

	private void Start()
	{
		_playerMover = GetComponent<PlayerMover>();
		_playerScript = GetComponent<Player>();
		_lastAttackTime = -_attackFrequency;
	}

	private void Update()
	{
		if (!_playerMover.IsGrounded)
		{
			Jump();
		}
		else
		{
			Run();
		}

		if (_playerMover.controls.GetAttack())
		{
			if (Time.time > _lastAttackTime + _attackFrequency)
			{
				Attack();
				_lastAttackTime = Time.time;
			}
		}
	}

	private void Run()
	{
		animatorChar.SetBool("Jump", false);
		Vector2 velocity = _playerMover.Velocity;

		if (velocity.x == 0)
		{
			animatorChar.SetBool("Run", false);
		}
		else
		{
			animatorChar.SetBool("Run", true);
			_playerScript.Flip(velocity);
		}
	}

	private void Jump()
	{
		Vector2 velocity = _playerMover.Velocity;

		animatorChar.SetBool("Jump", true);
		_playerScript.Flip(velocity);
	}

	protected override void DieAction()
	{
		_playerScript.canvasController.End();
	}

	protected override void ObjectToAttack(Collider2D objectCollider)
	{
		objectCollider.GetComponent<EnemyAnimator>().TakeDamage(attackDamage);
	}

	protected override void AttackDelay()
	{
		_lastAttackTime = Time.time;
	}
}