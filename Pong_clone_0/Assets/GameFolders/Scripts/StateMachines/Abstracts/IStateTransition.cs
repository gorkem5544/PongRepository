using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Assembly_CSharp.Assets.GameFolders.Scripts.StateMachines.Abstracts
{
    public interface IStateTransition
    {
        public IState From { get; }
        public IState To { get; }
        public System.Func<bool> Condition { get; }
    }

}