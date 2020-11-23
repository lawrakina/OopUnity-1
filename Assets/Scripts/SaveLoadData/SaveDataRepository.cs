using System.Collections.Generic;
using System.IO;
using Controller;
using Enum;
using Model;
using UnityEngine;


namespace SaveLoadData
{
    public sealed class SaveDataRepository
    {
        private readonly IData<Indexator<SavedData>> _data;

        private const    string _folderName = "dataSave";
        private const    string _fileName   = "data.bat";
        private readonly string _path;

        private SavedData _player;
        private List<SavedBonusData> _bonuses;
        public SaveDataRepository()
        {
            // if (Application.platform == RuntimePlatform.WebGLPlayer)
            // {
            //     _data = new PlayerPrefsData();
            // }
            // else
            // {
            _data = new JsonData<Indexator<SavedData>>();

            _path = Path.Combine(Application.dataPath, _folderName);
        }

        public void Save()
        {
            if (!Directory.Exists(Path.Combine(_path)))
            {
                Directory.CreateDirectory(_path);
            }
            
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


        public void AddToSave(PlayerModel player)
        {
            _player = new SavedData
            {
                DataType = SavedDataType.Player,
                Position = player.PlayerView.Transform().position,
                Name = "MyName",
                IsEnabled = true
            };
            _data.
        }

        public void AddToSave(BonusesModel bonuses)
        {
            _bonuses = new List<SavedBonusData>();
            foreach (var item in bonuses.AllBonuses)
            {
                _bonuses.Add(new SavedBonusData
                {
                    DataType = SavedDataType.Bonus,
                    BonusType = item.ObjectType,
                    IsEnabled = item.enabled,
                    Position = item.transform.position
                });
            }
        }
    }

    public sealed class Indexator<T>
    {
        public SavedDataType DataType;
    }
}