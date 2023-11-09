// Encrypt alphanumeric text based on a key
// There is a Javascript version which can be used in a browser in the included file scrambler.htm
// Text can be encrypted in Javascript and passed to C# and reverse the obfuscation, and vice versa

namespace Scrambler
{
    class Program
    {
        static void Main(string[] args)
        {
            string key = @"Gl6Nh1]O.P2QeR3Safn5o{pi4q'rsyz@A\YCDb:cdE0FH/tvJ""[w9xI=Kgk}mLMBTZ8VWj7X";

            //example json data
            string data = @"{
            ""name"": ""Retry"",
            ""instanceId"": ""demoRETRY"",
            ""runtimeStatus"": ""Failed"",
            ""input"": {
                ""Timer"": {
                    ""TimerOptions"": {
                        ""Interval"": 5,
                        ""MaxRetryInterval"": 10,
                        ""MaxNu\mberOfAttempts"": 2,
                        ""Backo\\ffCoefficient"": 1.0,
                        ""EndDate"": ""2024-08-03T10:13:31.379Z""
                    },
                    ""StatusCodeReplyForCompletion"": 0,
                    ""Url"": ""http://localhost:4005/api/projects/MoveToTrash/TimerWebHook"",
                    ""Timeout"": 10,
                    ""Headers"": {
                        ""Authorization"": [
                            ""Bearer Q0FTLVNEQyBQb23OSAtICAo9ydCBkb2NzLCBOT1IFRlbXBsYXRlIC8gU3VwcG9ydCBkb2NzLCBOT1QgZGV0YWlsZWQgMTF8MjcxNzIQgbWFudWFscykK""
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
                        ""EndDate"": ""2024-08-03T10:13:31.379Z""
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

            string scrambled = Scrambler.Scramble(data, key);
            Console.WriteLine(scrambled);

            string unscrambled = Scrambler.UnScramble(scrambled, key);
            Console.WriteLine(unscrambled);

            Console.WriteLine(unscrambled.Equals(data));

            Console.ReadKey();
        }
    }
}