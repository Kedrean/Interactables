using UnityEngine;
using jbmedina;

public class Player : MonoBehaviour
{
    private Camera _camera;
    private bool isSitting = false;
    private Transform originalPosition; // Store the original player position to stand up later

    private void Start()
    {
        _camera = Camera.main;
        originalPosition = transform; // Store player's original position
    }

    private void Update()
    {
        // If sitting, allow the player to stand up by pressing the left mouse button
        if (isSitting)
        {
            if (Input.GetButtonDown("Fire1"))
            {
                StandUp();
            }
            return;
        }

        GameObject nearestGameObject = GetNearestGameObject();

        if (nearestGameObject == null) return;

        if (Input.GetButtonDown("Fire1"))
        {
            var interactable = nearestGameObject.GetComponent<IInteractable>();
            if (interactable == null) return;
            interactable.Interact();
        }
    }

    private GameObject GetNearestGameObject()
    {
        GameObject result = null;
        var ray = _camera.ScreenPointToRay(Input.mousePosition);
        if (Physics.Raycast(ray, out var hit, 3))
        {
            result = hit.transform.gameObject;
        }
        return result;
    }

    // Method to make the player sit
    public void EnableSitting(bool sitting, Transform sitPosition)
    {
        isSitting = sitting;

        if (isSitting)
        {
            // Move the player to the sitting position
            transform.position = sitPosition.position;
            transform.rotation = sitPosition.rotation;

            // Disable movement or other actions while sitting
        }
        else
        {
            // Enable movement and other actions again when standing up
        }
    }

    // Method to make the player stand up
    private void StandUp()
    {
        isSitting = false;
        
        // You can return the player to a standing position or a predefined position
        // Here, we move the player a little backward from the chair
        transform.position = originalPosition.position + Vector3.back * 0.5f;
        transform.rotation = originalPosition.rotation;

        // Re-enable player controls if needed
    }
}
