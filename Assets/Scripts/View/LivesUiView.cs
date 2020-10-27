using System;
using UnityEngine;
using UnityEngine.UI;

namespace View
{
    public sealed class LivesUiView : MonoBehaviour
    {
        #region Fields

        private Text _text;

        #endregion

        
        #region Properties

        public string Text
        {
            set => _text.text = $"Lives: {value:0.0}";
        }
        
        public int Count
        {
            set => _text.text = $"Lives: {value:0.0}";
        }

        #endregion


        #region UnityMethods

        private void Awake()
        {
            _text = GetComponent<Text>();
        }

        #endregion
    }
}
