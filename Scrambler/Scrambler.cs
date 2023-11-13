using System.Text;

namespace Scrambler
{
    public static class Scrambler
    {
        /// <summary>
        /// Obfuscate the input text with the key
        /// </summary>
        public static string Scramble(this string text, string key, Encoding enc)
        {
            text = Convert.ToBase64String(enc.GetBytes(text));

            Dictionary<char, char> chars;
            StringBuilder sb;
            CreateLookup(text, key, out chars, out sb);

            for (int i = 0; i < sb.Length; i++)
            {
                if (key.Contains(sb[i]))
                {
                    sb[i] = chars[sb[i]];
                }
            }

            return sb.ToString();
        }

        /// <summary>
        /// Reverse the obfuscated text with the key
        /// </summary>
        public static string UnScramble(this string text, string key, Encoding enc)
        {
            Dictionary<char, char> chars;
            StringBuilder sb;
            CreateLookup(text, key, out chars, out sb);

            for (int i = 0; i < text.Length; i++)
            {
                char c = chars.SingleOrDefault(d => d.Value.Equals(sb[i])).Key;
                if (c != 0)
                {
                    sb[i] = c;
                }
            }

            return enc.GetString(Convert.FromBase64String(sb.ToString()));
        }

        /// <summary>
        /// Helper method to create a lookup dictionary based on the key
        /// </summary>
        private static void CreateLookup(string text, string key, out Dictionary<char, char> chars, out StringBuilder sb)
        {
            chars = new Dictionary<char, char>();
            for (int i = 0; i < key.Length; i++)
            {
                chars.Add(key[i], key[key.Length - 1 - i]);
            }

            sb = new StringBuilder(text);
        }
    }
}