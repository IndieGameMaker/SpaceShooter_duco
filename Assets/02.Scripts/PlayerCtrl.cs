using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCtrl : MonoBehaviour
{
    //  1회 호출
    void Start()
    {

    }

    // 화면을 랜더링하는 주기
    void Update()
    {
        transform.position += new Vector3(0.0f, 0.0f, 0.1f);
        //transform.position = transform.position + new Vector3(0.0f, 1.0f, 0.1f);
    }
}
