using System;
using System.Collections.Generic;
using System.Linq;

namespace PC0483SecretCode.Helpers
{
    public static class ConvertCodeToTextHelper
    {
        public static List<string> ConvertToText(string code)
        {
            if (code.Length != 5 || !TextHelper.IsNumberOnly(code))
            {
                return [$"ERROR_CODE({code})"];
            }

            string consonantCode = $"{code[0]}{code[1]}";
            string vowelCode = $"{code[2]}{code[3]}";
            string toneMarkCode = $"{code[4]}";

            //bool checkConsonant = TextHelper.ConsonantCodes.TryGetValue(consonantCode, out var consonant);

            //bool checkVowel = TextHelper.VowelCodes.TryGetValue(vowelCode, out var vowels);

            //bool checkToneMark = TextHelper.ToneMarksAndPunctuations.TryGetValue(toneMarkCode, out var toneMark);

            //if (!checkConsonant || !checkVowel || !checkToneMark)
            //{
            //    return [$"ERROR_CODE({code})"];
            //}

            //List<string> texts = [];
            //foreach (var vowel in vowels!)
            //{
            //    texts.Add($"{consonant![0]}{vowel}{toneMark}");
            //}
            //return texts;

            var consonants = TextHelper.ConsonantCodes
                          .Where(pair => pair.Key.Equals(consonantCode, StringComparison.OrdinalIgnoreCase))
                          .SelectMany(pair => pair.Value)
                          .ToList();

            var vowels = TextHelper.VowelCodes
                            .Where(pair => pair.Key.Equals(vowelCode, StringComparison.OrdinalIgnoreCase))
                            .SelectMany(pair => pair.Value) 
                            .ToList();

            var tones = TextHelper.ToneMarksAndPunctuations
                            .Where(pair => pair.Key.Equals(toneMarkCode, StringComparison.OrdinalIgnoreCase))
                            .Select(pair => pair.Value)
                            .ToList();

            List<string> resuls = [];
            foreach (var _consonant in consonants)
            {
                foreach (var _vowel in vowels)
                {
                    foreach (var _tone in tones)
                    {
                        resuls.Add($"{_consonant}{_vowel}{_tone}");
                    }
                }
            }

            return resuls;
        }
    }
}