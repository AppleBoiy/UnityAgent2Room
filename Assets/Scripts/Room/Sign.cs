using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

namespace Room
{
    public class Sign : MonoBehaviour
    {
        [Header("Sign Components")]
        public TextMeshPro textMeshPro;
        
        // Start is called before the first frame update
        void Start()
        {
            textMeshPro = GetComponent<TextMeshPro>();
        }
        
        void Update()
        {
            // Make the sign always face the camera rotate 180 degrees
            transform.rotation = Quaternion.LookRotation(transform.position - Camera.main.transform.position);
        }
        
        public void Setup(int roomNumber, int floorNumber)
        {
            name = "Sign " + roomNumber + "#" + floorNumber;
            textMeshPro.text = "Sign " + roomNumber + "#" + floorNumber;
        }
    }
}