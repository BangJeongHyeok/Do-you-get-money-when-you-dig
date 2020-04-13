using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoleAdmin : MonoBehaviour
{
    #region SerializeField
    [SerializeField] float MinTime;
    [SerializeField] float MaxTime;

    [SerializeField] float MinDigSpeed;
    [SerializeField] float MaxDigSpeed;
    [SerializeField] public GameObject MolePrefebs;
    #endregion

    #region PrivateField
    float CurTime;
    float TargetTime;
    #endregion

    #region PublicField
    #endregion

    private void Awake()
    {
        CurTime = 0f;
    }

    // Start is called before the first frame update
    void Start()
    {
        TargetTime = Random.Range(MinTime, MaxTime);
    }

    // Update is called once per frame
    void Update()
    {
        CurTime += Time.deltaTime;
        if (CurTime >= TargetTime)
        { 
            CurTime -= TargetTime;
            TargetTime = Random.Range(MinTime, MaxTime);
            int Dir = Random.Range(0, 100) > 50 ? -1 : 1;
            AddMole(Dir);
        }

    }


    void AddMole(int Dir)
    {
        GameObject Mole = GameObject.Instantiate(MolePrefebs);
        Mole.transform.position = new Vector3(0f + -Dir * 10f, Random.Range(Camera.main.transform.position.y -10f, Camera.main.transform.position.y - 16f),100f);
        Mole.GetComponent<Mole>().Dir = Dir;
        Mole.GetComponent<Mole>().DigSpeed = Random.Range(MinDigSpeed, MaxDigSpeed);

    }
}
