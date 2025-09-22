using System.Collections.Generic;

namespace PC0483SecretCode.Helpers
{
    public static class ConvertCodeToTextHelper
    {
        public static List<string> ConvertToText(string code)
        {
            if (code.Length != 5)
            {
                return [$"ERROR_CODE({code})"];
            }

            string consonantCode = $"{code[0]}{code[1]}";
            string vowelCode = $"{code[2]}{code[3]}";
            string toneMarkCode = $"{code[4]}";

            bool checkConsonant = TextConstants.ConsonantCodes.TryGetValue(consonantCode, out var consonant);
            bool checkVowel = TextConstants.VowelCodes.TryGetValue(vowelCode, out var vowels);
            bool checkToneMark = TextConstants.ToneMarksAndPunctuations.TryGetValue(toneMarkCode, out var toneMark);

            if (!checkConsonant || !checkVowel || !checkToneMark)
            {
                return [$"ERROR_CODE({code})"];
            }

            List<string> texts = [];
            foreach (var vowel in vowels!)
            {
                var v1 = consonant![0];
                var v2 = vowel;
                var v3 = toneMark;
                texts.Add($"{consonant![0]}{vowel}{toneMark}");
            }
            return texts;
        }
    }
}