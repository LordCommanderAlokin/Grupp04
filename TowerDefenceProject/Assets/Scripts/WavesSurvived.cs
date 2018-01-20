using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class WavesSurvived : MonoBehaviour
{
    public Text wavesText;

    void OnEnable()
    {
        StartCoroutine(RoundText());
    }

    IEnumerator RoundText()
    {
        wavesText.text = "0";
        int waves = 0;

        yield return new WaitForSeconds(.7f);

        while (waves < PlayerStats.Rounds)
        {
            waves++;
            wavesText.text = waves.ToString();

            yield return new WaitForSeconds(.05f);
        }
    }
}
