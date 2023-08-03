using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class UIController : MonoBehaviour
{
	[SerializeField] private GameObject[] _hearts;
	[SerializeField] private GameObject _endPanel;
	[SerializeField] private TMP_Text _endText;

	private float _gameTime;

	private void Start()
	{
		_gameTime = Time.time;
	}

	public void Restart()
	{
		SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
	}

	public void Exit()
	{
		Application.Quit();
	}

	public void End()
	{
		_endText.text = "Game ended!\nGame time: " + (int)(Time.time - _gameTime) + " seconds";
		_endPanel.SetActive(true);
	}

	public void LoseHeart()
	{
		for (int i = 0; i < _hearts.Length; i++)
		{
			if (_hearts[i] != null)
			{
				Destroy(_hearts[i]);
				break;
			}
		}
	}
}
