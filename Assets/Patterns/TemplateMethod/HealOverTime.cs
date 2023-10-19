using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Patterns.TemplateMethod
{
    [CreateAssetMenu(menuName = "TemplateMethod/Create HealOverTimeSkill", fileName = "HealOverTimeSkill", order = 0)]

    public class HealOverTime : ActiveSkill
    {
        [SerializeField] private float _secondsActive;
        [SerializeField] private int _healthToAdd;

        private float _currentTimeInSeconds;
        private bool _isActivate;
        private Hero _hero;

        private int _charges;
        protected override void DoActivate(Hero hero)
        {
            _isActivate = true;
            _currentTimeInSeconds = 0;
            _hero = hero;
        }

        protected override bool DoIsReady()
        {
            return _charges > 0;
        }

        protected override void DoUpdate()
        {
            if (!_isActivate)
            {
                return;
            }
            _hero.AddHealth(_healthToAdd * Time.deltaTime);
            _currentTimeInSeconds += Time.deltaTime;
            if (_currentTimeInSeconds > _secondsActive)
            {
                _isActivate = false;
                return;
            }
        }
    }
}

