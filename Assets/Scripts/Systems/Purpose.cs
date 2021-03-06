using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace CharacterComparison 
{
    /// <summary>
    /// This object determines a correct visa type to restriction combo
    /// This is used in <see cref="ValidPurposeCombo"/> to keep a list of purpose to <see cref="Restriction"/> combinations
    /// </summary>
    [System.Serializable]
    public struct Purpose
    {
        public VisaType visaType;
        public Restriction restriction;

        // Compare the params to the given enums
        public bool Compare(VisaType vt, Restriction r)
        {
            if(vt == visaType && r == restriction)
                return true;
            else
                return false;
        }
    }
}