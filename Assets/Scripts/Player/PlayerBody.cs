using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerBody : MonoBehaviour
{
    #region SerializeField
    [SerializeField] private float MoveSpeed;
    #endregion

    #region PrivateField
    GameObject Parent = null;
    Rigidbody2D ParentRigidBody;
    PlayerDig playerDig;
    #endregion

    private void Awake()
    {
        Parent = this.transform.parent.gameObject;
        ParentRigidBody = Parent.GetComponent<Rigidbody2D>();
        playerDig = Parent.GetComponentInChildren<PlayerDig>();
    }
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (playerDig.HandleObject == null)
            ParentRigidBody.velocity = new Vector3(ParentRigidBody.velocity.x, -MoveSpeed * Time.deltaTime, 0f);
        else
        {
            ParentRigidBody.velocity = Vector3.zero;
        }
    }
}
