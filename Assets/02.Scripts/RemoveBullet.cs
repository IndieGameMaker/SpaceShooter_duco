using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RemoveBullet : MonoBehaviour
{
    void OnCollisionEnter(Collision coll)
    {
        if (coll.collider.tag == "BULLET")
        {
            // 총알 삭제
            Destroy(coll.gameObject);
        }
    }


}
