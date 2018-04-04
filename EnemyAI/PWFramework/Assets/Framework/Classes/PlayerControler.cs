using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : Controller
{
    public static bool LogMissingInputDelegates = true;
    public static bool LogInputStateInfo = true;
    public static bool LogHUDUpdateError = false;

    protected delegate void InputAxis(float value);
    protected delegate void InputButton(bool value);

    protected Dictionary<string, InputAxis> AxisDelegates;
    protected Dictionary<string, InputButton> ButtonDelegates;

    protected InputPoller IP; 
    protected InputState IS;
    protected InputState ISprevious;
    public FrameworkHUD HUD; 

    protected override void Start()
    {
        base.Start();
        IsHuman = true; 

        IP = InputPoller.Self; 
        if (!IP)
        {
            LOG_ERROR("****PLAYER CONTROLER: No Input Poller in Scene");
            return; 
        }
        AxisDelegates = new Dictionary<string, InputAxis>();
        ButtonDelegates = new Dictionary<string, InputButton>();
        IS = InputState.GetBlankState();
        ISprevious = InputState.GetBlankState();
        DefaultBinds();
    }

    protected void FixedUpdate()
    {
        
        GetInput();
        
        // Do not pass Pawn info to HUD if one or the other is missing. 
        if (!HUD && !PossesedPawn)
        {
            if (LogHUDUpdateError)
            {
                LOG_ERROR("Missing Pawn or Hud for HUD Update");
            }

            return; 
        }
        UpdateHUD(); 
    }

    /// <summary>
    /// Override this Method to pass information from your Pawn to your HUD
    /// </summary>
    protected virtual void UpdateHUD()
    {

    }

    protected virtual void GetInput()
    {
        if (!IP)
        {
            LOG_ERROR("****PLAYER CONTROLER (" + gameObject.name + "): No Input Poller in Scene");
            return;
        }
        
        IS = InputPoller.Self.GetPlayerInput(InputPlayerNumber);
        if (LogInputStateInfo)
        {
            LOG(IS.ToString());
        }
        ProcessInputState();
        ISprevious = IS;
    }



    protected virtual void ProcessInputState()
    {
        // Process Buttons
        foreach (KeyValuePair<string, bool> item in IS.Buttons)
        {
            if (!ButtonDelegates.ContainsKey(item.Key) && LogMissingInputDelegates)
            {
                LOG_ERROR("****PLAYER CONTROLER (" + gameObject.name + "): " + item.Key + " has no defined Input Delegate");
                break; 
            }
            ButtonDelegates[item.Key].Invoke(item.Value);
        }
        
        // Process Axis
        foreach (KeyValuePair<string, float> item in IS.Axes)
        {
            if (!AxisDelegates.ContainsKey(item.Key) && LogMissingInputDelegates)
            {
                LOG_ERROR("****PLAYER CONTROLER (" + gameObject.name + "): " + item.Key + " has no defined Input Delegate");
                break;
            }
            AxisDelegates[item.Key].Invoke(item.Value);
        }
    }

    protected virtual void AddButton(string command, InputButton delegateMethod)
    {
        ButtonDelegates.Add(command, delegateMethod);
    }
    protected virtual void AddAxis(string command, InputAxis delegateMethod)
    {
        AxisDelegates.Add(command, delegateMethod);
    }

    public virtual void DefaultBinds()
    {
        AddAxis("Horizontal", Horizontal);
        AddAxis("Vertical", Vertical);
        AddButton("Fire1", Fire1);
        AddButton("Fire2", Fire2);
        AddButton("Fire3", Fire3);
        AddButton("Fire4", Fire4);
    }

    public virtual void Horizontal(float value)
    {
        if (value != 0)
        {
            LOG("Del-Horizontal (" + value + ")");
        }
    }

    public virtual void Vertical(float value)
    {
        if (value != 0)
        {
            LOG("Del-Vertical (" + value +")");
        }       
    }

    public virtual void Fire1(bool value)
    {
        if (value)
        {
            LOG("Del-Fire1");
        }
    }

    public virtual void Fire2(bool value)
    {
        if (value)
        {
            LOG("Del-Fire2");
        }
    }

    public virtual void Fire3(bool value)
    {
        if (value)
        {
            LOG("Del-Fire3");
        }
    }

    public virtual void Fire4(bool value)
    {
        if (value)
        {
            LOG("Del-Fire4");
        }
    }
}
