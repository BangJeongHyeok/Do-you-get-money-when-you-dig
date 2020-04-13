using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class PlayerMovement : MonoBehaviour
{
    #region SerializeField
    [SerializeField] private float MoveSpeed;
    [SerializeField]Rigidbody2D PlayerRigid;
    SFXPlayer sFXPlayer;
    #endregion

    #region PrivateField
    Vector2 DragStartPosition;
    public static bool isDead = false;
    bool isPipe = false;
    #endregion
    #region PublicField
    [HideInInspector] public GameObject HandleObject = null;
    #endregion
    // Start is called before the first frame update
    void Start()
    {
        sFXPlayer = GameObject.Find("SFXPlayer").GetComponent<SFXPlayer>();
    }

    // Update is called once per frame
    void Update()
    {
        if (!isPipe && !isDead)
        {
            if (HandleObject == null)
                PlayerRigid.velocity = new Vector3(PlayerRigid.velocity.x, -MoveSpeed * Time.deltaTime, 0f);
            else
            {
                HandleObject.GetComponent<Stone>().Hp -= 10 * Time.deltaTime;
                PlayerRigid.velocity = Vector3.zero;
                if(!sFXPlayer.audio_F.isPlaying)
                sFXPlayer.SoundManager_F("Dig");
            }
        }
    }

    void TeleportPipe(int PipeNumber)
    {
        Vector3 PipeVec = GameObject.Find("Pipe_Out (" + PipeNumber +")").transform.position;//찾아낸 번호의 나가는 파이프를 찾아냄
        gameObject.transform.parent.transform.position = new Vector3(PipeVec.x, PipeVec.y, 0);//거기로 위치이동
        isPipe = false;//파이프 상태 끝!
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Trash" || collision.gameObject.tag == "Mole")
        {
            //isDead = true;
            //PlayerRigid.velocity = Vector3.zero;

            GameManager.instance.CurHP -= 8;
            //GameManager.instance.doGameOver();
        }

        if(collision.gameObject.tag == "Stone")
        {
            if(collision.transform.position.y < this.transform.position.y)
            HandleObject = collision.gameObject;
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Stone")
        {
            HandleObject = null;
        }

        if (collision.gameObject.tag == "PipeIn")//파이프를 탄다면
        {
            isPipe = true;
            PlayerRigid.velocity = Vector3.zero;
            int pipenumber = int.Parse(collision.gameObject.name.Substring(9,1));//파이프마다 붙어있는 숫자를 찾아내고 저장
            StartCoroutine(Waiting(pipenumber));//코루틴으로 기다리기

        }
    }

    IEnumerator Waiting(int number)
    {
        yield return new WaitForSeconds(0.4f);
        TeleportPipe(number);//파이프 찾아내서 이동하는 함수
    }
}
