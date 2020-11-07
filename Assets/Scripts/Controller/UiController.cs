using System;
using System.Diagnostics;
using Enum;
using Healper;
using Interface;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;
using View;


namespace Controller
{
    public sealed class UiController : IInitialization, ICleanup
    {
        #region Fields

        private UiPlay                    _ui;
        private IIntNotifyPropertyChange       _coinCount;
        private IIntNotifyPropertyChange       _maxCoinCount;
        private IIntNotifyPropertyChange       _liveCount;
        private IGameStateNotifyPropertyChange _gameState;
        private GameObject                     _menuScreen;
        private GameObject                     _pauseScreen;
        private GameObject                     _endGameScreen;

        #endregion


        #region ClassLiveCycles

        public UiController(UiPlay    ui,
            IIntNotifyPropertyChange       coinCount,
            IIntNotifyPropertyChange       maxCoinCount,
            IIntNotifyPropertyChange       liveCount,
            GameObject                     menuScreen,
            GameObject                     pauseScreen,
            GameObject                     endGameScreen,
            IGameStateNotifyPropertyChange gameState)
        {
            _ui = ui;
            _coinCount = coinCount;
            _maxCoinCount = maxCoinCount;
            _liveCount = liveCount;
            _menuScreen = menuScreen;
            _pauseScreen = pauseScreen;
            _endGameScreen = endGameScreen;
            _gameState = gameState;

            _ui.PauseButton.onClick.AddListener(EnablePause());
            _menuScreen.GetComponentInChildren<Button>().onClick.AddListener(StartGame());

            _coinCount.OnValueChange += CoinCountOnValueChange;
            _maxCoinCount.OnValueChange += MaxCoinCountOnValueChange;
            _liveCount.OnValueChange += LiveCountOnValueChange;
            _gameState.OnValueChange += GameStateOnValueChange;

            ShowOneScreen(_menuScreen);
        }

        private UnityAction StartGame()
        {
            return () => { _gameState.SetValue(GameState.Play, "Start"); };
        }

        private UnityAction EnablePause()
        {
            return () =>
            {
                if (_gameState.Value == GameState.Play)
                {
                    _gameState.SetValue(GameState.Pause, "Pause");
                }
                else
                {
                    _gameState.SetValue(GameState.Play, "");
                }
            };
        }


        private void GameStateOnValueChange(GameState state, string message)
        {
            switch (state)
            {
                case GameState.Menu:
                    SetTimeScale(0.0f);
                    ShowOneScreen(_menuScreen);
                    break;
                case GameState.Play:
                    SetTimeScale(1.0f);
                    ShowOneScreen(null);
                    break;
                case GameState.Pause:
                    SetTimeScale(0.0f);
                    ShowOneScreen(_pauseScreen);
                    break;
                case GameState.Win:
                    SetTimeScale(0.0f);
                    ShowOneScreen(_endGameScreen);
                    _endGameScreen.GetComponentInChildren<Text>().text = message;
                    break;
                case GameState.Fail:
                    SetTimeScale(0.0f);
                    ShowOneScreen(_endGameScreen);
                    _endGameScreen.GetComponentInChildren<Text>().text = message;
                    break;
                default:
                    throw new ArgumentOutOfRangeException(nameof(state), state, null);
            }
        }

        private static void SetTimeScale(float newTime)
        {
            Time.timeScale = newTime;
        }

        private void ShowOneScreen(GameObject screen)
        {
            _menuScreen.SetActive(false);
            _pauseScreen.SetActive(false);
            _endGameScreen.SetActive(false);
            if (screen) screen.SetActive(true);
        }

        #endregion


        #region IInitialization

        public void Initialization()
        {
        }

        #endregion


        #region ICleanup

        public void Cleanup()
        {
            _coinCount.OnValueChange -= CoinCountOnValueChange;
            _maxCoinCount.OnValueChange -= MaxCoinCountOnValueChange;
            _liveCount.OnValueChange -= LiveCountOnValueChange;
            _gameState.OnValueChange -= GameStateOnValueChange;
        }

        #endregion


        #region Methods

        private void LiveCountOnValueChange(int value)
        {
            _ui.LivesUiView.Text = $"Live: {value}";
        }

        private void MaxCoinCountOnValueChange(int value)
        {
            _ui.MaxCoinsUiView.Text = $"/{value}";
        }

        private void CoinCountOnValueChange(int value)
        {
            _ui.CoinsUiView.Text = $"{value}";
        }

        #endregion
    }
}