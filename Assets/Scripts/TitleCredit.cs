using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TitleCredit : MonoBehaviour
{
    public GameObject Credit;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void CreditOn()
    {
        Credit.SetActive(true);
    }
    public void CreditOff()
    {
        Credit.SetActive(false);
    }
}
