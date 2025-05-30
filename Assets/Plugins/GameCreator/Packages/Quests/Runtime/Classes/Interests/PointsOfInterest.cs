using System.Collections.Generic;
using GameCreator.Runtime.Quests;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace GameCreator.Runtime.Common
{
    public static class PointsOfInterest
    {
        // PROPERTIES: ----------------------------------------------------------------------------
        
        private static Dictionary<int, TSpotPoi> Values { get; set; }

        public static List<TSpotPoi> List => new List<TSpotPoi>(Values.Values);

        // PUBLIC METHODS: ------------------------------------------------------------------------

        public static bool Insert(int key, TSpotPoi value)
        {
            return Values.TryAdd(key, value);
        }

        public static bool Remove(int key)
        {
            return Values.Remove(key);
        }

        // INIT METHODS: --------------------------------------------------------------------------

        [RuntimeInitializeOnLoadMethod(RuntimeInitializeLoadType.SubsystemRegistration)]
        private static void OnSubsystemsInit()
        {
            Values = new Dictionary<int, TSpotPoi>();
            
            SceneManager.sceneLoaded -= OnSceneLoad;
            SceneManager.sceneLoaded += OnSceneLoad;
        }

        private static void OnSceneLoad(Scene scene, UnityEngine.SceneManagement.LoadSceneMode mode)
        {
            if (mode == UnityEngine.SceneManagement.LoadSceneMode.Single)
            {
                Values.Clear();
            }
        }
    }
}