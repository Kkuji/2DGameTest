using UnityEngine;

public class KeyboardControls : BaseControls
{
	public override float GetHorizontalInput()
	{
		return Input.GetAxisRaw("Horizontal");
	}

	public override bool GetAttack()
	{
		if (Input.GetKeyDown(KeyCode.W))
		{
			return true;
		}
		else
		{
			return false;
		}
	}

	public override bool GetJump()
	{
		if (Input.GetKeyDown(KeyCode.Space))
		{
			return true;
		}
		else
		{
			return false;
		}
	}
}

