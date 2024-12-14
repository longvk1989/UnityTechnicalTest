using Photon.Pun;
using Photon.Realtime;
using UnityEngine;

public class PhotonLauncher : MonoBehaviourPunCallbacks
{
    [SerializeField] private string gameVersion = "0.1";
    [SerializeField] private string roomName = "MyRoom";
    [SerializeField] private GameObject playerPrefab;

    // Start is called before the first frame update
    void Start()
    {
        // Connect to Photon Master Server
        PhotonNetwork.GameVersion = gameVersion;
        PhotonNetwork.ConnectUsingSettings();
    }

    public override void OnConnectedToMaster()
    {
        Debug.Log("Connected to Photon Master Server.");

        // Join (or create) a room
        PhotonNetwork.JoinOrCreateRoom(roomName, new RoomOptions { MaxPlayers = 8 }, TypedLobby.Default);
    }

    public override void OnJoinedRoom()
    {
        Debug.Log("Joined Room: " + roomName);

        // Spawn the local player once we've joined the room
        Vector3 spawnPos = new Vector3(Random.Range(-2f, 2f), 1f, Random.Range(0, 4f));
        PhotonNetwork.Instantiate(playerPrefab.name, spawnPos, Quaternion.identity, 0);
    }
}
