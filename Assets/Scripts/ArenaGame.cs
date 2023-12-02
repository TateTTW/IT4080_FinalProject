using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Unity.Netcode;
using Pinwheel.Poseidon;

public class ArenaGame : NetworkBehaviour
{
    private NetworkedPlayers networkedPlayers;

    public Player playerPrefab;
    public Player hostPrefab;

    public Camera arenaCamera;
    public PWater arenaWater;

    private Vector3[] startPositions = new Vector3[]
    {
        new Vector3(805, 6, 826),
        new Vector3(134, 6, 825),
        new Vector3(808, 6, 139),
        new Vector3(147, 6, 151)
    };

    public GameObject[] playerDocks = new GameObject[4];

    void Start()
    {
        if (IsClient && arenaCamera != null)
        {
            arenaCamera.enabled = false;
            arenaCamera.GetComponent<AudioListener>().enabled = false;
        }

        if (IsServer)
        {
            networkedPlayers = GameObject.Find("NetworkedPlayers").GetComponent<NetworkedPlayers>();
            SpawnPlayers();
        }
    }

    private void SpawnPlayers()
    {
        int index = 0;
        foreach(NetworkPlayerInfo info in networkedPlayers.allNetPlayers)
        {
            Debug.Log("clientId: " + info.clientId);
            Vector3 position = startPositions[index];
            Quaternion rotation = index < 2 ? new Quaternion(0, 180, 0, 0) : Quaternion.identity;

            Player playerSpawn = Instantiate(playerPrefab, position, rotation);
            playerSpawn.respawnPosition = position;
            playerSpawn.respawnRotation = rotation;
            playerSpawn.GetComponent<NetworkObject>().SpawnAsPlayerObject(info.clientId);
            playerSpawn.playerColorNetVar.Value = info.color;
            playerSpawn.GetComponent<SimpleBuoyController>().water = arenaWater;

            playerDocks[index].GetComponent<NetworkObject>().ChangeOwnership(info.clientId);
            playerDocks[index].GetComponent<PlayerDock>().colorNetVar.Value = info.color;

            index += 1;
        }
    }

}
