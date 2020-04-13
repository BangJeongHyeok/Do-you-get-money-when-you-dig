using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class ScreenDrag : MonoBehaviour, IDragHandler, IEndDragHandler
{
    [SerializeField]
    GameObject Player;
    [SerializeField]
    float SideMoveSpeed;
    

    GameObject PlayerHead;
    Vector2 DragStartPosition;
    float BetweenDistance;
    float HeadRotation;
    Rigidbody2D PlayerRigid;

    // Start is called before the first frame update
    void Start()
    {
        PlayerRigid = Player.GetComponent<Rigidbody2D>();
        PlayerHead = Player.transform.GetChild(0).gameObject;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void OnDrag(PointerEventData eventData)
    {
        PlayerRigid.velocity = new Vector3(eventData.delta.x * SideMoveSpeed * 0.1f , PlayerRigid.velocity.y, 0);
        Debug.Log(eventData.delta.x);
    }

    public void OnEndDrag(PointerEventData eventData)
    {
        PlayerRigid.velocity = new Vector3(0, PlayerRigid.velocity.y, 0);
        PlayerHead.transform.rotation = new Quaternion(0, 0, 0, 0);
    }
}
