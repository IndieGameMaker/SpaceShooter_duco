using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FireCtrl : MonoBehaviour
{
    // 총알 프리팹을 저장할 변수
    public GameObject bulletPrefab;
    // 총알을 생성할 위치정보를 저장할 변수
    public Transform firePos;

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            // 총알을 생성
            // Instantiate(생성할 프리팹, 위치, 각도)
            Instantiate(bulletPrefab, firePos.position, firePos.rotation);
        }
    }
}