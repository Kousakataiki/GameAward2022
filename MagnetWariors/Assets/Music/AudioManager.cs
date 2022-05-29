using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioManager : MonoBehaviour
{
    // Sound�N���X�z��
    [SerializeField]
    private Sound[] sounds;
    // �V���O���g����
    public static AudioManager instance;
    [SerializeField] private float FadeTime;
    private WaitForSeconds BGMFadeTime;

    private void Awake()
    {
        // AudioManager�C���X�^���X�����݂��Ȃ���ΐ���
        // ���݂����Destroy,return
        if (instance == null)
        {
            instance = this;
        }
        else
        {
            Destroy(gameObject);
            return;
        }

        BGMFadeTime = new WaitForSeconds(FadeTime);
        DontDestroyOnLoad(gameObject);

        // Sound�N���X�ɓ��ꂽ�f�[�^��AudioSource�ɓ��Ă͂߂�
        foreach (Sound s in sounds)
        {
            s.audioSource = gameObject.AddComponent<AudioSource>();
            s.audioSource.clip = s.clip;
            s.audioSource.volume = s.volume;
        }
    }

    public void Play(string name)
    {

        // �����_���@��������Predicate
        // Sound�N���X�̔z��̒��̖��O�ɁC
        // ����name�ɓ��������̂����邩�ǂ����m�F
        Sound s = System.Array.Find(sounds, sound => sound.name == name);
        // �Ȃ����return
        if (s == null)
        {
            print("Sound" + name + "was not found");
            return;
        }
        // �����Play()
        s.audioSource.Play();
    }

    public void BGMStart(string name)
    {
        // �����_���@��������Predicate
        // Sound�N���X�̔z��̒��̖��O�ɁC
        // ����name�ɓ��������̂����邩�ǂ����m�F
        Sound s = System.Array.Find(sounds, sound => sound.name == name);
        // �Ȃ����return
        if (s == null)
        {
            print("Sound" + name + "was not found");
            return;
        }
        // �����Play()
        s.audioSource.loop = true;
        s.audioSource.volume = s.volume;
        s.audioSource.Play();
    }

    public void BGMFadeStarter(string bgmName)
    {
        Sound s = System.Array.Find(sounds, sound => sound.name == bgmName);
        StartCoroutine(BGMFadeStop(s));
    }

    IEnumerator BGMFadeStart(Sound s)
    {
        s.audioSource.Play();
        s.audioSource.loop = true;
        while (true)
        {
            s.audioSource.volume += 0.01f;
            yield return BGMFadeTime;
            if (s.audioSource.volume >= s.volume)
            {
                s.audioSource.volume = s.volume;
                break;
            }
        }
    }

    public void BGMFadeStoper(string bgmName)
    {
        Sound s = System.Array.Find(sounds, sound => sound.name == bgmName);
        StartCoroutine(BGMFadeStop(s));
    }

    public void BGMStop(string name)
    {
        // �����_���@��������Predicate
        // Sound�N���X�̔z��̒��̖��O�ɁC
        // ����name�ɓ��������̂����邩�ǂ����m�F
        Sound s = System.Array.Find(sounds, sound => sound.name == name);
        // �Ȃ����return
        if (s == null)
        {
            print("Sound" + name + "was not found");
            return;
        }
        // �����Play()
        // s.audioSource.loop = true;
        s.audioSource.volume = 0;
        s.audioSource.Stop();
    }

    IEnumerator BGMFadeStop(Sound s)
    {
        while (true)
        {
            s.audioSource.volume -= 0.01f;
            yield return new WaitForSeconds(0.1f);
            if (s.audioSource.volume <= 0)
            {
                s.audioSource.volume = 0;
                break;
            }
        }
        s.audioSource.Stop();
    }
}
