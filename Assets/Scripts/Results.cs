using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class Results : MonoBehaviour
{
    public TextMeshProUGUI InnocentpercentageText;
    public TextMeshProUGUI GuiltypercentageText;
    public TextMeshProUGUI MoraleRankText;



    // Start is called before the first frame update
    void Start()
    {
        float stat1Value = PlayerPrefs.GetInt("Innocent");
        float stat2Value = PlayerPrefs.GetInt("Guilty");
        Debug.Log(stat1Value + stat2Value);
        float percentage = (stat1Value / 5) * 100f;
        float percentage2 = (stat2Value / 5) * 100f;

        InnocentpercentageText.text = "You said " + percentage.ToString() + "%" + " of cases were innocent";
        GuiltypercentageText.text = "You said " + percentage2.ToString() + "%" + " of cases were guilty";


        //MoraleRankText.text = "You are"+percentage.ToString() + "%" + "Forgiving";
        if (percentage > percentage2)
        {
            MoraleRankText.text = "You are morally forgiving.";
        }
        else 
        {
            MoraleRankText.text = "You are morally relentless.";
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
