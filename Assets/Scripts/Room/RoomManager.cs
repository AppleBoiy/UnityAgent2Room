using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Room
{
    public class RoomManager : MonoBehaviour
    {

        #region Singleton
        
        [Header("Room Manager")]
        [SerializeField] private GameObject roomPrefab;
        
        [Space(10)]
        [SerializeField] private GameObject roomParent;

        public static RoomManager Instance;
        
        // Activated panel
        public Panel activePanel;
        
        #endregion

        private void Start()
        {
            Instance = this;
        }
        
        public void ToggleActivePanel(Panel panel)
        {
            if (activePanel == panel)
            {
                // If the panel is already active, deactivate it
                activePanel.ToggleActive();
                activePanel = null;
                return;
            }
            if (activePanel != null)
            {
                activePanel.ToggleActive();
            }

            activePanel = panel;
            activePanel.ToggleActive();
        }
        
        void InstantiateRoom() {
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
    }
}
