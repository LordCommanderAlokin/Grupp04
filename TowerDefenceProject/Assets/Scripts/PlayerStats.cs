using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerStats : MonoBehaviour
{

    public static int Faith;
    public int startFaith = 400;

    public static int Lives;
    public int startLives = 20;

    public static int Rounds = 0;

    void Start()
    {
        Lives = startLives;
        Faith = startFaith;

        Rounds = 0;
    }
}
