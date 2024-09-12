using System;
using UnityEngine;

public class Enemy : MonoBehaviour
{
	[SerializeField] private Health _health;
	[SerializeField] private GameObject _destroyEffectPrefab;

	private void Start()
	{
		_health.HealthEnded += OnEndHealth;
	}

	private void OnEndHealth(object sender, EventArgs e)
	{
		Instantiate(_destroyEffectPrefab, transform.position, Quaternion.identity);
		Destroy(gameObject);
	}

	private void OnDestroy()
	{
		_health.HealthEnded -= OnEndHealth;
	}
}
