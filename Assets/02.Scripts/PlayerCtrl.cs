using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCtrl : MonoBehaviour
{
    float h;    // 실수값을 저장할 수 있는 변수 선언
    float v;

    //  1회 호출
    void Start()
    {

    }

    // 화면을 랜더링하는 주기
    void Update()
    {
        h = Input.GetAxis("Horizontal");
        v = Input.GetAxis("Vertical");
        Debug.Log("h=" + h);
        Debug.Log("v=" + v);

        transform.position += new Vector3(0.0f, 0.0f, 0.1f);

    }
}
