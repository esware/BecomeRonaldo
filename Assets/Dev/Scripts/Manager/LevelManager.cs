using System;
using ScriptableObjects.Scripts;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace Managers
{
    public struct GameEvents
    {
        public static Action WinEvent;
        public static Action LoseEvent;
        public static Action<string> TouchEvent;
        public static Action GameFinishEvent;
        public static Action RunEvent;

        public static Action FinishTriggerEvent;
        public static Action<int> FinishScoreTriggerEvent;
        
        // Vector3 parameter is for collectable position to create relative gem image
        public static Action<Vector3> CollectableEvent;

        public static void DestroyEvents()
        {
            WinEvent = null;
            LoseEvent = null;
            TouchEvent = null;
            GameFinishEvent = null;
            FinishTriggerEvent = null;
            FinishScoreTriggerEvent = null;
            RunEvent = null;
            CollectableEvent = null;
        }
        
    }
    
    public class LevelManager : MonoBehaviour
    {
        
        [SerializeField] private bool transitionWithPrefab;
        [SerializeField] private GameData gameData;

        [HideInInspector] public static LevelData LevelData;

        private const int LevelResetIndex = 1;
        
        private int _currentLevel;

        private int _levelIndex;

        private void Awake()
        {
            InitLevelData();

            if (transitionWithPrefab)
            {
                InstantiateLevel();
            }
        }

        private void InitLevelData()
        {
            _currentLevel = PlayerPrefs.GetInt("PlayerLevel");

            var lastLevelIndex = gameData.LastLevelIndex;
            _levelIndex = lastLevelIndex == gameData.levelsDataArray.Length - 1 ? LevelResetIndex : lastLevelIndex + 1;
            LevelData = gameData.levelsDataArray[_levelIndex];
            
#if UNITY_EDITOR
            Debug.Log($"Current Level: {_currentLevel.ToString()}");
#endif
            
        }
        
        private static void IncreasePlayerPrefLevel()
        {
            PlayerPrefs.SetInt("PlayerLevel", PlayerPrefs.GetInt("PlayerLevel") + 1);
        }
    
        //Returns scene name
        public string GetNextSceneName()
        {
            IncreasePlayerPrefLevel();
            if (transitionWithPrefab)
            {
                return GetSceneName();
            }
        
            var sceneIndex = SceneManager.GetActiveScene().buildIndex + 1;
            if (sceneIndex >= SceneManager.sceneCountInBuildSettings)
            {
                sceneIndex = LevelResetIndex;
            }

            var path = SceneUtility.GetScenePathByBuildIndex(sceneIndex);
            var sceneName = path.Substring(0, path.Length - 6).Substring(path.LastIndexOf('/') + 1);

            return sceneName;
        }
        

        public string GetSceneName()
        {
            return SceneManager.GetActiveScene().name;
        }
    
        private void Start()
        {
            SignUpEvents();
        }

        private void SignUpEvents()
        {
            SignUpWinEvent();
            SignUpLoseEvent();
            SignUpOtherEvents();
        }

        
        private void OnGameOverEvents()
        {
            GameEvents.LoseEvent = null;
            GameEvents.WinEvent = null;
        }
        
        private void OnLoseEvent()
        {
            OnGameOverEvents();
            /*Elephant.LevelFailed(_currentLevel);*/
        }

        private void SignUpLoseEvent()
        {
            GameEvents.LoseEvent += OnLoseEvent;
        }
    
        private void SignUpWinEvent()
        {
            GameEvents.WinEvent += OnWinEvent;
        }

        private void SignUpOtherEvents()
        {
            GameEvents.FinishTriggerEvent += LockToWin;
        }

        private void LockToWin()
        {
            GameEvents.LoseEvent -= OnLoseEvent;
            GameEvents.WinEvent += OnWinEvent;
        }

        private void OnWinEvent()
        {
            OnGameOverEvents();
            /*Elephant.LevelCompleted(_currentLevel);*/
        }

        private void InstantiateLevel()
        {
            Instantiate(gameData.levelsDataArray[_currentLevel % gameData.levelsDataArray.Length].levelObject);

            LevelData = gameData.levelsDataArray[_currentLevel % gameData.levelsDataArray.Length];
        }

        private void OnDestroy()
        {
            GameEvents.DestroyEvents();
        }
    }
}