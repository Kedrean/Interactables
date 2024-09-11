using UnityEngine;
using jbmedina;

public class Chair : MonoBehaviour, IInteractable
{
    [SerializeField] private Transform sittingPosition; // Reference to the sitting position

    public void Interact()
    {
        SitPlayerOnChair();
    }

    private void SitPlayerOnChair()
    {
        Player player = FindObjectOfType<Player>();

        if (player != null)
        {
            player.EnableSitting(true, sittingPosition);
        }
    }
}
