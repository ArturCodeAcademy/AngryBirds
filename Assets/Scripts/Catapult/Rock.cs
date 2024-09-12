using UnityEngine;

public class Rock : MonoBehaviour
{
    [SerializeField] private Rigidbody2D _rigidbody;
	[SerializeField] private TrailRenderer _trailRenderer;

	private void Awake()
	{
		_rigidbody.isKinematic = true;
	}

	public void Throw(Vector2 impulse)
    {
		_trailRenderer.enabled = true;
        _rigidbody.isKinematic = false;
		_rigidbody.AddForce(impulse, ForceMode2D.Impulse);
    }
}
