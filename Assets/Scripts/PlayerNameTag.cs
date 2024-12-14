using Photon.Pun;
using TMPro;
using UnityEngine;

public class PlayerNameTag : MonoBehaviourPun
{
    [SerializeField] private TextMeshProUGUI nameText;

    private Transform mainCam;

    public void Setup(string name, Transform camera)
    {
        nameText.SetText(name);
        mainCam = camera;
    }

    // Update is called once per frame
    void LateUpdate()
    {
        if (mainCam != null)
        {
            // Keep the NameTag facing the camera
            transform.LookAt(transform.position + mainCam.forward);
        }
    }
}
