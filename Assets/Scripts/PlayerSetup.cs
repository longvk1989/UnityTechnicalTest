using Cinemachine;
using Photon.Pun;
using UnityEngine;

public sealed class PlayerSetup : MonoBehaviourPun
{
    [SerializeField] private Transform playerCameraRoot;
    [SerializeField] private PlayerNameTag playerNameTag;

    void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;

        if (photonView.IsMine)
        {
            var camera = FindObjectOfType<CinemachineVirtualCamera>();
            if (camera != null)
            {
                camera.Follow = playerCameraRoot;
            }
        }

        playerNameTag.Setup($"Player{photonView.ViewID}", Camera.main.transform);
    }
}
