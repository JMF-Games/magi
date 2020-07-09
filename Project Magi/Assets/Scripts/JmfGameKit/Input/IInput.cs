using UnityEngine;

namespace JmfGameKit.Input
{
    public interface IInput
    {
        bool GetKeyDown(KeyCode button);
        bool GetKeyUp(KeyCode button);
    }
}
