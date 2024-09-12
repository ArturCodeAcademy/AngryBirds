using UnityEngine;

public class Catapult : MonoBehaviour
{
    [Header("Params")]
    [SerializeField, Range(0.5f, 5)] private float _dragDistance;
    [SerializeField, Min(0.5f)] private float _maxImpulse;

    [Header("Components")]
    [SerializeField] private Rock _rockPrefab;

    private Rock _currentRock;

	private void OnMouseDown()
	{
		_currentRock = Instantiate(_rockPrefab);
	}

	private void OnMouseDrag()
	{
		if (_currentRock == null)
			return;

		Vector2 mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
		Vector3 dirrection = (Vector2)transform.position - mousePos;
		Vector3 rockPos = mousePos;

		if (dirrection.sqrMagnitude > _dragDistance * _dragDistance)
		{
			rockPos = transform.position - dirrection.normalized * _dragDistance;
		}

		_currentRock.transform.position = rockPos;
	}

	private void OnMouseUp()
	{
		if (_currentRock == null)
			return;

		Vector2 mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
		Vector2 dirrection = (Vector2)transform.position - mousePos;

		if (dirrection.sqrMagnitude > _dragDistance * _dragDistance)
		{
			_currentRock.Throw(dirrection.normalized * _maxImpulse);
		}
		else
		{
			float force = Vector2.Distance(mousePos, transform.position) / _dragDistance;
			_currentRock.Throw(dirrection.normalized * _maxImpulse * force);
		}

		_currentRock = null;
	}

#if UNITY_EDITOR

	private void OnDrawGizmosSelected()
	{
		Gizmos.color = Color.blue;

		Gizmos.DrawWireSphere(transform.position, _dragDistance);
	}

#endif

}
