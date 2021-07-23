using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(AudioSource))]
public class FireCtrl : MonoBehaviour
{
    // 총알 프리팹을 저장할 변수
    public GameObject bulletPrefab;
    // 총알을 생성할 위치정보를 저장할 변수
    public Transform firePos;

    // AudioSource 컴포넌트를 추출해 저장할 변수
    private new AudioSource audio;
    // 음원파일을 저장할 변수를 선언
    public AudioClip fireSfx;

    // MuzzleFlash 게임오브젝트에 추가된 MeshRenderer 컴포넌트를 저장할 변수
    public MeshRenderer muzzleFlash;

    void Start()
    {
        audio = GetComponent<AudioSource>();
        muzzleFlash = firePos.GetComponentInChildren<MeshRenderer>();
        muzzleFlash.enabled = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            Fire();
        }
    }

    void Fire()
    {
        // 총알을 생성
        // Instantiate(생성할 프리팹, 위치, 각도)
        Instantiate(bulletPrefab, firePos.position, firePos.rotation);
        // 총소리 발생
        audio.PlayOneShot(fireSfx, 0.8f);
        // 총구화염 효과
        ShowMuzzleFlash();
    }

    // 총구화염 효과를 깜빡거리는 로직
    void ShowMuzzleFlash()
    {
        // MuzzleFlash를 활성

        // MuzzleFlash를 비활성
    }
}
