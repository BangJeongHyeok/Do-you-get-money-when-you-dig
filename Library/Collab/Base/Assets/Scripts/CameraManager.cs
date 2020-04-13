using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraManager : MonoBehaviour
{

    #region PrivateField
    Camera mainCamera;
    GameObject Player;
    #endregion

    // Start is called before the first frame update
    private void Awake()
    {
        mainCamera = Camera.main;
        Player = GameObject.FindGameObjectWithTag("Player");
    }

    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 Pos = this.transform.position;
    }
}
