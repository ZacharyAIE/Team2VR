using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace CharacterComparison
{
    [CreateAssetMenu(menuName = "Visa/Visa Purpose Combo List")]
    public class ValidPurposeCombo : ScriptableObject
    {
        public List<Purpose> purposes;
    }
}