using System;
using System.Collections.Generic;

namespace Patterns.Observer.Solution2
{
    public class Skill : ISkill
    {
        public event Action<bool> OnIsReadyUpdated;
        public event Action<int> OnChargesUpdated;

        private int _charges;
        private bool IsReady => _charges > 0;

        public Skill()
        {
            _charges = 3;
        }

        public void Use()
        {
            if(!IsReady)
            {
                return;
            }

            _charges -= 1;
            OnChargesUpdated?.Invoke(_charges);

            if(!IsReady)
            {
                OnIsReadyUpdated?.Invoke(IsReady);
            }
        }
    }
}