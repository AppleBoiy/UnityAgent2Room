using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;


namespace Room
{
    public class InnerRoom : MonoBehaviour
    {
        
        [Header("Room Components")] 
        public Panel panel;
        public Sign sign;
        
        [Header("Room Properties")]
        public int roomNumber;
        public int floorNumber;
        
        void Start()
        {
            panel = GetComponentInChildren<Panel>();
            sign = GetComponentInChildren<Sign>();
            
            // Temporary setup
            SetProperties(roomNumber, floorNumber);
        }
        
        public void SetProperties(int room, int floor) {
            roomNumber = room;
            floorNumber = floor;
            
            panel.Setup(room, floor);
            sign.Setup(room, floor);
            
            name = "Room " + room + "#" + floor;
            
            Debug.Log("Room " + room + "#" + floor + " created!");
        }
    }

}