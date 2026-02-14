using UnityEngine;

public class ZoneAddForce : MonoBehaviour
{
    [SerializeField]
    [Tooltip("Force that will be added to any rigidbody that stays in the collider of this gameobject.")]
    private Vector3 AddForce = 400 * Vector3.up;

    void OnTriggerStay(Collider other)
    {
        if (other.attachedRigidbody)
        {
            other.attachedRigidbody.AddForce(10 * Time.deltaTime * AddForce);
        }
    }
}
