using UnityEngine;

namespace EmreBeratUtils.Extensions
{
    public static class TransformExtensions
    {
        
        #region Extension Methods for Parents
        
        public static void RenameChildren(this Transform transform, string commonName, bool withIndex = true)
        {
            if (transform.childCount == 0)
            {
                ExtensionWarningMessage.RaiseNoChild();
                return;
            }
            
            int counter = 0;
            foreach (Transform child in transform)
            {
                if (withIndex)
                {
                    child.name = $"[{counter++}] {commonName}";
                    continue;
                }

                child.name = commonName;
            }
        }

        public static Transform GetFirstChild(this Transform transform)
        {
            if (transform.childCount == 0)
            {
                ExtensionErrorMessage.RaiseChildOutOfBounds();
                return null;
            }
            
            return transform.GetChild(0);
        }
        
        public static Transform GetLastChild(this Transform transform)
        {
            if (transform.childCount == 0)
            {
                ExtensionErrorMessage.RaiseChildOutOfBounds();
                return null;
            }
            
            return transform.GetChild(transform.childCount - 1);
        }
        
        public static void AttachChild(this Transform transform, Transform newChild, bool worldPositionStays = true)
        {
            newChild.SetParent(transform, worldPositionStays);
        }
        
        public static void AttachChild(this Transform transform, Transform newChild, int siblingIndex, bool worldPositionStays = true)
        {
            transform.AttachChild(newChild, worldPositionStays);

            if (siblingIndex < 0 || siblingIndex >= transform.childCount)
            {
                ExtensionErrorMessage.RaiseChildOutOfBounds();
                return;
            }
            
            newChild.SetSiblingIndex(siblingIndex);
        }
        
        public static void AttachChildAsFirstSibling(this Transform transform, Transform newChild, bool worldPositionStays = true)
        {
            transform.AttachChild(newChild, worldPositionStays);
            newChild.SetAsFirstSibling();
        }

        public static void DetachChild(this Transform transform, int index)
        {
            if (transform.childCount == 0)
            {
                ExtensionWarningMessage.RaiseNoChild();
                return;
            }
            
            if (index < 0 || index >= transform.childCount)
            {
                ExtensionErrorMessage.RaiseChildOutOfBounds();
                return;
            }
            
            transform.GetChild(index).SetParent(null);
        }
        
        public static void DetachChild(this Transform transform, string name)
        {
            Transform child = transform.Find(name);

            if (child == null)
            {
                ExtensionErrorMessage.RaiseChildDoesNotExist(name);
                return;
            }
            
            child.SetParent(null);
        }

        public static void DetachFirstChild(this Transform transform)
        {
            transform.DetachChild(0);
        }
        
        public static void DetachLastChild(this Transform transform)
        {
            transform.DetachChild(transform.childCount - 1);
        }

        public static void DestroyChild(this Transform transform, int index)
        {
            if (transform.childCount == 0)
            {
                ExtensionWarningMessage.RaiseNoChild();
                return;
            }
            
            Object.Destroy(transform.GetChild(index).gameObject);
        }
        
        public static void DestroyChild(this Transform transform, string name)
        {
            Transform child = transform.Find(name);
            
            if (child == null)
            {
                ExtensionErrorMessage.RaiseChildDoesNotExist(name);
                return;
            }
            
            Object.Destroy(child.gameObject);
        }

        public static void DestroyFirstChild(this Transform transform)
        {
            transform.DestroyChild(0);
        }
        
        public static void DestroyLastChild(this Transform transform)
        {
            transform.DestroyChild(transform.childCount - 1);
        }
        
        public static void DestroyChildren(this Transform transform)
        {
            transform.DestroyChildren(0, transform.childCount - 1);
        }
        
        public static void DestroyChildren(this Transform transform, int firstIndex)
        {
            transform.DestroyChildren(firstIndex, transform.childCount - 1);
        }
        
        public static void DestroyChildren(this Transform transform, int firstIndex, int lastIndex)
        {
            if (transform.childCount == 0)
            {
                ExtensionWarningMessage.RaiseNoChild();
                return;
            }
            
            for (int i = lastIndex; i >= firstIndex; i--)
            {
                Object.Destroy(transform.GetChild(i).gameObject);
            }
        }
        
        public static Transform RandomChild(this Transform transform)
        {
            return transform.RandomChild(0, transform.childCount - 1);
        }
        
        public static Transform RandomChild(this Transform transform, int firstIndex)
        {
            return transform.RandomChild(firstIndex, transform.childCount - 1);
        }

        public static Transform RandomChild(this Transform transform, int firstIndex, int lastIndex)
        {
            if (transform.childCount == 0)
            {
                ExtensionWarningMessage.RaiseNoChild();
                return null;
            }
            
            return transform.GetChild(Random.Range(firstIndex, lastIndex + 1));
        }

        #endregion

        #region Extension Methods for Children

        public static void Rename(this Transform transform, string newName)
        {
            transform.name = newName;
        }

        public static void Detach(this Transform transform)
        {
            transform.SetParent(null);
        }

        #endregion
        
    }
}