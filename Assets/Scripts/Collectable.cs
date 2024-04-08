using System;
using System.Collections;
using System.Collections.Generic;
using Unity.Mathematics;
using UnityEngine;

public class Collectable : MonoBehaviour
{
    [SerializeField] private Vector3 spinAmount = new Vector3(0, 20, 0);

    public CollectableSpawner spawner;
    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        // transform.rotation = quaternion.Euler(transform.rotation.eulerAngles + spinAmount * Time.deltaTime);
    }
}
