using UnityEngine;
using jbmedina;

    public class Radio : MonoBehaviour, IInteractable
    {
        public void Toggle()
        {
            print("Toggle Radio On/Off");
        }

        public void Interact()
        {
        Toggle();
        }
   
    }

