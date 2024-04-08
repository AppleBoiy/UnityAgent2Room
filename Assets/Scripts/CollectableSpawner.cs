using System;
using System.Collections;
using System.Collections.Generic;
using Room;
using UnityEngine;
using UnityEngine.AI;

public class CollectableSpawner : MonoBehaviour
{
    [SerializeField] private Collectable collectablePrefab;
    [SerializeField] private Transform playerTransform;
    [SerializeField] private LineRenderer pathRenderer;
    
    [SerializeField] private float pathHeight = 1.25f;
    [SerializeField] private float spawnHeight = 1.5f;
    [SerializeField] private float pathUpdateSpeed = 0.25f;
    
    private Collectable _activeCollectable;
    private NavMeshTriangulation _triangulation;
    private Coroutine _pathUpdateCoroutine;

    private void Start()
    {
        RoomManager.Spawner = this;
    }

    private void Awake()
    {
        _triangulation = NavMesh.CalculateTriangulation();
    }
    
    public void SpawnNewObject(float positionX, float positionY)
    {
        // Spawn at (0, 1, 0) for now
        _activeCollectable = Instantiate(collectablePrefab, new Vector3(positionX, spawnHeight, positionY), Quaternion.identity);
        _activeCollectable.spawner = this;
        
        if (_pathUpdateCoroutine != null)
            StopCoroutine(_pathUpdateCoroutine);
        
        _pathUpdateCoroutine = StartCoroutine(UpdatePath());
    }
    
    private IEnumerator UpdatePath()
    {
        WaitForSeconds wait = new WaitForSeconds(pathUpdateSpeed);
        NavMeshPath path = new NavMeshPath();
        float sqrPathUpdateDistance = 25f;

        while (_activeCollectable != null)
        {
            float sqrDistance = (playerTransform.position - _activeCollectable.transform.position).sqrMagnitude;

            if (sqrDistance > sqrPathUpdateDistance)
            {
                Vector3 playerPosition = new Vector3(playerTransform.position.x, 0, playerTransform.position.z);
                Vector3 collectablePosition = new Vector3(_activeCollectable.transform.position.x, 0, _activeCollectable.transform.position.z);

                if (NavMesh.CalculatePath(playerPosition, collectablePosition, NavMesh.AllAreas, path))
                {
                    pathRenderer.positionCount = path.corners.Length;
                    for (int i = 0; i < path.corners.Length; i++)
                    {
                        pathRenderer.SetPosition(i, path.corners[i] + Vector3.up * pathHeight);
                    }
                }
                else
                {
                    Debug.LogError($"Unable to calculate path between {playerPosition} and {collectablePosition}.");
                }
            }

            yield return wait;
        }
    }


}
