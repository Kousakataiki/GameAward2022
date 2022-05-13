using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StageArea : MonoBehaviour
{
    [SerializeField] float AreaWidth;

    MainCamera cameraScr;
    Vector3 cameraPos;
    public Vector3 CameraPos { get { return cameraPos; } }

    float Width;
    float Height;
    float ColWidth;
    float ColHeight;

    private void OnValidate()
    {
        // AreaWidth����G���A�T�C�Y���v�Z
        SetAreaSize();
    }

    private void OnDrawGizmos()
    {
        //----- �`��͈͂̕\�� -----
        Gizmos.color = new Color(1, 0, 0, 1);
        Gizmos.DrawWireCube(transform.position, new Vector3(Width, Height, 0));

        //----- �����蔻��̕\�� -----
        Gizmos.color = new Color(0, 1, 0, 1);
        Gizmos.DrawWireCube(transform.position, new Vector3(ColWidth, ColHeight, 0));
    }


    void Awake()
    {
        // AreaWidth����G���A�T�C�Y���v�Z
        SetAreaSize();

        //----- ����p����J�����ʒu���v�Z -----
        Camera camera = GameObject.Find("Main Camera").GetComponent<Camera>();
        float distance = Height * 0.5f / Mathf.Tan(camera.fieldOfView * 0.5f * Mathf.Deg2Rad);
        cameraPos = transform.position + new Vector3(0, 0, -distance);

        cameraScr = camera.gameObject.GetComponent<MainCamera>();

        //----- �����蔻��̐ݒ� -----
        BoxCollider col = GetComponent<BoxCollider>();
        if (col == null)
        {
            col = gameObject.AddComponent<BoxCollider>();
        }
        col.size = new Vector3(ColWidth, ColHeight, 1);
        col.isTrigger = true;
    }

    void Update()
    {
    }


    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.tag == "Player")
        {
            cameraScr.SetTargetPos(cameraPos);
        }
    }

    void SetAreaSize()
    {
        Width = AreaWidth;
        Height = Width * (9f / 16f);
        ColWidth = Mathf.Max(0f, AreaWidth - 1.0f);
        ColHeight = ColWidth * (9f / 16f);
    }
}
