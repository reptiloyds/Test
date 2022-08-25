using System;
using UnityEngine;

namespace Systems.SystemInterfaces
{
    public interface IInputSystem
    {
        public Vector3 MoveDelta { get; }
        public event Action<GameObject> OnSelectObject;
    }
}
