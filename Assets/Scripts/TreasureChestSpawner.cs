using Pinwheel.Poseidon;
using System.Collections;
using System.Collections.Generic;
using Unity.Netcode;
using UnityEngine;

public class TreasureChestSpawner : MonoBehaviour
{
    public static TreasureChestSpawner instance;
    public GameObject treasureChestPrefab;
    public PWater arenaWater;
    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
        else
        {
            Debug.LogError("Duplicate TreasureChestSpawner instance", gameObject);
        }
    }

    public void SpawnTreasureChest()
    {
        GameObject treasureChest = Instantiate(treasureChestPrefab, new Vector3(501, 0, 445), new Quaternion(0, 0, 0, 0));
        treasureChest.GetComponent<SimpleBuoyController>().water = arenaWater;
        treasureChest.GetComponent<NetworkObject>().Spawn();
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
