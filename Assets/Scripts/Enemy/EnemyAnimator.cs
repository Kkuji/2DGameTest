using UnityEngine;
using System.Linq;

public class EnemyAnimator : BaseAnimator
{
	private int _enemyAlive;
	private Canvas _canvas;

	protected override void ObjectToAttack(Collider2D objectCollider)
	{
		objectCollider.GetComponent<PlayerAnimator>().TakeDamage(attackDamage);
	}

	protected override void DieAction()
	{
		Enemy[] objectsWithScript = FindObjectsOfType<Enemy>();


		_enemyAlive = objectsWithScript.Count(obj => obj.GetComponent<BoxCollider2D>().enabled);

		if (_enemyAlive == 0)
		{
			_canvas.GetComponent<UIController>().End();
		}
	}

	protected override void AttackDelay()
	{

	}

	public void SetCanvas(Canvas canvas)
	{
		_canvas = canvas;
	}
}