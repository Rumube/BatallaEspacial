using UnityEngine;

namespace Patterns.Observer.Solution1
{
    public class Installer : MonoBehaviour
    {
        [SerializeField] private SkillView _skillView;

        private void Awake()
        {
            var skill = new Skill();
            _skillView.Configure(skill);
        }
    }
}
