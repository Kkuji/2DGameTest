using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
	[SerializeField] private Transform[] _spawnPoints;
	[SerializeField] private GameObject _enemy;
	[SerializeField] private Canvas _canvas;

	private bool[] _avaliablePoints;

	private int _randomIndex;
	private int _maxEnemies;

	private void Start()
	{
		if (_spawnPoints.Length == 0)
			return;

		_avaliablePoints = new bool[_spawnPoints.Length];

		for (int i = 0; i < _avaliablePoints.Length; i++)
		{
			_avaliablePoints[i] = true;
		}

		_maxEnemies = Random.Range(1, _spawnPoints.Length + 1);

		for (int i = 0; i < _maxEnemies; i++)
		{
			SpawnEnemyInRandomPoint();
		}
	}

	private void SpawnEnemyInRandomPoint()
	{
		_randomIndex = Random.Range(0, _spawnPoints.Length);

		if (_avaliablePoints[_randomIndex])
		{
			GameObject currentEnemy = Instantiate(_enemy, _spawnPoints[_randomIndex]);
			currentEnemy.GetComponent<EnemyAnimator>().SetCanvas(_canvas);
			_avaliablePoints[_randomIndex] = false;
		}
		else
		{
			SpawnEnemyInRandomPoint();
		}
	}
}
