using UnityEngine;

namespace _Project.Scripts
{
    public class ChangeColorIfNearby : MonoBehaviour
    {
        [SerializeField, Tooltip("Distance at which we change the color")] private float _colorSwapThreshold = 1.4f;
        [SerializeField, Tooltip("Default Material of this cube")] private Material _defaultMaterial;
        [SerializeField] private Material _nearbyMaterial;
        [SerializeField] private MeshRenderer _renderer;
    
        private Camera _camera;

        // Start is called once before the first execution of Update after the MonoBehaviour is created
        private void Awake()
        {
            if(_renderer == null) Debug.LogWarning("No MeshRenderer found!");
        }

        private void Start()
        {
            _camera = Camera.main;
        }

        // Update is called once per frame
        private void Update()
        {
            Vector3 distanceTestVector =  transform.position - _camera.transform.position;
            float distance =  distanceTestVector.magnitude;

            _renderer.material = distance > _colorSwapThreshold ? _defaultMaterial : _nearbyMaterial;
        }
    }
}
