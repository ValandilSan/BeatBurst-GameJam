using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerObserver : MonoBehaviour
{
    protected EPlayerState _StateOfTheplayer;

   protected enum EPlayerState
    {
        Idle,
        Run,
        Attack,
        Dash
    }

    public void WhatStateThePlayerIs()
    {
        switch (_StateOfTheplayer)
        {
            case EPlayerState.Idle:
                break;
            case EPlayerState.Run:
                break;
            case EPlayerState.Attack:
                break;
            case EPlayerState.Dash:
                break;
            default:
                break;
        }
    }

    #region Enter/Exit State
    private void EEnterState()
    {

        switch (_StateOfTheplayer)
        {
            case EPlayerState.Idle:
                break;
            case EPlayerState.Run:
                break;
            case EPlayerState.Attack:
                break;
            case EPlayerState.Dash:
                break;
            default:
                break;
        }
    }

    void SwitchState(EPlayerState newState)
    {
        EExitState();
        _StateOfTheplayer = newState;
        EEnterState();
    }

    private void EExitState()
    {
        switch (_StateOfTheplayer)
        {
            case EPlayerState.Idle:
                break;
            case EPlayerState.Run:
                break;
            case EPlayerState.Attack:
                break;
            case EPlayerState.Dash:
                break;
            default:
                break;
        }

    }
    #endregion

}
