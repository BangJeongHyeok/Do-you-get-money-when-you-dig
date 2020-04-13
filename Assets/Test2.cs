using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Test2 : MonoBehaviour
{
    [SerializeField] GameObject TrailObject;
    [SerializeField] Camera TrailCamera;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

        TrailObject.transform.transform.position += new Vector3(-10f * Time.deltaTime,0f, 0f);
        this.transform.position = TrailObject.transform.position - TrailCamera.transform.position;
    }
}
