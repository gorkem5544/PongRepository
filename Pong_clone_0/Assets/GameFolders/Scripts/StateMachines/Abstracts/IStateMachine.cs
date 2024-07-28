using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Assembly_CSharp.Assets.GameFolders.Scripts.StateMachines.Abstracts
{
    public interface IStateMachine
    {
        void Update();
        void FixedUpdate();
        void SetState(IState state);
        void AddTransition(IState from, IState to, System.Func<bool> condition);
        void AddAnyState(IState to, System.Func<bool> condition);
    }

}