using System;
using StardewModdingAPI;
using StardewValley;
using StardewValley.Tools;
using Microsoft.Xna.Framework;
using StardewModdingAPI.Events;

namespace MasterHunterr // Ensure the folder matches this namespace
{
    public class ModEntry : Mod
    {
        private bool isMenuVisible = false;

        public override void Entry(IModHelper helper)
        {
            // Add an event to handle button presses
            helper.Events.Input.ButtonPressed += OnButtonPressed;
        }

        private void OnButtonPressed(object sender, ButtonPressedEventArgs e)
        {
            // Check if F1 was pressed
            if (e.Button == SButton.F1) // Using SButton to check keys in SMAPI
            {
                isMenuVisible = !isMenuVisible;
                if (isMenuVisible)
                {
                    ShowCheatMenu();
                }
                else
                {
                    HideCheatMenu();
                }
            }

            if (isMenuVisible)
            {
                if (e.Button == SButton.D1) // Add gold when pressing '1'
                {
                    Game1.player.Money += 10000;
                    Game1.addHUDMessage(new HUDMessage("Added 10,000 gold!", 1)); // 1 represents a positive message
                    Monitor.Log("Added gold: 10,000", LogLevel.Info);
                }
                if (e.Button == SButton.D2) // Speed up time when pressing '2'
                {
                    Game1.timeOfDay += 300; // Increase time by 5 minutes
                    Game1.addHUDMessage(new HUDMessage("Time sped up!", 1)); // 1 represents a positive message
                    Monitor.Log("Time sped up", LogLevel.Info);
                }
            }
        }

        private void ShowCheatMenu()
        {
            // Show the options in the menu
            Game1.drawObjectDialogue("Cheat menu activated!\n1. Add 10,000 gold\n2. Speed up time\nPress F1 to close.");
            Monitor.Log("Displayed cheat menu", LogLevel.Info);
        }

        private void HideCheatMenu()
        {
            // Hide the menu
            Game1.drawObjectDialogue("Cheat menu deactivated");
            Monitor.Log("Hidden cheat menu", LogLevel.Info);
        }

    }
}
