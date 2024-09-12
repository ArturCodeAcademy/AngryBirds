using UnityEngine;

public class ForceDamager : MonoBehaviour
{
	[SerializeField, Min(0)] private float _minVelocityForDamage;
    [SerializeField, Min(0.1f)] private float _damageMultiplier;
    [SerializeField] private Health _health;

	private void OnCollisionEnter2D(Collision2D collision)
	{
		float velocity = collision.relativeVelocity.magnitude;

		if (velocity < _minVelocityForDamage)
			return;

		_health.Hit(velocity * _damageMultiplier);
	}
}
