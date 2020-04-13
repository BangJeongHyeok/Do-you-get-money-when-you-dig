using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Coin : MonoBehaviour
{
    float CoinX;
    float CoinRotation;
    SFXPlayer sFXPlayer;
    // Start is called before the first frame update
    void Start()
    {
        sFXPlayer = GameObject.Find("SFXPlayer").GetComponent<SFXPlayer>();
        CoinX = Random.Range(0, 12) - 6;
        CoinRotation = Random.Range(0, 180) - 90;
        gameObject.transform.position = new Vector3(CoinX, this.transform.position.y, 0);
        gameObject.transform.rotation = new Quaternion(0, 0, CoinRotation, 0);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.tag == "Player")
        {
            if(gameObject.name == "Bok")
                Score.score += 50;
            else
                Score.score += 10;
            gameObject.SetActive(false);
        }
        sFXPlayer.SoundManager_F("Coin");
    }

}
