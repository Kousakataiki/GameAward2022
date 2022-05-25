using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SelectMapEnelgyManager : MonoBehaviour
{
    //�Q�[���I�u�W�F�N�g���X�g�N���X�錾
    [System.Serializable]
    class GameObjectList
    {
        public List<GameObject> tagList = new List<GameObject>();
    }

    //�ϐ�
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
        //������Ȃ��Ă����Ƃ��͂��Ȃ�
        if( openMapNum == 0
          )//  worldNumber  != 3)
        {
            isOpenEvent = false;
            return;
        }


        //������
        isOpenEvent = true;
        TagNum = 1;

        //�G�t�F�N�g�I��
        eventEffect.SetActive(true);

        //�G�t�F�N�g�̈ʒu��������
        eventEffect.transform.position = moveTagLists[openMapNum - 1].tagList[TagNum-1].transform.position;

        //�ړ�������ݒ�
        moveVec = getMoveVec(TagNum);
    }

    void updateEvent()
    {
        if (!isOpenEvent)
            return;

        //�ړ�����
        eventEffect.transform.position += moveVec * Time.deltaTime * moveSpeed;

        //�|�C���g�������Ă�����
        if (getMoveVec(TagNum) != moveVec)
        {
            //���̃^�O�͂܂����邩�`�F�b�N
            if (moveTagLists[openMapNum - 1].tagList.Count - 1 == TagNum)
            {
                //������ΏI��
                isOpenEvent = false;

                ParticleSystem particle = eventEffect.GetComponent<ParticleSystem>();
                var emission = particle.emission;
                emission.enabled = false;

                //eventEffect.SetActive(false);
                return;
            }

            //�L��΃^�[�Q�b�g��ύX
            else
            {
                //�^�O���X�V
                TagNum++;

                //�G�t�F�N�g�̈ʒu���C��
                eventEffect.transform.position = moveTagLists[openMapNum - 1].tagList[TagNum - 1].transform.position;

                //�ړ��������C��
                moveVec = getMoveVec(TagNum);
                
            }
        }
    }


    //�ړ������擾�֐�
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
