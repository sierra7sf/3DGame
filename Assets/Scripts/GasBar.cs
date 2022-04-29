using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GasBar : MonoBehaviour
{
    public Image gasBar;

    public float Gas = 100;
    public float MaxGas = 100;

    // Update is called once per frame
    void Update()
    {
        float fill = Gas / MaxGas;
        Gas = Gas - Time.deltaTime * 5.0f;
        gasBar.fillAmount = fill;

        if (fill <= 0)
        {
            Debug.Log("YOU LOST");
        }
   
        
     
    }

}
