using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;


public class ClickerMiniGame : MonoBehaviour
{
    public TextMeshProUGUI ClicksTotalText;

    float TotalClicks;

    bool hasUpgrade;
    bool hasMissUpgrade;
    public int autoClicksPerSecond;
    public int autoClicksPerSecondMiss;
    public int minimumClicksToUnlockUpgrade;
    public int ClicksToUnlockUpgradeMiss;
    public int MegaClicksToUnlockUpgrade;
    bool hasMegaUpgrade;
    public int MegaAutoClicksPerSecond;

    public int BabyClicksToUnlockUpgrade;
    bool hasBabyUpgrade;
    public int BabyAutoClicksPerSecond;

    public int ShrekClicksToUnlockUpgrade;
    bool hasShrekUpgrade;
    public int ShrekAutoClicksPerSecond;

    public int GodClicksToUnlockUpgrade;
    bool hasGodUpgrade;
    public int GodAutoClicksPerSecond;

    public GameObject Peter;
    public GameObject PeterUI;
    public GameObject Sephiroth;
    public GameObject SephirothUI;
    public GameObject May;
    public GameObject MayUI;
    public GameObject Imposter;
    public GameObject ImposterUI;
    public GameObject Jones;
    public GameObject JonesUI;
    public GameObject Sans;
    public GameObject SansUI;

    public int SansClicksToUnlockUpgrade;
    bool hasSansUpgrade;
    public int SansAutoClicksPerSecond;
    public void AddClicks()
    {
        TotalClicks++;
        ClicksTotalText.text = TotalClicks.ToString("0");
    }

    public void AutoClickUpgrade()
    {
        if (!hasUpgrade && TotalClicks >= minimumClicksToUnlockUpgrade)
        {
            TotalClicks -= minimumClicksToUnlockUpgrade;
            hasUpgrade = true;
        }
    }

    private void Update()
    {
        if (hasUpgrade)
        {
            TotalClicks += autoClicksPerSecond * Time.deltaTime;

            ClicksTotalText.text = TotalClicks.ToString("0");
        }

        if (hasMissUpgrade)
        {
            TotalClicks += autoClicksPerSecondMiss * Time.deltaTime;

            ClicksTotalText.text = TotalClicks.ToString("0");
            PeterUI.SetActive(false);
            Peter.SetActive(true);
        }

        if (hasMegaUpgrade)
        {
            TotalClicks += MegaAutoClicksPerSecond * Time.deltaTime;

            ClicksTotalText.text = TotalClicks.ToString("0");
            SephirothUI.SetActive(false);
            Sephiroth.SetActive(true);
        }

        if (hasBabyUpgrade)
        {
            TotalClicks += BabyAutoClicksPerSecond * Time.deltaTime;

            ClicksTotalText.text = TotalClicks.ToString("0");
            MayUI.SetActive(false);
            May.SetActive(true);
        }
        if (hasShrekUpgrade)
        {
            TotalClicks += ShrekAutoClicksPerSecond * Time.deltaTime;

            ClicksTotalText.text = TotalClicks.ToString("0");
            ImposterUI.SetActive(false);
            Imposter.SetActive(true);
        }
        if (hasGodUpgrade)
        {
            TotalClicks += GodAutoClicksPerSecond * Time.deltaTime;

            ClicksTotalText.text = TotalClicks.ToString("0");
            JonesUI.SetActive(false);
            Jones.SetActive(true);
        }
        if (hasSansUpgrade)
        {
            TotalClicks += GodAutoClicksPerSecond * Time.deltaTime;

            ClicksTotalText.text = TotalClicks.ToString("0");
            SansUI.SetActive(false);
            Sans.SetActive(true);
        }
    }

    public void MsPacManUpgrade()
    {
        if (!hasUpgrade && TotalClicks >= ClicksToUnlockUpgradeMiss)
        {
            TotalClicks -= ClicksToUnlockUpgradeMiss;
            hasMissUpgrade = true;
            Peter.SetActive(true);
        }
    }

    public void MegaUpgrade()
    {
        if (!hasUpgrade && TotalClicks >= MegaClicksToUnlockUpgrade)
        {
            TotalClicks -= MegaClicksToUnlockUpgrade;
            hasMegaUpgrade = true;
        }
    }

    public void BabyUpgrade()
    {
        if (!hasUpgrade && TotalClicks >= BabyClicksToUnlockUpgrade)
        {
            TotalClicks -= BabyClicksToUnlockUpgrade;
            hasBabyUpgrade = true;
        }
    }

    public void ShrekUpgrade()
    {
        if (!hasUpgrade && TotalClicks >= ShrekClicksToUnlockUpgrade)
        {
            TotalClicks -= ShrekClicksToUnlockUpgrade;
            hasShrekUpgrade = true;
        }
    }

    public void GodUpgrade()
    {
        if (!hasUpgrade && TotalClicks >= GodClicksToUnlockUpgrade)
        {
            TotalClicks -= GodClicksToUnlockUpgrade;
            hasGodUpgrade = true;
        }
    }

    public void SansUpgrade()
    {
        if (!hasUpgrade && TotalClicks >= SansClicksToUnlockUpgrade)
        {
            TotalClicks -= SansClicksToUnlockUpgrade;
            hasSansUpgrade = true;
        }
    }
}

