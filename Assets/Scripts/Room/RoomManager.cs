using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Room
{
    public class RoomManager : MonoBehaviour
    {

        [Header("Room Manager")]
        [SerializeField] private GameObject roomPrefab;
        
        [Space(10)]
        [SerializeField] private GameObject roomParent;
        
        public static RoomManager Instance;

        // Start is called before the first frame update
        void Start()
        {
            Instance = this;
            
            // Instantiate the room 3 times
            int x = -10;
            for (int i = 1; i < 4; i++)
            {
                GameObject room = Instantiate(roomPrefab, roomParent.transform);
                room.GetComponent<InnerRoom>().SetProperties(i, 1);
                
                // Set the position of the room
                room.transform.position = new Vector3(x, 0.2f, 20);
                x += 10;
            }
        }
        public void OnRoomPanelClicked(Panel roomPanel)
        {
            Debug.Log(roomPanel.name + " clicked!");
            roomPanel.ToggleActive(true);
        }
    }
}
