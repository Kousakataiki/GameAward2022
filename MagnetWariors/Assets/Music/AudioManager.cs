using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioManager : MonoBehaviour
{
    // Soundクラス配列
    [SerializeField]
    private Sound[] sounds;
    // シングルトン化
    public static AudioManager instance;
    [SerializeField] private float FadeTime;
    private WaitForSeconds BGMFadeTime;

    private void Awake()
    {
        // AudioManagerインスタンスが存在しなければ生成
        // 存在すればDestroy,return
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

        // Soundクラスに入れたデータをAudioSourceに当てはめる
        foreach (Sound s in sounds)
        {
            s.audioSource = gameObject.AddComponent<AudioSource>();
            s.audioSource.clip = s.clip;
            s.audioSource.volume = s.volume;
        }
    }

    public void Play(string name)
    {

        // ラムダ式　第二引数はPredicate
        // Soundクラスの配列の中の名前に，
        // 引数nameに等しいものがあるかどうか確認
        Sound s = System.Array.Find(sounds, sound => sound.name == name);
        // なければreturn
        if (s == null)
        {
            print("Sound" + name + "was not found");
            return;
        }
        // あればPlay()
        s.audioSource.Play();
    }

    public void BGMStart(string name)
    {
        // ラムダ式　第二引数はPredicate
        // Soundクラスの配列の中の名前に，
        // 引数nameに等しいものがあるかどうか確認
        Sound s = System.Array.Find(sounds, sound => sound.name == name);
        // なければreturn
        if (s == null)
        {
            print("Sound" + name + "was not found");
            return;
        }
        // あればPlay()
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
        // ラムダ式　第二引数はPredicate
        // Soundクラスの配列の中の名前に，
        // 引数nameに等しいものがあるかどうか確認
        Sound s = System.Array.Find(sounds, sound => sound.name == name);
        // なければreturn
        if (s == null)
        {
            print("Sound" + name + "was not found");
            return;
        }
        // あればPlay()
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
