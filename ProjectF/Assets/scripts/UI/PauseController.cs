using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PauseController : MonoBehaviour
{
    public static bool JogoPausado { get ; private set ; } = false;
    public static void SetPause(bool pause)
    {
        JogoPausado = pause;
    }
}
