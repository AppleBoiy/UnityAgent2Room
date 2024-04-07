using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Serialization;


namespace Room
{

    public class Panel : MonoBehaviour
    {

        [Header("Materials")]
        [SerializeField] private Material idleMaterial;
        [SerializeField] private Material activeMaterial;

        private Renderer _renderer;

        private bool _isActive;
        
        // Start is called before the first frame update
        void Start()
        {
            _renderer = GetComponent<Renderer>();
            _renderer.material = idleMaterial;

            _isActive = false;
        }

        void OnMouseDown()
        {
            RoomManager.Instance.ToggleActivePanel(this);
        }
        
        public void ToggleActive()
        {
            _isActive = !_isActive;
            GetComponent<Renderer>().material = _isActive ? activeMaterial : idleMaterial;
        }

        public void Setup(int roomNumber, int floorNumber)
        {
            name = "Panel " + roomNumber + "#" + floorNumber;
        }
        
    }

}
