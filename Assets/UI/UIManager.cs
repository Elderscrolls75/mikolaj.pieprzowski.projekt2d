using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIManager : MonoBehaviour
{
    [SerializeField] BaseView loseView;
    [SerializeField] BaseView hudView;
    [SerializeField] BaseView menuView;

    public static UIManager Instance;

    private void Awake() 
    {
        if(Instance==null)
        {
            Instance = this;
        }    
        else
        {
            Destroy(gameObject);
        }
    }

    public void ShowMenu()
    {
        menuView.ShowView();
        hudView.HideView();
        loseView.HideView();
    }

    public void ShowHUD()
    {
        hudView.ShowView();
        loseView.HideView();
        menuView.HideView();
    }

    public void ShowLose()
    {
        loseView.ShowView();
        menuView.HideView();
        hudView.HideView();
    }

    
}
