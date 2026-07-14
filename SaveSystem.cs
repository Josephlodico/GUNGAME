using System;
using System.IO;
using System.Text.Json;

namespace GunGame
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
            if (File.Exists(savePath))
            {
                string json = File.ReadAllText(savePath);
                GameData data = JsonSerializer.Deserialize<GameData>(json);
                Console.WriteLine("Game loaded successfully!");
                return data;
            }
            else
            {
                Console.WriteLine("No saved game found.");
                return null;
            }
        }
    }
}
