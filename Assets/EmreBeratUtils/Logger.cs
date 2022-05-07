using UnityEngine;

namespace EmreBeratUtils
{
    public static class ExtensionWarningMessage
    {
        public static void RaiseNoChild()
        {
            Debug.LogWarning("The Transform has no children!");
        }
    }
    
    public static class ExtensionErrorMessage
    {
        public static void RaiseChildDoesNotExist(string name)
        {
            Debug.LogError($"Child with name ( {name} ) does not exist!");
        }

        public static void RaiseChildOutOfBounds()
        {
            Debug.LogError("Child out of Bounds, Sibling Index must be non-negative and less than the child count!");
        }
    }
}