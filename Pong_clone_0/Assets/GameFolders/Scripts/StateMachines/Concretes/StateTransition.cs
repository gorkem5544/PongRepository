using System;
using System.Collections;
using System.Collections.Generic;
using Assembly_CSharp.Assets.GameFolders.Scripts.StateMachines.Abstracts;
using UnityEngine;

namespace Assembly_CSharp.Assets.GameFolders.Scripts.StateMachines.Concretes
{
    public class StateTransition : IStateTransition
    {
        IState _from;
        IState _to;
        System.Func<bool> _condition;

        public IState From => _from;
        public IState To => _to;
        public Func<bool> Condition => _condition;

        public StateTransition(IState from, IState to, Func<bool> condition)
        {
            _from = from;
            _to = to;
            _condition = condition;
        }


    }

}