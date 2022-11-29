using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Column : MonoBehaviour
{
    bool isOn = false;
    AudioSource audioSource;

    private void Start()
    {
        audioSource = GetComponent<AudioSource>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            if (!isOn)
            {
                isOn = true;
                GameManager.gm.GetScore();          //점수 획득 함수 호출
                StartCoroutine(ResetOn());
                audioSource.Play();
            }
        }
    }

    private IEnumerator ResetOn()
    {
        yield return new WaitForSeconds(1);
        isOn = false;
    }
}
