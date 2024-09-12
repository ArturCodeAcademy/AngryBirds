using System;
using UnityEngine;

public class Health : MonoBehaviour
{
	public event EventHandler HealthChanged;
	public event EventHandler HealthEnded;

	public float CurrentHealth { get; private set; }
	[field:SerializeField] public float MaxHealth { get; private set; }

	private void Awake()
	{
		CurrentHealth = MaxHealth;
	}

	public float Hit(float amount)
	{
		if (amount < 0)
			return 0;

		amount = Mathf.Min(amount, CurrentHealth);
		CurrentHealth -= amount;
		HealthChanged?.Invoke(this, EventArgs.Empty);

		if (CurrentHealth <= 0)
			HealthEnded?.Invoke(this, EventArgs.Empty);

		return amount;
	}
}
