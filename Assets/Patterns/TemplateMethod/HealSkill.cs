using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Patterns.TemplateMethod
{
    [CreateAssetMenu(menuName = "TemplateMethod/Create HealSkill", fileName = "HealSkill", order = 0)]
    public class HealSkill : ActiveSkill
    {
        [SerializeField] private int healthToAdd;
        protected override void DoActivate(Hero hero)
        {
            hero.AddHealth(healthToAdd);
        }

        protected override bool DoIsReady()
        {
            return true;
        }

        protected override void DoUpdate()
        {
            
        }
    }
}

