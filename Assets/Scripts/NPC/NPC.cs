using UnityEngine;
using UnityEngine.Events;
using UnityEngine.InputSystem;

public class NPC : MonoBehaviour
{
    [SerializeField] private InputAction interact;
    private CapsuleCollider collider;
    [SerializeField] private UnityEvent onInteract;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        collider = GetComponent<CapsuleCollider>();
        interact.started += OnInteract;
        interact.Disable();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnCollisionEnter(Collision collision)
    {
        //Check for player
        //if (!collision.gameObject.TryGetComponent<PlayerScript>(out PlayerScript player)) return;
        //Show interaction icon
        interact.Enable();
    }

    private void OnCollisionExit(Collision collision)
    {
        //Check for player
        //if (!collision.gameObject.TryGetComponent<PlayerScript>(out PlayerScript player)) return;
        //Hide interaction icon
        interact.Disable();
    }

    private void OnInteract(InputAction.CallbackContext ctx)
    {
        //Only interact when in radius
        Debug.Log("Interacted!");
        onInteract.Invoke();
    }
}
