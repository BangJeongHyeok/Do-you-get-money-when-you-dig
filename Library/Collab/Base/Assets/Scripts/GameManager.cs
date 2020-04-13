using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager instnace;

    public GameObject GameOver;
    public float MaxHP;
    public float CurHP;
    public bool isGameOver;
    public float LookHP;
    private float CurTime = 0f;
    public int Score;


    private void Awake()
    {
        instnace = this;
    }

    // Start is called before the first frame update
    void Start()
    {
        MaxHP = 100f;
        CurHP = 100f;
        LookHP = 100f;
        Score = 0;
        isGameOver = false;
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
                MainSound.instnace.PlayDead();
                isGameOver = true;
                GameOver.SetActive(true);
                StartCoroutine(a());
            }
        }
        else
        {
            GameOver.GetComponent<Animator>().enabled = true;
            Time.timeScale = 0f;
        }
        LookHP = Mathf.Lerp(LookHP, CurHP, Time.deltaTime * 10);

    }

    public void ChangeScene(string SceneName)
    {
        UnityEngine.SceneManagement.SceneManager.LoadScene(SceneName);
    }

    IEnumerator a()
    {
        yield return new WaitForSeconds(3f);

        UnityEngine.SceneManagement.SceneManager.LoadScene("GameOverScene");
    }

}
