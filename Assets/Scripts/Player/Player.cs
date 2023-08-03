using UnityEngine;

public class Player : BaseCharacter
{
	[SerializeField] private Canvas _canvas;

	[HideInInspector] public UIController canvasController;

	private void Start()
	{
		canvasController = _canvas.GetComponent<UIController>();
	}

	private void OnCollisionEnter2D(Collision2D collision)
	{
		if (collision.gameObject.GetComponent<Enemy>() != null)
		{
			canvasController.LoseHeart();
		}
	}

	public override void Flip(Vector2 velocity)
	{
		if (velocity.x < 0 && transform.eulerAngles.y != 180)
		{
			transform.eulerAngles = new Vector2(0, 180);
		}
		else if (velocity.x > 0 && transform.eulerAngles.y != 0)
		{
			transform.eulerAngles = new Vector2(0, 0);
		}
	}
}