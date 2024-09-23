using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.Events;

public class EnemyRegister : MonoBehaviour
{
    public UnityEvent AllEnemiesKilled;

    [SerializeField] private List<Enemy> _enemies;

    private void Start()
    {
		foreach (var enemy in _enemies)
			enemy.Health.HealthEnded += OnEnemyKilled;
	}

    private void OnEnemyKilled(object sender, System.EventArgs e)
    {
		if (_enemies.All(h => h.Health.CurrentHealth <= 0))
		    AllEnemiesKilled?.Invoke();
	}

#if UNITY_EDITOR

    [ContextMenu("Register Enemies")]
    private void RegisterEnemies()
    {
        _enemies ??= new List<Enemy>();
		_enemies.Clear();
		_enemies.AddRange(FindObjectsOfType<Enemy>());
	}

#endif
}
