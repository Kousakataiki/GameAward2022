using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MagnetType : MonoBehaviour
{
    public enum POLE
    {
        N,
        S,
        MAX
    }

    [SerializeField] public POLE pole;

    public POLE GetMagnetType()
    {
        return pole;
    }
}
