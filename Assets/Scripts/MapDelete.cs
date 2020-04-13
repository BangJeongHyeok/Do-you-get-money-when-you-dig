using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MapDelete : MonoBehaviour
{
    GameObject Player;
    [SerializeField]GameObject[] ChildObject = new GameObject[20];//자식 오브젝트
                             // Start is called before the first frame update

    void Awake()
    {
        for (int number = 0; number < gameObject.transform.childCount; number++)
        {
            ChildObject[number] = gameObject.transform.GetChild(number).gameObject;
        }
        Player = GameObject.Find("Player 1");   
        
    }

    void Update()
    {
        if (gameObject.transform.position.y >= Player.transform.position.y + 60)
            gameObject.SetActive(false);
    }

    private void OnEnable()//켜질때
    {
        Debug.Log("On");
        for (int Objnumber = 0; Objnumber < gameObject.transform.childCount; Objnumber++)//모든 오브젝트를 돌면서
        {
            ChildObject[Objnumber].gameObject.SetActive(true);//꺼진 옵젝들을 다시 켜둠
        }
    }
}
