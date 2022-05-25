using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VariableManager : MonoBehaviour
{
    [SerializeField] private float playerMoveSpeed;
    [SerializeField] private float playerJumpPower;
    [SerializeField] private float playerMagnetStrength;
    [SerializeField] private float playerMagnetRange;
    [SerializeField] private float MaxMagnetAmount;
    [SerializeField] private float SpendMagnetAmount;
    [SerializeField] private float HealMagnetAmount;
    [SerializeField] private float RimitHeight;
    [SerializeField] private float MagnetWallAttractStrength;
    [SerializeField] private float MagnetWallFlickStrength;

    static public float playerMoveSpeed_s;
    static public float playerJumpPower_s;
    static public float playerMagnetStrength_s;
    static public float playerMagnetRange_s;
    static public float MaxMagnetAmount_s;
    static public float SpendMagnetAmount_s;
    static public float HealMagnetAmount_s;
    static public float RimitHeight_s;
    static public float MagnetWallAttractStrength_s;
    static public float MagnetWallFlickStrength_s;
    
    private void Awake()
    {
        playerMoveSpeed_s = playerMoveSpeed;
        playerJumpPower_s = playerJumpPower;
        playerMagnetStrength_s = playerMagnetStrength;
        playerMagnetRange_s = playerMagnetRange;
        MaxMagnetAmount_s = MaxMagnetAmount;
        SpendMagnetAmount_s = SpendMagnetAmount;
        HealMagnetAmount_s = HealMagnetAmount;
        RimitHeight_s = RimitHeight;
        MagnetWallAttractStrength_s = MagnetWallAttractStrength;
        MagnetWallFlickStrength_s = MagnetWallFlickStrength;

        Application.targetFrameRate = 60;

        DontDestroyOnLoad(gameObject);
    }
}
