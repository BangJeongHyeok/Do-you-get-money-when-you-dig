using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tset : MonoBehaviour
{
    [SerializeField] GameObject TrailObject;
    [SerializeField] Camera TrailCamera;
    Vector2 LastInput;
    int a = 0;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        TrailObject.transform.transform.position += new Vector3(0f, -1.000000f * Time.deltaTime, 0f);
        TrailCamera.transform.transform.position += new Vector3(0f, -1.000000f * Time.deltaTime, 0f);
    //    this.transform.GetComponent<TrailRenderer>().Clear();
     //   this.transform.GetComponent<TrailRenderer>().AddPosition(this.transform.position + Vector3.up * a++);
        if (Input.GetMouseButton(0))
        {
            Vector2 CurInput = Input.mousePosition;
            Vector2 ScrollDelta = CurInput - LastInput;
            this.transform.position += new Vector3(ScrollDelta.x * Time.deltaTime,0f,0f);
            TrailObject.transform.transform.position += new Vector3(ScrollDelta.x * Time.deltaTime ,0f,  0f);
           // TrailCamera.transform.transform.position += new Vector3(ScrollDelta.x * Time.deltaTime * 5f,0f, 0f);
        }
        LastInput = Input.mousePosition;
    }
}
