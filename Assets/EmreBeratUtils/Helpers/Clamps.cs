using System;
using UnityEngine;

namespace EmreBeratUtils.Helpers
{
    [Serializable]
    public struct Clamp
    {
        [field:SerializeField] public float min { get; private set; }
        [field:SerializeField] public float max { get; private set; }
    }
    
    [Serializable]
    public struct ClampInt
    {
        [field:SerializeField] public int min { get; private set; }
        [field:SerializeField] public int max { get; private set; }
    }
}