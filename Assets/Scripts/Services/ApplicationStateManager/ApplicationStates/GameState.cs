using System.Collections.Generic;
using Constants;
using StateManager;
using UnityEngine;

namespace Services
{
    public class GameState : BaseApplicationState
    {
        public readonly string UI_PREFAB = UIPrefabs.UIGame;

        //public readonly int SCENE_INDEX = (int)SceneIndexes.FIRST_SCENE_NAME;
        //private AudioClip _mainMenuMusic = Resources.Load<AudioClip>("MainMenuMusic");
        private UIWidget _uiWidget;

        public GameState()
        {

        }

        protected override void SetToActiveStateFromBackground(BaseState prevState, Dictionary<string, object> options)
        {
            if (_uiWidget != null)
            {
                _uiWidget.UIObject.SetActive(true);
            }

            Time.timeScale = 1f;
        }

        protected override void SetToBackgroundStateFromActive(BaseState prevState, Dictionary<string, object> options)
        {
            if (_uiWidget != null)
            {
                _uiWidget.UIObject.SetActive(false);
            }
        }

        protected override void SetupState(BaseState prevState, Dictionary<string, object> options)
        {
            _uiWidget = ServiceLocator.Instance.Get<UIManager>().LoadUI(UI_PREFAB);
            //ServiceLocator.Instance.Get<LevelSceneManager>().LoadLevel(SCENE_INDEX);
            //ServiceLocator.Instance.Get<MusicManager>().StartSong(_mainMenuMusic, 1f);
        }

        protected override void SetupStateInBackground(BaseState prevState, Dictionary<string, object> options)
        {
            SetupState(prevState, options);
            SetToBackgroundStateFromActive(prevState, options);
        }

        protected override void TeardownState(BaseState prevState, Dictionary<string, object> options)
        {
            if (_uiWidget != null)
            {
                ServiceLocator.Instance.Get<UIManager>().RemoveUIByGuid(_uiWidget.GUID);
            }
        }
    }
}
