using UnityEngine;

public class Player : MonoBehaviour
{
	[SerializeField] private float moveDistance = 1f;
	[SerializeField] private LayerMask wallLayer;

	void Update()
	{
		float h = Input.GetAxisRaw("Horizontal");
		float v = Input.GetAxisRaw("Vertical");

		Vector2 dir = Vector2.zero;

		dir = new Vector2(h, v);

		if (dir != Vector2.zero)
		{
			TryMove(dir);
		}
	}

	private void TryMove(Vector2 dir)
	{
		Vector2 currentPos = transform.position;
		Vector2 targetPos = currentPos + dir * moveDistance * Time.deltaTime;

		Collider2D hit = Physics2D.OverlapCircle(targetPos, 0.2f, wallLayer);

		if (hit != null) return;

		transform.position = targetPos;
	}
}