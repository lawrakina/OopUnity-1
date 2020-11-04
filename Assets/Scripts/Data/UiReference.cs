using UnityEngine;

namespace Data
{
    public sealed class UiReference
    {
        private Canvas _canvas; 
        private GameObject _menu;
        private GameObject _endGame;
        private GameObject _pauseGame;

        public Canvas Canvas
        {
            get
            {
                if (_canvas == null)
                {
                    _canvas = Object.FindObjectOfType<Canvas>();
                }
                return _canvas;
            }
        }
        
        public GameObject Menu
        {
            get
            {
                if (_endGame == null)
                {
                    var gameObject = Resources.Load<GameObject>("UI/Menu");
                    _endGame = Object.Instantiate(gameObject, Canvas.transform);
                    return _endGame;
                }

                return _menu;
            }
        }
        
        public GameObject EndGame
        {
            get
            {
                if (_endGame == null)
                {
                    var gameObject = Resources.Load<GameObject>("UI/EndGame");
                    _endGame = Object.Instantiate(gameObject, Canvas.transform);
                    return _endGame;
                }

                return _endGame;
            }
        }
        
        public GameObject PauseGame
        {
            get
            {
                if (_pauseGame == null)
                {
                    var gameObject = Resources.Load<GameObject>("UI/PauseGame");
                    _pauseGame = Object.Instantiate(gameObject, Canvas.transform);
                    return _pauseGame;
                }

                return _pauseGame;
            }
        }
        
        
    }
}