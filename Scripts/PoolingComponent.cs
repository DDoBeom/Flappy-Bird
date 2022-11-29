using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

public class PoolingComponent : MonoBehaviour
{
    //const int SIZE = 5;

    public GameObject column;       //기둥 오브젝트

    int size = 5;                   //총 생성될 기둥 갯수

    [SerializeField]                
    float spawnRate = 3;            //기둥 생성 간격
    float time = 0;

    [SerializeField]
    float minY = -1;                //기둥 최소 높이값
    [SerializeField]
    float maxY = 3.25f;             //기둥 최대 높이값

    [SerializeField]
    GameObject[] columnsArr;        //기둥 담아둘 배열
    int currentColumn = 0;          //가장 최근 사용된 기둥의 인덱스

    Vector2 pos = new Vector2(20, 100);       //생성 위치
    float posX = 10;                        //재사용될 때 스폰 위치
    float posY = 0;                         //재사용될 때 스폰 위치


    // Start is called before the first frame update
    void Start()
    {
        init();
    }

    // Update is called once per frame
    void Update()
    {
        if(!GameManager.gm.isGameStart ||GameManager.gm.isGameOver) return;

        spawn();
    }

    private void init()
    {
        if (column == null)
        column = (GameObject)AssetDatabase.LoadAssetAtPath("Assets/Pretaps/Columns.prefab", typeof(GameObject));

        columnsArr = new GameObject[size];      //배열에 기둥 사이즈만큼 공간 배정

        for (int i = 0; i < columnsArr.Length; i++)
        {
            columnsArr[i] = Instantiate(column, pos, Quaternion.identity);
        }
        
    }

    void spawn()
    {
        time += Time.deltaTime;

        if (time >= spawnRate)
        {
            posY = Random.Range(minY, maxY);            //높이값을 랜덤으로 설정  
            columnsArr[currentColumn].transform.position = new Vector2(posX, posY);

            currentColumn++;

            if (currentColumn >= size) currentColumn = 0;

            time = 0;
        }
    }

}
