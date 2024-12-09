using NUnit.Framework;
using UnityEngine;
using System.Collections.Generic;
using UnityEngine.UIElements;

public class TrapsManager : MonoBehaviour
{
    [Header("References")]
    [SerializeField] GameObject trapPrefab;
    [SerializeField] BoxCollider groundMesh;

    [Header("Settings")]
    [SerializeField] int trapCount;
    
    [Header("Input Events")]
    [SerializeField] RSE_LevelStarted levelStarted;
    [SerializeField] RSE_PlayerDied playerDied;
    [SerializeField] RSE_Win win;

    List<GameObject> traps = new List<GameObject>();
    Vector3 groundCenter;
    float groundWidth;
    float groundHeight;
    float groundDepth;

    private void OnEnable()
    {
        if (trapPrefab == null) Debug.LogError("No prefab set for traps.");
        if (groundMesh == null) Debug.LogError("No mesh collider set for the ground.");

        levelStarted.Fire += SpawnTraps;
        playerDied.Fire += RemoveTraps;
        playerDied.Fire += SpawnTraps;
        win.Fire += RemoveTraps;
        win.Fire += SpawnTraps;
    }

    private void OnDisable()
    {
        levelStarted.Fire -= SpawnTraps;
        playerDied.Fire -= RemoveTraps;
        playerDied.Fire -= SpawnTraps;
        win.Fire -= RemoveTraps;
        win.Fire -= SpawnTraps;
    }

    void SpawnTraps()
    {
        groundCenter = groundMesh.bounds.center;
        groundWidth = groundMesh.bounds.extents.x;
        groundHeight = groundMesh.bounds.extents.y;
        groundDepth = groundMesh.bounds.extents.z;

        for (int i = 0;  i < trapCount; i++)
        {
            Vector3 newTrapPosition = FindSpawnPosition();
            SpawnTrapAtPosition(newTrapPosition);
        }
    }

    Vector3 FindSpawnPosition()
    {
        Vector3 result = Vector3.zero;

        do
        {
            float widthRatio = Random.Range(-1f, 1f);
            float depthRatio = Random.Range(-1f, 1f);

            Vector3 testPosition = new Vector3(widthRatio * groundWidth, groundHeight + 1, depthRatio * groundDepth);

            RaycastHit hit;

            if (Physics.Raycast(testPosition, Vector3.down, out hit, Mathf.Infinity))
            {
                if (hit.collider.CompareTag("Ground"))
                {
                    result = hit.point;
                }
            }
        } while (result == Vector3.zero);

        return result;
    }

    void SpawnTrapAtPosition(Vector3 position)
    {
        traps.Add(Instantiate(trapPrefab, position, Quaternion.identity));
    }

    void RemoveTraps()
    {
        foreach (var trap in traps)
        {
            Destroy(trap);
        }

        traps.Clear();
    }
}
