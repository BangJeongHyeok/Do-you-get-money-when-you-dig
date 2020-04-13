using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraManager : MonoBehaviour
{

    #region PrivateField
    Camera mainCamera;
    public GameObject Player;
    float PlayerY;
    #endregion

    // Start is called before the first frame update
    private void Awake()
    {
        mainCamera = Camera.main;
        
    }

    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        PlayerY = Player.transform.position.y;
        transform.position = new Vector3(0, PlayerY - 10,-10);
    }
}
