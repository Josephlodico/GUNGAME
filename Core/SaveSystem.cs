using System;
using System.IO;
using System.Text.Json;

namespace GunGame.Core
{
    public static class SaveSystem
    {
        private static readonly string savePath = "saveData.txt";

        public static void SaveGame(GameData data)
        {
            string json = JsonSerializer.Serialize(data);
            File.WriteAllText(savePath, json);
            Console.WriteLine("Game saved successfully!");
        }

        public static GameData LoadGame()
        {
            if (!File.Exists(savePath))
            {
                Console.WriteLine("No saved game found.");
                return null;
            }

            try
            {
                string json = File.ReadAllText(savePath);
                GameData data = JsonSerializer.Deserialize<GameData>(json);
                Console.WriteLine("Game loaded successfully!");
                return data;
            }
            catch (JsonException)
            {
                Console.WriteLine("The saved game file was corrupted and could not be loaded. Starting a new game.");
                DeleteSave();
                return null;
            }
        }

        public static void DeleteSave()
        {
            if (File.Exists(savePath))
            {
                File.Delete(savePath);
            }
        }
    }
}
