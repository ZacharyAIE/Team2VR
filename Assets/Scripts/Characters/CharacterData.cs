using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace CharacterComparison
{
    [CreateAssetMenu(menuName = "Character/Create Data")]
    public class CharacterData : ScriptableObject
    {
        public List<string> shipNames;
        public List<GameObject> shipModels;
        public List<Sprite> characterSprites;

        public List<AudioClip> voiceLines;
    }
}