// Encrypt alphanumeric text based on a key
// There is a Javascript version which can be used in a browser in the included file scrambler.htm
// Text can be encrypted in Javascript and passed to C# and reverse the obfuscation, and vice versa

namespace Scrambler
{
    class Program
    {
        public static string GenerateKey(string str)
        {
            char[] array = str.ToCharArray();
            Random rng = new Random();
            int n = array.Length;
            while (n > 1)
            {
                n--;
                int k = rng.Next(n + 1);
                var value = array[k];
                array[k] = array[n];
                array[n] = value;
            }
            return new string(array);
        }

        static void Main(string[] args)
        {
            string allchars = @"!""#$%&'()*+,-./0123456789:;<=>?@ABCDEFGHIJKLMNOPQRSTUVWXYZ[\]^_`abcdefghijklmnopqrstuvwxyz{|}~";

            string key = GenerateKey(allchars);

            Console.WriteLine("Data before encryption with random generated key:");
            Console.WriteLine(key);
            Console.WriteLine();

            //string key = @"Gl6Nh1]O.P2)QeR3S#af&n(5o{pi4*q'rs;yz@A\Y!CDb:cdE-+0FH/tvJ""[w9xI=Kgk}mLM$BTZ8VWj%7X";
            Console.BackgroundColor = ConsoleColor.Blue;
            Console.ForegroundColor = ConsoleColor.White;
            //example json data
            string data = @"{
            ""name"": ""Retry"",
            ""instanceId"": ""demoRETRY"",
            ""runtimeStatus"": ""Failed"",
            ""input"": {
                ""Timer"": {
                    ""TimerOptions"": {
                        ""Interval"": 5,
                        ""MaxRetryI'erval"": 10,
                        ""MaxNu\mberOfAttempts"": 2,
                        ""Backo\\ffCoefficient"": 1.0,
                        ""EndDate"": ""2024-08-03T10:13:31.379Z""
                    },
                    ""StatusCodeReplyForCompletion"": 0,
                    ""Url"": ""http://localhost:4005/api/projects/MoveToTrash/TimerWebHook"",
                    ""Timeout"": 10,
                    ""Headers"": {
                        ""Authorization"": [
                            ""Bearer Q0FTLVNEQyBQb23OSAtICAo9ydCBkb2NzLCBOT1IFRlbXBsYXRlI'8gU3VwcG9ydCBkb2NzLCBOT1QgZGV0YWlsZWQgMTF8MjcxNzIQgbWFudWFscykK""
                        ]
                    },
                    ""HttpMethod"": {
                        ""Method"": ""GET""
                    },
                    ""Content"": ""someuser@gmail.com"",
                    ""PollIf202"": true,
                    ""RetryOptions"": {
                        ""Interval"": 10,
                        ""MaxRetryInterval"": 10,
                        ""MaxNumberOfAttempts"": 1,
                        ""BackoffCoefficient"": 1.0,
                        ""EndDate"": ""2024-08-03T1""""0:13:31.379Z""
                    }
                },
                ""Count"": 0,
                ""Deadline"": ""2023-11-08T15:02:44.7537176Z"",
                ""HasWebhook"": false
            },
                ""customStatus"": ""The operation was canceled. Reached user specified timeout: 00:00:10."",
                ""output"": ""Orchestrator function 'Retry' failed: The operation was canceled. Reached user specified timeout: 00:00:10."",
                ""createdTime"": ""2023-11-08T15:02:44Z"",
                ""lastUpdatedTime"": ""2023-11-08T15:03:02Z""
            }";
                        
            Console.WriteLine(data);

            Console.WriteLine();
            Console.BackgroundColor = ConsoleColor.Black;
            Console.ForegroundColor = ConsoleColor.White;
            Console.WriteLine("Data after encryption:");

            string scrambled = Scrambler.Scramble(data, key);
            Console.BackgroundColor = ConsoleColor.Green;
            Console.ForegroundColor = ConsoleColor.White;
            Console.WriteLine(scrambled);

            Console.WriteLine();
            Console.BackgroundColor = ConsoleColor.Black;
            Console.ForegroundColor = ConsoleColor.White;
            Console.WriteLine();
            Console.WriteLine();
            Console.WriteLine("Data after decryption:");

            Console.BackgroundColor = ConsoleColor.Red;
            Console.ForegroundColor = ConsoleColor.White;

            string unscrambled = Scrambler.UnScramble(scrambled, key);
            Console.WriteLine(unscrambled);
            Console.WriteLine();

            Console.BackgroundColor = ConsoleColor.Black;
            Console.ForegroundColor = ConsoleColor.White;

            Console.WriteLine();
            Console.WriteLine("Success: " + unscrambled.Equals(data));

            Console.ReadKey();
            Console.Clear();

            Main(null);
        }
    }
}