using UnityEngine;

namespace EmreBeratUtils.Extensions
{
    public static class GameObjectExtensions
    {
        public static void PrintName(this Object obj)
        {
            if (obj == null)
            {
                Debug.Log("null");
                return;
            }
            
            Debug.Log(obj.name);
        }
        
        public static void Activate(this GameObject gameObject)
        {
            gameObject.SetActive(true);
        }
        
        public static void Deactivate(this GameObject gameObject)
        {
            gameObject.SetActive(false);
        }
    }
}