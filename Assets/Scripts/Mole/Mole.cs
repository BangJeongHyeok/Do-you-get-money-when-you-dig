using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Mole : MonoBehaviour
{
    #region SerializeField
    #endregion

    #region PrivateField
    #endregion

    #region PublicField
    [HideInInspector] public float DigSpeed;
    [HideInInspector] public int Dir;
    #endregion
    private void Start()
    {
     //   Dir = 1;
       // this.transform.localScale = new Vector3(this.transform.localScale.x , this.transform.localScale.y * Dir,0f);
        if(Dir == -1)
        {
            this.transform.Find("Body").GetComponent<SpriteRenderer>().flipY = true;
        }

        Destroy(this.gameObject, 10);
    }

    // Update is called once per frame
    void Update()
    {
        this.transform.position += new Vector3(Dir * Time.deltaTime * DigSpeed,0f,0f);
       
    }
    
}
