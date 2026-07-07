using Helpers;
using UnityEngine;

namespace Gameplay
{
    public class GameplayController : MonoBehaviour
    {
        private void Awake()
        {
            ServiceSingleton.Add(this);
        }

        private void Start()
        {
        }
    }
}