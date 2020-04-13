using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerTail : MonoBehaviour
{
    RelativeJoint2D[] relativeJoint2Ds = new RelativeJoint2D[6];
    // Start is called before the first frame update
    void Start()
    {
        for(int i = 0; i < 6; i++)
        {
            relativeJoint2Ds[i] = this.transform.GetChild(i).GetComponent<RelativeJoint2D>();
        }
    }

    // Update is called once per frame
    void Update()
    {
        //for(int i = 0; i < 6; i++)
        //{
        //    relativeJoint2Ds[i].isActiveAndEnabled
        //}
    }
}
