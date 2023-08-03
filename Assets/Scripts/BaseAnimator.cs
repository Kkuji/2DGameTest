using UnityEngine;

[RequireComponent(typeof(Animator))]
public abstract class BaseAnimator : MonoBehaviour
{
	[SerializeField] private int _health;
	private int _currentHealth;

	[SerializeField] protected int attackDamage;
	[SerializeField] protected Transform attackPoint;
	[SerializeField] protected LayerMask enemyLayer;
	[SerializeField] protected float attackRange;
	protected Animator animatorChar;

	private void Awake()
	{
		_currentHealth = _health;
		animatorChar = GetComponent<Animator>();
	}

	public void TakeDamage(int damage)
	{
		AttackDelay();
		_currentHealth -= damage;
		animatorChar.SetTrigger("Damaged");

		if (_currentHealth < 1)
		{
			Die();
		}
	}

	private void Die()
	{
		animatorChar.SetBool("IsDead", true);

		if (GetComponent<Player>() != null)
		{
			GetComponent<PlayerMover>().enabled = false;
		}
		else
		{
			GetComponent<Collider2D>().enabled = false;
		}
		DieAction();

		enabled = false;
	}

	protected abstract void ObjectToAttack(Collider2D objectCollider);

	protected abstract void DieAction();

	protected abstract void AttackDelay();

	public void Attack()
	{
		animatorChar.SetTrigger("Attack");
		Collider2D[] hitEnemies = Physics2D.OverlapCircleAll(attackPoint.position, attackRange, enemyLayer);

		foreach (Collider2D enemy in hitEnemies)
		{
			ObjectToAttack(enemy);
		}
	}
}