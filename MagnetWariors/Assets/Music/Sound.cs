using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]public class Sound
{
    [Tooltip("�T�E���h�̖��O")]
    public string name;
    // AudioSource�ɕK�v�ȏ��
    [Tooltip("�T�E���h�̉���")]
    public AudioClip clip;
    [Tooltip("�T�E���h�{�����[��,0.0����1.0�܂�")]
    public float volume;
    // AudioSource.Inspector�ɕ\�����Ȃ�
    [HideInInspector]
    public AudioSource audioSource;
}
