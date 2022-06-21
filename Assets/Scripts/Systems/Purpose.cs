using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace CharacterComparison 
{ 
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