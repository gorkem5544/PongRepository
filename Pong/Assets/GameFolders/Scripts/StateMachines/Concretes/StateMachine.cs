using System;
using System.Collections;
using System.Collections.Generic;
using Assembly_CSharp.Assets.GameFolders.Scripts.StateMachines.Abstracts;
using UnityEngine;

namespace Assembly_CSharp.Assets.GameFolders.Scripts.StateMachines.Concretes
{
    public class StateMachine : IStateMachine
    {
        List<StateTransition> _stateTransitions = new List<StateTransition>();
        List<StateTransition> _anyStateTransitions = new List<StateTransition>();

        IState _currentState;
        /// <summary>
        /// Oyunu ilk Stateini bu method sayesinde başlatıyoruz 
        /// </summary>

        public void SetState(IState state)
        {
            if (_currentState == state)
            {
                return;
            }

            _currentState?.Exit();
            _currentState = state;
            _currentState.Enter();
        }

        public void Update()
        {

            StateTransition stateTransition = CheckForTransition();
            if (stateTransition != null)
            {
                SetState(stateTransition.To);
            }
            _currentState.Update();
        }
        public void FixedUpdate()
        {
            StateTransition stateTransition = CheckForTransition();
            if (stateTransition != null)
            {
                SetState(stateTransition.To);
            }
            _currentState.FixedUpdate();
        }
        private StateTransition CheckForTransition()
        {
            foreach (StateTransition anyStateTransition in _anyStateTransitions)
            {
                if (anyStateTransition.Condition.Invoke())
                {
                    return anyStateTransition;
                }
            }
            foreach (StateTransition stateTransition in _stateTransitions)
            {
                if (stateTransition.Condition() && stateTransition.From == _currentState)
                {
                    return stateTransition;
                }
            }
            return null;
        }

        public void AddTransition(IState from, IState to, System.Func<bool> condition)
        {
            StateTransition stateTransition = new StateTransition(from, to, condition);
            _stateTransitions.Add(stateTransition);
        }
        public void AddAnyState(IState to, System.Func<bool> condition)
        {
            StateTransition stateTransition = new StateTransition(null, to, condition);
            _anyStateTransitions.Add(stateTransition);
        }
    }

}