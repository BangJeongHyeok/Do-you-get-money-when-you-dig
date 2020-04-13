using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.SceneManagement;
public class TitleScene : MonoBehaviour
{
    bool a = false;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        //if(Input.GetMouseButtonDown(0) && !EventSystem.current.IsPointerOverGameObject())
        //{
        //    Debug.Log("sex");
            
        //}

        if(a == true)
        {
            Score.score = 0;
            if (this.GetComponent<Animator>().GetCurrentAnimatorStateInfo(0).normalizedTime > 0.99f)
            {
                SceneManager.LoadScene("HyeokScene");
            }
        }
    }

    public void StartButtonPress()
    {
        a = true;
        this.GetComponent<Animator>().enabled = true;
    }
}
