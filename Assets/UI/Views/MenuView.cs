using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MenuView : BaseView
{
    [SerializeField] StateMachine stateMachine;

    public override void ShowView()
    {
        base.ShowView();
    }

    public override void HideView()
    {
        base.HideView();
    }

        public void OnGameStartButtonPressed()
    {
        stateMachine.EnterState(new GameState());
        HideView();
    }
}
