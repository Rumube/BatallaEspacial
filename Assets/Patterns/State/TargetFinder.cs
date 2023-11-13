using System;
using System.Collections.Generic;
using UnityEngine;

namespace Patterns.State
{
    public class TargetFinder
    {
        public IEnumerable<Enemy> FindTargets()
        {
            return GameObject.FindObjectsOfType<Enemy>();
        }
    }
}