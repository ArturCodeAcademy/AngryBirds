using System;
using UnityEngine;

public class Enemy : MonoBehaviour
{
	[field:SerializeField] public Health Health { get; private set; }
	[SerializeField] private GameObject _destroyEffectPrefab;

	private void Start()
	{
		Health.HealthEnded += OnEndHealth;
	}

	private void OnEndHealth(object sender, EventArgs e)
	{
		Instantiate(_destroyEffectPrefab, transform.position, Quaternion.identity);
		Destroy(gameObject);
	}

	private void OnDestroy()
	{
		Health.HealthEnded -= OnEndHealth;
	}
}
