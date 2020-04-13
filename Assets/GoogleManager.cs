using System.Collections;
using System.Collections.Generic;
using UnityEngine;
// Text UI 사용
using UnityEngine.UI;
using GooglePlayGames;
using GooglePlayGames.BasicApi;
public class GoogleManager : MonoBehaviour
{


    public static GoogleManager instance = null;
    bool loggin = false;
    void Awake()
    {

        instance = this;
        if (loggin == false)
        {
            GoogleManager.instance.loggin = true;
              OnLogin();


        }
    }


    // Start is called before the first frame update
    void Start()
    {
        PlayGamesPlatform.InitializeInstance(new PlayGamesClientConfiguration.Builder().Build());
        PlayGamesPlatform.DebugLogEnabled = true;
        PlayGamesPlatform.Activate();
        Social.localUser.Authenticate((bool success) =>
        {
            if (success)
            {
                print("성공");
            }
            else print("11");
        });
    }



    public void RankButtonClick()

    {
        PlayGamesPlatform.Activate();
        Social.localUser.Authenticate(AuthenticateHandler);

    }

    void AuthenticateHandler(bool isSuccess)

    {

        if (isSuccess)

        {

            int highScore = PlayerPrefs.GetInt("HighScore", 0);

            Social.ReportScore((long)highScore, GPGSIds.leaderboard_leaderboard, (bool success) =>

            {

                if (success)

                {

                    PlayGamesPlatform.Instance.ShowLeaderboardUI(GPGSIds.leaderboard_leaderboard);

                }

                else

                {

                    // upload highscore failed

                }

            });

        }

        else

        {
            print("실패");
            // login failed

        }

    }


    public void OnLogin()
    {
        if (!Social.localUser.authenticated)
        {
            Social.localUser.Authenticate((bool bSuccess) =>
            {
                if (bSuccess)
                {
                    Debug.Log("Success : " + Social.localUser.userName);
                }
                else
                {
                    Debug.Log("Fall");
                }
            });
        }
    }

    public void OnLogOut()
    {
        ((PlayGamesPlatform)Social.Active).SignOut();
    }
}

