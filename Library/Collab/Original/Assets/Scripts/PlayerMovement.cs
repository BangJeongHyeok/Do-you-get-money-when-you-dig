using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class PlayerMovement : MonoBehaviour
{
    #region SerializeField
    [SerializeField] private float MoveSpeed;

    #endregion

    #region PrivateField
    GameObject HandleObject = null;
    Vector2 DragStartPosition;
    #endregion
    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(HandleObject == null)
        this.transform.position -= new Vector3(0f, MoveSpeed * Time.deltaTime,0f);
        else
        {
            HandleObject.GetComponent<Stone>().Hp -= 20 * Time.deltaTime;
        }
    }



    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.tag == "Stone")
        {
            HandleObject = collision.gameObject;
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.tag == "Stone")
        {
            HandleObject = null;
        }
    }
}
