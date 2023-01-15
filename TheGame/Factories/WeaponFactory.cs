﻿using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using System.IO;
using TheGame.Items;

namespace TheGame.Factories
{
    public static class WeaponFactory
    {
        private static readonly string WeaponsFilePath = Path.Combine(Common.GetWorkingDirectory(), "Weapons");
        private static HashSet<Weapon> Weapons { get; set; } = new();

        public static List<Weapon> GetWeapons() => ReadWeaponsFromFile();

        public static void GenerateWeapon(int id, string name, int amountDice, Dice damageDice, string description = "")
        {
            Weapon weapon = new(id, name, amountDice, damageDice, description);
            Weapons.Add(weapon);
            WriteToFile(weapon);
        }

        private static void WriteToFile(Weapon weapon)
        {
            string json = JsonConvert.SerializeObject(weapon);
            if (!Directory.Exists(WeaponsFilePath))
            {
                Directory.CreateDirectory(WeaponsFilePath);
            }

            var path = Path.Combine(WeaponsFilePath, $"{weapon.Name}.json");
            File.WriteAllText(path, json);
        }

        private static List<Weapon> ReadWeaponsFromFile()
        {
            try
            {
                string json = File.ReadAllText(Path.Combine(WeaponsFilePath, "Weapons.json"));
                List<Weapon>? weapons = JsonConvert.DeserializeObject<List<Weapon>>(json);
                if (weapons is null)
                {
                    throw new NullReferenceException($"Weapons list from file was null.");
                }
                return weapons;
            }
            catch (Exception exc)
            {
                Logger.LogError(exc);
                return new List<Weapon>();
            }
        }

        public static void ZipWeapons()
        {
            string json = JsonConvert.SerializeObject(Weapons);
            if (!Directory.Exists(WeaponsFilePath))
            {
                Directory.CreateDirectory(WeaponsFilePath);
            }

            var path = Path.Combine(WeaponsFilePath, "Weapons.json");
            File.WriteAllText(path, json);
        }

        public static List<Weapon> GenerateWeapons()
        {
            GenerateWeapon(1, "Knife", 1, Dice.d4, "Is very sharp...");
            GenerateWeapon(2, "Shortsword", 1, Dice.d6, "Is even sharper...");
            GenerateWeapon(3, "Longsword", 1, Dice.d8, "The sharpest...");
            return Weapons.ToList();
        }

        public static Weapon GetRandomWeapon()
        {
            Random rnd = new();
            return Weapons.ToArray()[rnd.Next(Weapons.Count)];
        }
    }
}