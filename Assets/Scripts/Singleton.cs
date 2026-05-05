using UnityEngine;

public class Singleton<T> : MonoBehaviour where T : Singleton<T>
{    
        private static T Instance;

        public static T Get()
        {
            return Instance;
        }

        protected virtual void Awake()
        {
            if (Instance == null)
            {
                // This component becomes the singleton instance
                Instance = (T)this;
                DontDestroyOnLoad(gameObject);
            }
            else
            {
                // This is a duplicate! Destroy it
                Destroy(gameObject);
            }
        }    
}
