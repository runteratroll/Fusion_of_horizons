using UnityEngine;

public class PlayerPickup : MonoBehaviour
{
    [Header("Hold")]
    [SerializeField] private Transform holdPoint;

    [Header("Drop")]
    [SerializeField] private float dropDistance = 1f;

    private PickupObject nearbyObject;
    private PickupObject heldObject;

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.P))
        {
            if (heldObject == null)
            {
                PickUp();
            }
            else
            {
                Drop();
            }
        }

        if (heldObject != null)
        {
            heldObject.transform.position =
                holdPoint.position;
        }
    }

    private void PickUp()
    {
        if (nearbyObject == null) return;

        heldObject = nearbyObject;
        heldObject.isHeld = true;

        Rigidbody2D rb =
            heldObject.GetComponent<Rigidbody2D>();

        if (rb != null)
        {
            rb.linearVelocity = Vector2.zero;
            rb.simulated = false;
        }
    }

    private void Drop()
    {
        heldObject.isHeld = false;

        Rigidbody2D rb =
            heldObject.GetComponent<Rigidbody2D>();

        if (rb != null)
        {
            rb.simulated = true;
        }

        Vector3 dropPos =
            transform.position +
            transform.right * dropDistance;

        heldObject.transform.position = dropPos;

        heldObject = null;
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        PickupObject pickup =
            other.GetComponent<PickupObject>();

        if (pickup != null)
        {
            nearbyObject = pickup;
        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        PickupObject pickup =
            other.GetComponent<PickupObject>();

        if (pickup == nearbyObject)
        {
            nearbyObject = null;
        }
    }
}