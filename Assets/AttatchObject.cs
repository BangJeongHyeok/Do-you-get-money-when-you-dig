using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[ExecuteInEditMode]
public class AttatchObject : MonoBehaviour
{
    [Header("OnlyEditer")] public GameObject AttatchgameObject;
    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
if(Application.isPlaying == false)
        AttatchgameObject.transform.position = this.transform.position;    
    }
}
