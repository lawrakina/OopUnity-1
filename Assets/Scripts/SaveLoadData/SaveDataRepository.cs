using System.IO;
using Controller;
using Model;
using UnityEngine;


namespace SaveLoadData
{
    
    public sealed class SaveDataRepository
    {
        private readonly IData<SavedData> _data;

        private const    string _folderName = "dataSave";
        private const    string _fileName   = "data.bat";
        private readonly string _path;

        public SaveDataRepository()
        {
            if (Application.platform == RuntimePlatform.WebGLPlayer)
            {
                _data = new PlayerPrefsData();
            }
            else
            {
                _data = new JsonData<SavedData>();
            }
            _path = Path.Combine(Application.dataPath, _folderName);
            
        }

        public void Save(PlayerModel player)
        {
            if (!Directory.Exists(Path.Combine(_path)))
            {
                Directory.CreateDirectory(_path);
            }
            var savePlayer = new SavedData
            {
                Position = player.PlayerView.Transform().position,
                Name = "MyName",
                IsEnabled = true
            };

            _data.Save(savePlayer, Path.Combine(_path, _fileName));
        }

        public void Load(PlayerModel player)
        {
            var file = Path.Combine(_path, _fileName);
            if (!File.Exists(file)) return;
            var newPlayer = _data.Load(file);
            player.PlayerView.Transform().position = newPlayer.Position;
            player.PlayerView.Transform().name = newPlayer.Name;
            player.PlayerView.Transform().gameObject.SetActive(newPlayer.IsEnabled);

            Debug.Log(newPlayer);
        }
    }
}