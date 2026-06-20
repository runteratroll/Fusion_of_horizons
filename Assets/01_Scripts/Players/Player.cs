using UnityEngine;
using UnityEngine.Events;

public class Player : MonoBehaviour
{
    [SerializeField] private float moveDistance = 1f;
    [SerializeField] private LayerMask wallLayer;

    public IClampBoundsProvider BoundsProvider;

    public bool IsVelocityMove = false;

    private Vector2 moveVelocity = Vector2.zero;

    void Update()
    {
        Vector2 dir = Vector2.zero;
        
        if (IsVelocityMove == false)
        {

            dir = GetDirection();

            if (dir != Vector2.zero)
            {
                TryMove(dir);
            }
        } else
        {
            dir = GetDirectionByInputDown();
            moveVelocity += dir;

            TryMove(moveVelocity * 0.5f);
        }
    }

    public void SetIsVelocityMove(bool value)
    {
        IsVelocityMove = value;

        moveVelocity = Vector2.zero;
    }

    private Vector2 GetDirection()
    {
        return new Vector2(Input.GetAxisRaw("Horizontal"), Input.GetAxisRaw("Vertical"));
    }

    private Vector2 GetDirectionByInputDown()
    {
        float h = 0;
        float v = 0;

        h = (Input.GetKeyDown(KeyCode.A) ? -1f : 0f) + (Input.GetKeyDown(KeyCode.D) ? 1f : 0f);
        v = (Input.GetKeyDown(KeyCode.S) ? -1f : 0f) + (Input.GetKeyDown(KeyCode.W) ? 1f : 0f);

        Debug.Log($"H : {h}, V : {v}");
        return new Vector2(h, v);
    }

    private void TryMove(Vector2 dir)
    {
        Vector2 currentPos = transform.position;
        Vector2 targetPos = currentPos + dir * moveDistance * Time.deltaTime;

        Collider2D hit = Physics2D.OverlapCircle(targetPos, 0.2f, wallLayer);

        if (hit != null) return;

        if(BoundsProvider != null)
        {
            Bounds bounds = BoundsProvider.GetBounds();

            targetPos.x = Mathf.Clamp(targetPos.x, bounds.min.x, bounds.max.x);
            targetPos.y = Mathf.Clamp(targetPos.y, bounds.min.y, bounds.max.y);
        }

        transform.position = targetPos;
    }
}