using UnityEngine;

public class MatchPosition : MonoBehaviour
{
    [SerializeField]
    [Tooltip("What this gameobject's transform will match the position.")]
    private Transform target;

    [SerializeField]
    [Tooltip("What this gameobject's transform will match the position.")]
    private bool keepOffset = true;

    /// <summary> position delta between target and starting position of this gameobject. </summary>
    private Vector3 offset;

    void Start()
    {
        OnValidate();
    }

    private void OnValidate()
    {
        offset = keepOffset
            ? this.transform.position - target.position
            : Vector3.zero;
    }

    void Update()
    {
        this.transform.position = target.position + offset;
    }
}
