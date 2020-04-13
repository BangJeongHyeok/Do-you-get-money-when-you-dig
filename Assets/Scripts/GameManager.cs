using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
public class GameManager : MonoBehaviour
{
    public static GameManager instance;
    public GameObject ScoreText;

    public GameObject GameOver;
    public float MaxHP;
    public float CurHP;
    public bool isGameOver;
    string b;
    public float LookHP;
    private float CurTime = 0f;
    SFXPlayer sFXPlayer;
    GameObject HPBar;

    private void Awake()
    {
        instance = this;
    }

    // Start is called before the first frame update
    void Start()
    {
        MaxHP = 100f;
        CurHP = 100f;
        LookHP = 100f;

        isGameOver = false;
        sFXPlayer = GameObject.Find("SFXPlayer").GetComponent<SFXPlayer>();
        HPBar = GameObject.Find("HP_Bar");
    }

    // Update is called once per frame
    void Update()
    {
        if (isGameOver == false)
        {
            CurTime += Time.deltaTime;
            if (CurTime > 2f)
            {
                CurTime = CurTime - 1;
                CurHP -= 1.5f;
                isGameOver = false;
            }


            if (CurHP <= 0)
            {
                sFXPlayer.SoundManager_F("Die");
                isGameOver = true;
                b = Mathf.Round(Score.score * 10).ToString();
            }
        }
        else
        {
            
            doGameOver();
        }
        LookHP = Mathf.Lerp(LookHP, CurHP, Time.deltaTime * 10);



        PlayerHP();
    }

    public void ChangeScene(string SceneName)
    {
        //Time.timeScale = 1f;
        UnityEngine.SceneManagement.SceneManager.LoadScene(SceneName);
    }
    public void ResetScore()
    {
        Score.score = 0;
    }
    public void doGameOver()
    {
        GameObject.Find("BGMManager").GetComponent<AudioSource>().Stop();
        ScoreText.GetComponent<Text>().text = b;
        GameOver.SetActive(true);
        GameOver.GetComponent<Animator>().enabled = true;
        //Time.timeScale = 0f;
    }

    public void PlayerHP()
    {
        HPBar.GetComponent<Slider>().value = LookHP/MaxHP;
    }



}
