using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RemoveBullet : MonoBehaviour
{
    public GameObject sparkEffect;

    void OnCollisionEnter(Collision coll)
    {
        if (coll.collider.tag == "BULLET")
        {
            // 충돌 지점
            Vector3 pos = coll.GetContact(0).point;
            // 충돌 지점의 법선벡터(수직을 이루는 벡터)
            Vector3 normal = coll.GetContact(0).normal;

            // 스파크 이펙트 생성
            // Instantiate(생성할 객체, 좌표, 각도)
            // 쿼터니언(Quaternion) : 유니티에서 사용하는 각도의 단위
            Quaternion rot = Quaternion.LookRotation(normal);

            Instantiate(sparkEffect, pos, rot);



            // 총알 삭제
            Destroy(coll.gameObject);
        }
    }


}
