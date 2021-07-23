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
        StartCoroutine(ShowMuzzleFlash());
    }

    // 총구화염 효과를 깜빡거리는 로직 (코루틴)
    IEnumerator ShowMuzzleFlash()
    {
        // MuzzleFlash Offset을 변경
        Vector2 offset = new Vector2(Random.Range(0, 2), Random.Range(0, 2)) * 0.5f;
        //muzzleFlash.material.SetTextureOffset("_MainTxt", offset);
        muzzleFlash.material.mainTextureOffset = offset;

        // MuzzleFlash 회전
        Quaternion rot = Quaternion.Euler(Vector3.forward * Random.Range(0, 360));
        muzzleFlash.transform.localRotation = rot;

        // MuzzleFlash 스케일 변경
        Vector3 scale = Vector3.one * Random.Range(1.0f, 2.5f);
        /*
            float scale = Random.Range(1.0f, 2.5f);
            Vector3 scale = new Vector3(scale, scale, scale);
        */
        muzzleFlash.transform.localScale = scale;

        // MuzzleFlash를 활성
        muzzleFlash.enabled = true;
        // Waiting...
        yield return new WaitForSeconds(0.2f);
        // MuzzleFlash를 비활성
        muzzleFlash.enabled = false;
    }
}
