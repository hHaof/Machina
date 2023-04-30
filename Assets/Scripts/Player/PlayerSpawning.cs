using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerSpawning : MonoBehaviour
{
    [SerializeField] GameObject clonePrefab;
    public List<GameObject> cloneList;
    AudioController audioController;

    private void Start()
    {
        audioController = GameObject.Find("AudioSource").GetComponent<AudioController>();
    }

    public void Spawn(int gateValue, GateType gateType)
    {
        audioController.PlayGateSound();
        if (gateType == GateType.ADDITION)
        {
            for (int i = 0; i < gateValue; i++)
            {
                // Instantiate the player prefab at the specified spawn position
                GameObject playerInstance = Instantiate(clonePrefab, GetPlayerPosition(), Quaternion.identity, transform);
                cloneList.Add(playerInstance);
            }
        }
        else if (gateType == GateType.MULTIPLY)
        {
            int playerCount = (cloneList.Count * gateValue) - cloneList.Count;
            for (int i = 0; i < playerCount; i++)
            {
                // Instantiate the player prefab at the specified spawn position
                GameObject playerInstance = Instantiate(clonePrefab, GetPlayerPosition(), Quaternion.identity, transform);
                cloneList.Add(playerInstance);
            }
        }

    }
    private Vector3 GetPlayerPosition()
    {
        Vector3 position = Random.onUnitSphere * 0.2f;
        Vector3 newPosition = position + transform.position;
        return newPosition;
    }

    public void RemoveFromList(GameObject cop)
    {
        cloneList.Remove(cop);
        Destroy(cop);
    }

    public int CopsNumber()
    {
        return cloneList.Count;
    }

    public GameObject getCop(int i)
    {
        return cloneList[i];
    }
}