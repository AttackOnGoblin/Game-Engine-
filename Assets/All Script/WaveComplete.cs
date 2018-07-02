using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class WaveComplete : MonoBehaviour {
    public Text waveText;

    void OnEnable()
    {
        StartCoroutine(AnimateText());
    }

    IEnumerator AnimateText()
    {
        waveText.text = "0";
        int wave = 0;

        yield return new WaitForSeconds(0.6f);

        while(wave < PLayerStats.Wave)
        {
            wave++;
            waveText.text = wave.ToString();

            yield return new WaitForSeconds(.05f);


        }

    }

}
