using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMoveAround : MagnetType
{
    public enum Dir
    {
        L = 0,
        R,
        MAX_DIR
    }

    // ���W�b�h�{�f�B
    Rigidbody rb;

    // �G�p�����[�^
    [SerializeField] public float fSpd;
    [SerializeField] public float fSmooth;
    public Vector3 vDir = Vector3.zero;
    private Quaternion Rot;
    // �t���O
    private bool bN = false;    
    private bool bS = false;
    public Dir dir;
    //GameObject goParent;



    // Start is called before the first frame update
    void Start()
    {
        // �e�R���|�[�l���g�擾
        //goParent = transform.parent.gameObject;
        //rb = goParent.GetComponent<Rigidbody>();
        
        // �R���|�[�l���g�擾
        rb = GetComponent<Rigidbody>();

        // �����Ă������������
        dir = Dir.L;
    }

    // Update is called once per frame
    void Update()
    {
        // ���]�f�o�b�O
        if(Controller.GetKeyTrigger(Controller.ControllerButton.Y))
        {
            dir++;
            if(dir > Dir.R)
            {
                dir = Dir.L;
            }
        }
        /*
          �n�ʂ�����������A��Q���ɐG���ƃL�����N�^�[�����]����B
          �A���A�v���C���[�ɐG�ꂽ�ꍇ�͔��]���Ȃ��B
          N�ɂ̎��́AS�ɂ̎��͂̂ǂ��炩��ттĂ���B
          N�ɂȂ�S�ɂ̏�Ԃ̃v���C���[�ɐG���Ƃ����B
          S�ɂȂ�N�ɂ̏�Ԃ̃v���C���[�ɐG���Ƃ����B
          �v���C���[����΂����I�u�W�F�N�g�ɐG���Ǝ��S����
          �ттĂ��鎥�͂��v���C���[�̂��̂Ɠ����ꍇ�A�݂��ɔ�������B
          ���̂Ƃ��A�v���C���[�����G���班�������Ԃ����B
         */

        switch(dir)
        {
            // ���������Ă���
            case Dir.L:
                vDir.z = -1.0f;
                //vDir.x = -1.0f;
                Rot = Quaternion.LookRotation(vDir);
                transform.rotation = Quaternion.Lerp(transform.rotation, Rot, Time.deltaTime * fSmooth);
                break;

            // �E�������Ă���
            case Dir.R:
                vDir.z = 1.0f;
                //vDir.x = 1.0f;
                Rot = Quaternion.LookRotation(vDir);
                transform.rotation = Quaternion.Lerp(transform.rotation, Rot, Time.deltaTime * fSmooth);
                break;

            default:
                break;
        }
        rb.velocity = new Vector3((rb.velocity.x + vDir.z) * fSpd, rb.velocity.y, rb.velocity.z);
        //rb.velocity = new Vector3((rb.velocity.x + vDir.x) * fSpd, rb.velocity.y, rb.velocity.z);
    }

    // ���]
    private void OnTriggerEnter(Collider other)
    {
        // �^�O�u���]�ǁv�ɐG�ꂽ
        if(other.gameObject.tag == "ReverseWall")
        {
            // �G���]
            dir++;
            if (dir > Dir.R)
            {
                dir = Dir.L;
            }
        }
    }
}
