using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GasBar : MonoBehaviour
{
    public Image gasBar;

    public int Gas;
    public int MaxGas;


    // Update is called once per frame
    void Update()
    {
        Gas -= 1;
        gasBar.fillAmount = Mathf.Clamp(Gas / MaxGas, 0, 1f);
    }
}
