using System;
using Systems.SystemInterfaces;
using UnityEngine;
using Zenject;

namespace Systems
{
    public class InputSystem : IInputSystem
    {
        private Vector3 _moveDelta;

        public Vector3 MoveDelta => _moveDelta;
        public event Action<GameObject> OnSelectObject;
        
    }
}
