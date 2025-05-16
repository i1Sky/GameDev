using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NPCSpawnField : MonoBehaviour
{
    public GameObject npcPrefab;
    public int maxNPCs = 5;
    public float checkInterval = 5f;
    public float spawnRadius = 10f;

    private List<GameObject> activeNPCs = new List<GameObject>();

    private void Start()
    {
        StartCoroutine(SpawnCheckLoop());
    }

    private IEnumerator SpawnCheckLoop()
    {
        while (true)
        {
            yield return new WaitForSeconds(checkInterval);

            // Remove NPCs that are destroyed OR disabled
            activeNPCs.RemoveAll(npc => npc == null || !npc.activeInHierarchy);

            if (activeNPCs.Count < maxNPCs)
            {
                int toSpawn = maxNPCs - activeNPCs.Count;
                for (int i = 0; i < toSpawn; i++)
                {
                    Vector3 spawnPos = GetRandomPosition();
                    GameObject newNPC = Instantiate(npcPrefab, spawnPos, Quaternion.identity);
                    activeNPCs.Add(newNPC);
                }
            }
        }
    }

    private Vector3 GetRandomPosition()
    {
        Vector2 circle = Random.insideUnitCircle * spawnRadius;
        Vector3 pos = new Vector3(circle.x, 0, circle.y) + transform.position;
        return pos;
    }
}
