using System.Collections;
using System.Collections.Generic;
using UnityEngine;

 [RequireComponent(typeof(Collider2D))]
public class TeleportTrigger : MonoBehaviour
{
    public enum TriggerType { Enter, Exit };
    public string key = "Press E";

    [Tooltip("The Transform to teleport to")]
    [SerializeField] Transform teleportTo;

    [Tooltip("The filter Tag")]
    [SerializeField] string filtertag = "Player";

    [Tooltip("Trigger Event to Teleport")]
    [SerializeField] TriggerType type;

        void OnTriggerStay2D(Collider2D other)
        {
            if (Input.GetKeyUp(KeyCode.E) && other.CompareTag("ranger"))
            {
                other.transform.position = teleportTo.position;
            }
        }
}
