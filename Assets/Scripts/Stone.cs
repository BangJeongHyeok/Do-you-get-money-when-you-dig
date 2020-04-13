using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class Stone : MonoBehaviour
{


    #region SerializeField
    [SerializeField] Sprite Cheese1;
    [SerializeField] Sprite Cheese2;
    [SerializeField] Sprite Cheese3;
    SFXPlayer sFXPlayer;
    [SerializeField] GameObject CheeseEffect;
    #endregion

    #region PublicField
    GameObject TextObject;
    [HideInInspector]public float Hp;
    Text HpText;
    #endregion

    // Start is called before the first frame update
    void Start()
    {
        
        //gameObject.transform.GetChild(0).gameObject.GetComponent<Canvas>().worldCamera = Camera.main;//Canvas의 MainCamera를 찾아주는 코드, 이걸쓰면 오브젝트의 위치가 엉킨다.
        sFXPlayer = GameObject.Find("SFXPlayer").GetComponent<SFXPlayer>();

        switch (Random.Range(1,4))
        {
            case 1:
                gameObject.GetComponent<SpriteRenderer>().sprite = Cheese1;
                break;
            case 2:
                gameObject.GetComponent<SpriteRenderer>().sprite = Cheese2;
                break;
            case 3:
                gameObject.GetComponent<SpriteRenderer>().sprite = Cheese3;
                break;
        }
        Hp = Random.Range(4, 25);
        TextObject = this.transform.GetChild(0).transform.GetChild(0).gameObject;
        HpText = TextObject.GetComponent<Text>();
    }

    // Update is called once per frame
    void Update()
    {
        if(GameManager.instance.isGameOver == true)
        {
            gameObject.SetActive(false);
        }
        Vector2 textpos = Camera.main.WorldToScreenPoint(this.gameObject.transform.position);
        TextObject.transform.position = new Vector3(textpos.x, textpos.y,0f);

        if (Hp < 0)
        {
            Camera.main.GetComponent<CameraManager>().CameraShake(0.16f, 0.2f);
            sFXPlayer.SoundManager_F("DigFinish");
            Instantiate(CheeseEffect, new Vector3(transform.position.x, transform.position.y, transform.position.z),
                new Quaternion(0,0,0,0));
            gameObject.SetActive(false);
            GameManager.instance.CurHP += 3f;
        }
        HpText.text = ((int)Hp).ToString();
    }

    private void OnEnable()
    {
        Hp = Random.Range(4, 25);
    }
}
