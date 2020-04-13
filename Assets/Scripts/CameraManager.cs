using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraManager : MonoBehaviour
{
    public static CameraManager instance;
    #region PrivateField
    Camera mainCamera;
    public GameObject Player;
    private PlayerMovement playerMovement;
    float PlayerY;
    float offset;
    #endregion

    // Start is called before the first frame update
    private void Awake()
    {
        instance = this;
        mainCamera = Camera.main;
    }

    void Start()
    {
        playerMovement = Player.transform.GetComponent<PlayerMovement>();

    }

    // Update is called once per frame
    void Update()
    {
        PlayerY = Player.transform.position.y;
        transform.position = new Vector3(0, PlayerY - offset, -10);

        if (playerMovement.HandleObject == null)
        {
            offset = Mathf.Lerp(offset, 8, Time.deltaTime * 6);
        }
        else
        {
            offset = Mathf.Lerp(offset, 10, Time.deltaTime * 6);
        }
    }

    public void CameraShake(float _amount, float _duration)
    {
        StartCoroutine(Shake(_amount, _duration));
    }


    public IEnumerator Shake(float _amount, float _duration)
    {
        //Vector3 originPos = transform.localPosition;
        float timer = 0;
        while (timer <= _duration)
        {
            transform.localPosition = (Vector3)Random.insideUnitCircle * _amount + transform.localPosition;

            timer += Time.deltaTime;
            yield return null;
        }
        //transform.localPosition = originPos;

    }
}
