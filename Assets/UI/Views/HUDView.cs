using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using System;

public class HUDView : BaseView
{


    [SerializeField] TMP_Text lifeCounter;

    public override void ShowView()
    {
        base.ShowView();

        PlayerController.Instance.HealthSystem.OnHealthChanged += HealthSystem_OnHealthChanged;

        UpdateText(PlayerController.Instance.HealthSystem.Health);

    }

    private void HealthSystem_OnHealthChanged(int obj)
    {
        UpdateText(obj);
    }

     void UpdateText(int hpCounter)
    {
        lifeCounter.text = "Life: " + hpCounter;
    }

    public override void HideView()
    {
        base.HideView();
    }
}
