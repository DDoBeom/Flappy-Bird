using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TextScaleChange : MonoBehaviour
{
    RectTransform text;
    
    [SerializeField]
    float minSize = 1;
    [SerializeField]
    float maxSize = 4;

    bool isMax = false;         //사이즈에 따라 커질 지 작아질 지 판단할 변수
    float time = 0;             //사이즈 변경

    [SerializeField]
    float speed = 0.75f;        //커지고 작아지는 속도


    // Start is called before the first frame update
    void Start()
    {
        text = GetComponent<RectTransform>();           //같은 게임 오브젝트 내에 있는 렉트 트랜스폼 컴포넌트를 가져옴
    }

    // Update is called once per frame
    void Update()
    {
        SizeChange();
    }

    void SizeChange()
    {
        if(isMax == false)      //isMax 같은 조건을 의미
        {
            text.localScale = Vector3.Lerp(new Vector3(minSize, minSize, minSize), new Vector3(maxSize, maxSize, maxSize), time += Time.deltaTime * speed);

            if (time >= 1)
            {
                time = 0;
                isMax = true;
            }
        }
        else
        {
            text.localScale = Vector3.Lerp(new Vector3(maxSize, maxSize, maxSize), new Vector3(minSize, minSize, minSize), time += Time.deltaTime * speed);

            if (time >= 1)
            {
                time = 0;
                isMax = false;
            }
        }
    }

}
