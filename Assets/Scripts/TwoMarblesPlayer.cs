using UnityEngine;
using UnityEngine.InputSystem;

namespace ShareDevice
{
    /// <summary> Minimal functionality to show reaction to Vector2 based OnMove from PlayerInput. </summary>
    [RequireComponent(typeof(PlayerInput))]
    [RequireComponent(typeof(Rigidbody))]
    public class TwoMarblesPlayer : MonoBehaviour
    {
        private new Rigidbody rigidbody
        {
            get
            {
                return _rigidbody ??= GetComponent<Rigidbody>();
            }
        }
        private Rigidbody _rigidbody;

        [Tooltip("How quickly OnMove from PlayerInput accelerates the rigidbody.")]
        [SerializeField]
        private float speed = 900;

        [Tooltip("Action (sourced from PlayerInput actions) that will be used to move the player.")]
        [SerializeField]
        private InputActionReference moveAction;

        /// <summary> Required <see cref="PlayerInput"/> actions are used to map <seealso cref="moveAction"/> to the correct binding & control scheme for this player.
        /// This action is expected to contain a Vector2 payload. </summary>
        private InputAction moveActionForPlayer;

        private void Start()
        {
            var playerInput = this.GetComponent<PlayerInput>();

            // reference move action
            if (playerInput.currentActionMap.id != moveAction.action.actionMap.id)
            {
                Debug.LogWarning($"Move Action using action asset '{moveAction.action.actionMap.ToString()}' may be incorrect due to PlayerInput using '{playerInput.currentActionMap.ToString()}'. ");
            }
            moveActionForPlayer = playerInput.actions[moveAction.action.id.ToString()];

            // give each player a color consistent with their part of the device
            var playerName = playerInput.currentControlScheme + playerInput.GetDevice<InputDevice>().deviceId;
            GetComponent<Renderer>().material.color = playerName.ToColorHue();
        }

        private void FixedUpdate()
        {
            Vector3 xzInput = Quaternion.AngleAxis(90, Vector3.right) * moveActionForPlayer.ReadValue<Vector2>();
            rigidbody.AddForce(xzInput * speed * Time.fixedDeltaTime);
        }
    }
}
