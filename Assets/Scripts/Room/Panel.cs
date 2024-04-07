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
        
        // Start is called before the first frame update
        void Start()
        {
            _renderer = GetComponent<Renderer>();
            _renderer.material = idleMaterial;
        }

        void OnMouseDown()
        {
            RoomManager.Instance.OnRoomPanelClicked(this);
        }

        public void ToggleActive(bool active)
        {
            GetComponent<Renderer>().material = active ? activeMaterial : idleMaterial;
        }

        public void Setup(int roomNumber, int floorNumber)
        {
            name = "Panel " + roomNumber + "#" + floorNumber;
        }
        
    }

}
