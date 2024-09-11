using System.Collections.Generic;
using UnityEngine;
using jbmedina;

public class Lamp : MonoBehaviour,IInteractable
    {
        [SerializeField] private List<Light> lights;
        [SerializeField] private List<GameObject> emissiveObjects;

        private bool _isEnabled = true;

        public void Switch()
        {
            _isEnabled = !_isEnabled;

            foreach (var aLight in lights)
            {
                aLight.enabled = _isEnabled;
            }

            foreach (var go in emissiveObjects)
            {
                var aRenderer = go.GetComponent<Renderer>();
                if (aRenderer == null) continue;
                var material = aRenderer.material;
                if (_isEnabled)
                {
                    material.EnableKeyword("_EMISSION");
                }
                else
                {
                    material.DisableKeyword("_EMISSION");
                }
            }
        }

    public void Interact()
    {
        Switch();
    }

}
