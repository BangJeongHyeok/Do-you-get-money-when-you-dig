using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TrashPlace : MonoBehaviour
{
    float TrashX;
    // Start is called before the first frame update
    void Start()
    {
        TrashX = Random.Range(0, 12) - 6;
        gameObject.transform.position = new Vector3(TrashX,this.transform.position.y, 0);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
