using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SelectMapEnelgyManager : MonoBehaviour
{
    //ゲームオブジェクトリストクラス宣言
    [System.Serializable]
    class GameObjectList
    {
        public List<GameObject> tagList = new List<GameObject>();
    }

    //変数
    [SerializeField] List<GameObjectList>   moveTagLists;
    [SerializeField] List<GameObjectList>   enelgyCubeList;
    [SerializeField] GameObject             eventEffect;

    [SerializeField] Vector3                moveVec;

    [SerializeField] bool                   isOpenEvent = false;
    [SerializeField] int                    worldNumber = 3;
    [SerializeField] int                    openMapNum;//= 2;
    [SerializeField] int                    TagNum;
    [SerializeField] float                  moveSpeed = 1;

    float enelgyFadeTime = 0;
    float enelgyFadeSpeed = 0.1f;
    // Start is called before the first frame update
    void Start()
    {
        initEvent();
        setEnelgyCubeMode();
    }

    // Update is called once per frame
    void Update()
    {
        updateEvent();
        setEnelgyCubeMode();
    }

    void initEvent()
    {
        //解放しなくていいときはしない
        if( openMapNum == 0
          )//  worldNumber  != 3)
        {
            isOpenEvent = false;
            return;
        }


        //初期化
        isOpenEvent = true;
        TagNum = 1;

        //エフェクトオン
        eventEffect.SetActive(true);

        //エフェクトの位置を初期化
        eventEffect.transform.position = moveTagLists[openMapNum - 1].tagList[TagNum-1].transform.position;

        //移動方向を設定
        moveVec = getMoveVec(TagNum);
    }

    void updateEvent()
    {
        if (!isOpenEvent)
            return;

        //移動処理
        eventEffect.transform.position += moveVec * Time.deltaTime * moveSpeed;

        //ポイントをこえていたら
        if (getMoveVec(TagNum) != moveVec)
        {
            //次のタグはまだあるかチェック
            if (moveTagLists[openMapNum - 1].tagList.Count - 1 == TagNum)
            {
                //無ければ終了
                isOpenEvent = false;

                ParticleSystem particle = eventEffect.GetComponent<ParticleSystem>();
                var emission = particle.emission;
                emission.enabled = false;

                //eventEffect.SetActive(false);
                return;
            }

            //有ればターゲットを変更
            else
            {
                //タグを更新
                TagNum++;

                //エフェクトの位置を修正
                eventEffect.transform.position = moveTagLists[openMapNum - 1].tagList[TagNum - 1].transform.position;

                //移動方向を修正
                moveVec = getMoveVec(TagNum);
                
            }
        }
    }


    //移動方向取得関数
    Vector3 getMoveVec(int next)
    {
        Vector3 TergetPos = moveTagLists[openMapNum - 1].tagList[next].transform.position;
        Vector3 NowPos    = eventEffect.transform.position;

        Vector3 vec;
        vec.x = TergetPos.x - NowPos.x;
        vec.y = TergetPos.y - NowPos.y;
        vec.z = 0;

        vec.Normalize();
        return vec;
    }

    void setEnelgyCubeMode()
    {
        int MaterialOnCount = openMapNum;
        if (isOpenEvent)
        {
            MaterialOnCount--;
        }

        for(int i = 0; i < enelgyCubeList.Count; ++i)
        {
            for(int j = 0; j < enelgyCubeList[i].tagList.Count; ++j)
            {
                if (i < MaterialOnCount)
                {
                    enelgyCubeList[i].tagList[j].GetComponent<Renderer>().material.SetInt("_on",1);
                }
                else
                {
                    enelgyCubeList[i].tagList[j].GetComponent<Renderer>().material.SetInt("_on", 0);
                }
                if (!isOpenEvent)
                {

                    enelgyFadeTime += enelgyFadeSpeed * Time.deltaTime;
                    if (enelgyFadeTime > 1)
                        enelgyFadeTime = 1.0f;
                    if (i == openMapNum-1)
                    {
                        enelgyCubeList[i].tagList[j].GetComponent<Renderer>().material.SetFloat("_pow",Mathf.Pow( enelgyFadeTime,2));
                    }
                    else
                    {
                        enelgyCubeList[i].tagList[j].GetComponent<Renderer>().material.SetFloat("_pow", 1);
                    }

                }

            }

        }


    }

}
