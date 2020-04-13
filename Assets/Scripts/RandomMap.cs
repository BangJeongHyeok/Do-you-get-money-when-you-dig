using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RandomMap : MonoBehaviour
{

    [SerializeField] GameObject Player;
    [SerializeField] GameObject[] Map;
    float CreateY = 0;
    int MapEditor = 0;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Player.transform.position.y <= CreateY + 50)
        {
            MapEditor = ExceptRandomNumber(MapEditor, 1, 7);//맵 갯수까지
            Map[MapEditor].SetActive(true);
            Map[MapEditor].transform.position = new Vector3(0, CreateY, 0);
                    //Instantiate(Map[MapEditor], new Vector3(0, CreateY,0), new Quaternion(0,0,0,0));
            CreateY -= 70;
        }
    }

    int ExceptRandomNumber(int ExceptionNumber, int From, int To)//하나의 값을 제외하고 난수를 찾는 함수
    {
        int temp;
        while (true)
        {
           temp = Random.Range(From, To);
            if (temp != ExceptionNumber)//제외하는 값이 아니라면
                break;
        }
        return temp;
    }
}
