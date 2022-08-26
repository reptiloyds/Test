using System;
using System.Collections.Generic;
using System.Linq;
using DevelopmentTools;
using Sirenix.OdinInspector;
using UnityEngine;
using UnityEngine.UI;
// ReSharper disable InconsistentNaming

namespace UI
{
    public class SkillTree : MonoBehaviour
    {
        [SerializeField] private SkillInfoPanel _skillInfoPanel;
        [SerializeField] private RectTransform _lineContainer;
        [SerializeField] private float _lineThickness;
        [SerializeField] private Color _lineColor;
        [SerializeField] private List<SkillBranch> _skillBranches;
        [SerializeField] private BaseSkillUI _selectSkillDefault;

        private List<BaseSkillUI> _skills = new List<BaseSkillUI>();
        private BaseSkillUI _currentSkill;

        [Button]
        private void CreateLines()
        {
            var children = _lineContainer.gameObject.GetChildren();
            foreach (var child in children)
            {
                DestroyImmediate(child);
            }
            
            foreach (var skillBranch in _skillBranches)
            {
                foreach (var nextSkill in skillBranch.NextSkills)
                {
                    var lineObject = new GameObject("UILine");
                    lineObject.AddComponent<Image>();
                    var line = lineObject.AddComponent<UILine>();
                    line.SetParent(_lineContainer.transform);
                    line.CreateLineBetween(skillBranch.Root.gameObject, nextSkill.gameObject, _lineThickness, _lineColor);   
                }
            }
        }
        
        private void Start()
        {
            _skills = GetComponentsInChildren<BaseSkillUI>().ToList();
            foreach (var skill in _skills)
            {
                skill.OnSkillClick += OnSkillClick;
            }
        }

        public void SelectSkillOnStart()
        {
            OnSkillClick(_selectSkillDefault);
        }

        private void OnSkillClick(BaseSkillUI skill)
        {
            if(skill == _currentSkill) return;
            if (_currentSkill != null)
            {
                _currentSkill.Deselect();
            }

            _currentSkill = skill;
            _currentSkill.Select();
            _skillInfoPanel.Show(_currentSkill);
        }

        public bool CanExploreSelectedSkill()
        {
            return _currentSkill.State != SkillState.Explored && IsConnected(_currentSkill);
        }

        public bool CanForgetSelectedSkill()
        {
            return _currentSkill.State == SkillState.Explored && CanForget(_currentSkill);
        }

        private bool IsConnected(BaseSkillUI skillUI, BaseSkillUI exception = null)
        {
            var searchFrom = new List<BaseSkillUI> { skillUI };
            var currentRoots = new List<BaseSkillUI>();
            do
            {
                currentRoots.Clear();
                foreach (var search in searchFrom)
                {
                    currentRoots.AddRange(_skillBranches.Where(item => item.Root != exception && item.NextSkills.Contains(search) && item.Root.State == SkillState.Explored)
                        .Select(item => item.Root)
                        .ToList());
                }

                if (currentRoots.Any(item => item.Config.ExploredOnStart)) return true;
                searchFrom = new List<BaseSkillUI>(currentRoots);
            }
            while (currentRoots.Count > 0);

            return false;
        }

        private bool CanForget(BaseSkillUI skillUI)
        {
            if (skillUI.Config.ExploredOnStart) return false;
            var skillBranch = _skillBranches.FirstOrDefault(item => item.Root == skillUI);
            if (skillBranch == null) return true;

            var nextItems = skillBranch.NextSkills.Where(item => item.State == SkillState.Explored);
            foreach (var nextItem in nextItems)
            {
                if (!IsConnected(nextItem, skillUI)) return false;
            }

            return true;
        }

        public void ForgetAllSkills()
        {
            foreach (var skill in _skills)
            {
                if(skill.Config.ExploredOnStart || skill.State == SkillState.Unexplored) continue;
                skill.Forget();
            }
        }
    }

    [Serializable]
    public class SkillBranch
    {
        [SerializeField] private BaseSkillUI _root;
        [SerializeField] private List<BaseSkillUI> _nextSkills;

        public BaseSkillUI Root => _root;
        public List<BaseSkillUI> NextSkills => _nextSkills;
    }
}
