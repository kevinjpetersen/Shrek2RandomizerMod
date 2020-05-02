using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace Shrek2RandomizerMod
{
    class Program
    {
        static void Main(string[] args)
        {
            var SH2 = new Shrek2KeyboardForeground();

            if (SH2.Initialize() == false) return;

            List<string> cmdLines = new List<string>();

            // Add Reset on Characters
            foreach (var character in Shrek2Actors.Characters)
                cmdLines.Add(GenerateSkeletalMeshLine(character, character));

            // Affected Characters
            Shrek2Actors.Characters.Shuffle();
            var affectedCharacters = Shrek2Actors.Characters.ToList();

            // Assigned Characters
            Shrek2Actors.Characters.Shuffle();
            var assignedCharacters = Shrek2Actors.Characters.ToList();

            for(int i = 0; i < affectedCharacters.Count; i++)
            {
                var afc = affectedCharacters[i];
                var asc = assignedCharacters[i];

                cmdLines.Add(GenerateSkeletalMeshLine(afc, asc));
            }

            File.WriteAllLines(Path.Combine(Directory.GetCurrentDirectory(), "SH2Random"), cmdLines);
            SH2.SendCommand("exec SH2Random");
        }

        static string GenerateSkeletalMeshLine(string affectedCharacter, string assignedCharacter) =>
            $"set {affectedCharacter} mesh skeletalmesh'ShrekCharacters.{assignedCharacter}'";
    }
}
