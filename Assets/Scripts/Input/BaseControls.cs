using UnityEngine;

public abstract class BaseControls : MonoBehaviour
{
	public abstract float GetHorizontalInput();
	public abstract bool GetAttack();
	public abstract bool GetJump();

}
