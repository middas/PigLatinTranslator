using System.Text;

namespace PigLatinTranslator
{
    public static class PigLatinTranslator
    {
        public static string Translate(string input)
        {
            if (string.IsNullOrEmpty(input))
            {
                return input;
            }

            string[] words = GetWords(input);
            words = TranslateWords(words);

            return string.Concat(words);
        }

        private static string[] GetWords(string input)
        {
            List<string> words = [];

            StringBuilder currentWord = new();

            for (int i = 0; i < input.Length; i++)
            {
                if (char.IsLetter(input[i]))
                {
                    currentWord.Append(input[i]);
                    continue;
                }

                if (currentWord.Length > 0)
                {
                    words.Add(currentWord.ToString());
                    currentWord.Clear();
                }

                // keep punctuation and spaces
                words.Add(input[i].ToString());
            }

            if (currentWord.Length > 0)
            {
                words.Add(currentWord.ToString());
            }

            return [.. words];
        }

        private static string[] TranslateWords(string[] words)
        {
            const string vowels = "AEIOUaeiou";
            const char pigLatinVowelSuffix = 'w';
            const string pigLatinSuffix = "ay";

            for (int i = 0; i < words.Length; i++)
            {
                if (string.IsNullOrWhiteSpace(words[i]) || !char.IsLetter(words[i][0]))
                {
                    continue;
                }

                char firstChar = words[i][0];
                bool isCapitalized = char.IsUpper(firstChar);
                bool isVowel = vowels.Contains(firstChar);

                StringBuilder stringBuilder = new(words[i], 1, words[i].Length - 1, words[i].Length + 3);
                stringBuilder.Append(char.ToLower(firstChar));
                if (isVowel)
                {
                    stringBuilder.Append(pigLatinVowelSuffix);
                }
                stringBuilder.Append(pigLatinSuffix);

                if (isCapitalized)
                {
                    stringBuilder[0] = char.ToUpper(stringBuilder[0]);
                }

                words[i] = stringBuilder.ToString();
            }

            return words;
        }
    }
}