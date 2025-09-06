using UnityEngine;

public class MatchPosition : MonoBehaviour
{
    [SerializeField]
    [Tooltip("What this gameobject's transform will match the position.")]
    private Transform target;

    void Update()
    {
        this.transform.position = target.position;
    }
}
