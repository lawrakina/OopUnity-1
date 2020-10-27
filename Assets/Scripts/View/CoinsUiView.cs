using UnityEngine;
using UnityEngine.UI;


namespace View
{
    public sealed class CoinsUiView : MonoBehaviour
    {
        #region Fields

        private Text _text;

        #endregion


        #region Properties

        public string Text
        {
            set => _text.text = $"{value}";
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