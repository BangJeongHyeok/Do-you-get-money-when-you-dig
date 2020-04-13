using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class ScreenDrag : MonoBehaviour
{
    [SerializeField]
    GameObject Player;
    [SerializeField]
    float SideMoveSpeed;
    

    GameObject PlayerHead;
    Vector3 DragStartPosition;
    float BetweenDistance;
    float HeadRotation;
    Rigidbody2D PlayerRigid;
    Physics2D PlayerPhysics;

    float PlayerPrevPositionX;//이전 X
    float PlayerNowPositionX;//현재 X
    enum TouchState
    {
        TouchBegin,
        Touching,
        TouchEnd
    }
    TouchState Touch;

    // Start is called before the first frame update
    void Start()
    {
        PlayerRigid = Player.GetComponent<Rigidbody2D>();
        PlayerHead = Player.transform.GetChild(0).gameObject;
        Touch = TouchState.TouchEnd;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0))//클릭
            Touch = TouchState.TouchBegin;
        else if (Input.GetMouseButtonUp(0))//땟을때
            Touch = TouchState.TouchEnd;
        else if (Input.GetMouseButton(0))//누르는 중
            Touch = TouchState.Touching;


        PlayerNowPositionX = Input.mousePosition.x;//현재 마우스 위치
        int b =  LayerMask.GetMask("Stone");
        int d = LayerMask.GetMask("Wall");
        if (Touch == TouchState.Touching)
        {
            Vector3 a = new Vector3(PlayerNowPositionX - PlayerPrevPositionX, 0, 0);
            a.Normalize();

            if (a.x > 0)
            {

                RaycastHit2D c = Physics2D.BoxCast(new Vector2(Player.transform.position.x, Player.transform.position.y), new Vector2(1.76f, 2), 0, Vector2.right, Mathf.Abs(PlayerNowPositionX - PlayerPrevPositionX) * Time.deltaTime, b);
                if (c == false)
                {
                    PlayerRigid.position += new Vector2(PlayerNowPositionX - PlayerPrevPositionX, 0f) * Time.deltaTime;

                }
            }
            else if(a.x < 0)
            {

                RaycastHit2D c = Physics2D.BoxCast(new Vector2(Player.transform.position.x, Player.transform.position.y), new Vector2(1.76f, 2), 0, Vector2.left, Mathf.Abs(PlayerNowPositionX - PlayerPrevPositionX) * Time.deltaTime, b);

                if (c == false )
                {
                    PlayerRigid.position += new Vector2(PlayerNowPositionX - PlayerPrevPositionX, 0f) * Time.deltaTime;

                }
            }
            if(PlayerRigid.position.x > 7.2f)
            {
                PlayerRigid.position = new Vector2(7.2f, PlayerRigid.position.y);
            }
            if (PlayerRigid.position.x < -7.2f)
            {
                PlayerRigid.position = new Vector2(-7.2f, PlayerRigid.position.y);
            }
            //Debug.Log(PlayerNowPositionX - PlayerPrevPositionX);
        }
        PlayerPrevPositionX = Input.mousePosition.x;//전 프레임 마우스 위치
                    //Debug.DrawRay(new Vector2(Player.transform.parent.position.x, Player.transform.parent.position.y),Vector2.right);
    }
}
