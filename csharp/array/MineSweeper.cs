using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Dojo2.Test
{
    using System.Globalization;

    public class MineSweeper
    {
        public static string ResolveMineField(string mineField)
        {
            if (string.IsNullOrEmpty(mineField))
                return string.Empty;
            if (mineField == "*")
                return "*";
            if (mineField == ".")
                return "0";
            string result = string.Empty;
            var splittedMineField = mineField.Split('\n');
            var currentLine = 0;
            var fieldCount = 0;
            while (currentLine < splittedMineField.Count()-1)
            {
                fieldCount++;
                var fieldDef = splittedMineField[currentLine].Split(' ');
                var lineCount = Int32.Parse(fieldDef[0]);
                var columnCount = Int32.Parse(fieldDef[1]);
                if (lineCount == 0 && columnCount == 0)
                {
                    return result.Substring(0, result.Length - 1);
                }

                currentLine++;
                result += string.Format("Field #{0}:\n", fieldCount);
                result += SolveMineField(splittedMineField.Skip(currentLine).Take(lineCount).ToArray());
                currentLine += lineCount;
            }
            if (result.Length >= 1)
                return result.Substring(0, result.Length - 1);
            return result;
        }

        private static string SolveMineField(string[] splittedMineField)
        {
            string result = string.Empty;
            for (int cptLigne = 0; cptLigne < splittedMineField.Length; cptLigne++)
            {
                for (int cptColonne = 0; cptColonne < splittedMineField[cptLigne].Length; cptColonne++)
                {
                    if (splittedMineField[cptLigne][cptColonne] == '*')
                    {
                        result += '*';
                    }
                    else
                    {
                        var nbMine = 0;
                        if (cptColonne > 0 && cptLigne > 0 && splittedMineField[cptLigne - 1][cptColonne - 1] == '*')
                            nbMine++;

                        if (cptColonne > 0 && splittedMineField[cptLigne][cptColonne - 1] == '*')
                            nbMine++;

                        if (cptColonne > 0 && cptLigne < splittedMineField.Length - 1 &&
                            splittedMineField[cptLigne + 1][cptColonne - 1] == '*')
                            nbMine++;

                        if (cptLigne > 0 && splittedMineField[cptLigne - 1][cptColonne] == '*')
                            nbMine++;

                        if (cptLigne < splittedMineField.Length - 1 && splittedMineField[cptLigne + 1][cptColonne] == '*')
                            nbMine++;


                        if (cptColonne < splittedMineField[cptLigne].Length - 1 && cptLigne > 0 &&
                            splittedMineField[cptLigne - 1][cptColonne + 1] == '*')
                            nbMine++;

                        if (cptColonne < splittedMineField[cptLigne].Length - 1 &&
                            splittedMineField[cptLigne][cptColonne + 1] == '*')
                            nbMine++;

                        if (cptColonne < splittedMineField[cptLigne].Length - 1 && cptLigne < splittedMineField.Length - 1 &&
                            splittedMineField[cptLigne + 1][cptColonne + 1] == '*')
                            nbMine++;

                        result += nbMine.ToString(CultureInfo.InvariantCulture);
                    }
                }
                result += "\n";
            }
            return result;
        }
    }
}
