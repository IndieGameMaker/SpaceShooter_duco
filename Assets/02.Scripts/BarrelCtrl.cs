using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BarrelCtrl : MonoBehaviour
{
    private int hitCount = 0;

    // 배열 타입 (Array Type)
    [System.NonSerialized]
    public int[] monsterPower;
    // monsterPower[2] --> 300
    public string[] monsterName;
    // monsterName[1] --> "Goblin"
    public float[] monsterDamage;

    // 텍스처(Texture)를 저장하기 위한 배열을 선언
    public Texture[] textures;
    // textures[0], textures[1], .... textures[99]

    [SerializeField]
    private new MeshRenderer renderer;

    // 폭발효과 프리팹을 저장할 변수
    public GameObject expEffect;

    void Start()
    {
        // 텍스처 -> 머티리얼 -> 메시(Mesh)
        // 자신의 하위에 있는 MeshRenderer 컴포넌트를 추출
        renderer = this.gameObject.GetComponentInChildren<MeshRenderer>();

        // 난수 발생
        /*
            Random.Range(1, 10)       --> 1, 2, 3, ..., 9
            Random.Range(1.0f, 10.0f) --> 1.0f , ..., 10.0f.
        */
        int idx = Random.Range(0, textures.Length); //(0, 3) --> 0, 1, 2

        // MeshRenderer 컴포넌트 접근 (메시랜더러.머티리얼.텍스처 = 텍스처)
        renderer.material.mainTexture = textures[idx];
    }

    void OnCollisionEnter(Collision coll)
    {
        if (coll.collider.CompareTag("BULLET"))  // O
        {
            if (++hitCount == 3)
            {
                ExpBarrel();
            }
        }
    }

    void ExpBarrel()
    {
        // Rigidbody 컴포넌트를 추가
        Rigidbody rb = this.gameObject.AddComponent<Rigidbody>();
        // 수직의 힘을 가함
        rb.AddForce(Vector3.up * 2000.0f);
        // 3초후에 베럴을 삭제
        Destroy(this.gameObject, 3.0f);

        // 폭발효과의 불규칙한 회전값을 생성
        Quaternion rot = Quaternion.Euler(0, Random.Range(0, 360), 0);
        // Quaternion rot = Quaternion.Euler(Vector3.up * Random.Range(0,360));

        // 폭발효과 프리팹을 생성
        GameObject exp = Instantiate(expEffect, transform.position, rot);
        Destroy(exp, 5.0f);
    }
}
