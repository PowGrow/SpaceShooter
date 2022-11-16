using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    [SerializeField] private GameObject _enemyPrefab;
    [SerializeField] private GameObject _asteroidPrefab;
    private GameObject _enemy;
    private GameObject _asteroid;

    private void FixedUpdate()
    {
        if (_enemy == null)
            _enemy = Instantiate(_enemyPrefab);
        if (_asteroid == null)
            _asteroid = Instantiate(_asteroidPrefab);
    }
}
