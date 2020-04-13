using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Score : MonoBehaviour
{
    [SerializeField] GameObject Player;
    public static float score = 0;
    Text ScoreText;
    // Start is called before the first frame update
    void Start()
    {
        ScoreText = transform.GetComponent<Text>();
    }

    // Update is called once per frame
    void Update()
    {
        if(!GameManager.instance.isGameOver)
            score += Time.deltaTime * 10;
        ScoreText.text = Mathf.Round(score ).ToString();
    }
}
