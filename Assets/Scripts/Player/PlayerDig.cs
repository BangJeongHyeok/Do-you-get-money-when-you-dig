using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerDig : MonoBehaviour
{
    #region SerializeField
    [SerializeField] private float DigSpeed;
    #endregion

    #region PrivateField
    GameObject Parent;
    Rigidbody2D PlayerRigidBody;
    #endregion

    #region PublicField
    public GameObject HandleObject = null;
    #endregion

    private void Awake()
    {
        Parent = this.transform.parent.gameObject;
        PlayerRigidBody = this.transform.parent.GetComponent<Rigidbody2D>();
    }
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (HandleObject != null)
        { 
            HandleObject.GetComponent<Stone>().Hp -= DigSpeed * Time.deltaTime;
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Stone")
        {
            HandleObject = collision.gameObject;
        }
    }
}
