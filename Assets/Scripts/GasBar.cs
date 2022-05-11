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
        Gas = Gas - Time.deltaTime * 6.0f;
        gasBar.fillAmount = fill;

        if (fill <= 0)
        {
            fill = 0;
            FindObjectOfType<Game_Manager>().endGame();
        }
   
    }


    public void increaseGas()
    {
        if(Gas <= 70)
        {
            Gas += 30;
        }
        else
        {
            Gas = MaxGas;
        }
        
    }

    
    public void LightDecreaseGas()
    {
        Gas -= 10;
    }

}
