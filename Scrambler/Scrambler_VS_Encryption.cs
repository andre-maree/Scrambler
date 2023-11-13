using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace Scrambler
{
    internal class Scrambler_VS_Encryption
    {
        public static async Task DoTheTest(string scramblerKey, Encoding enc)
        {
            StringBuilder sb = new(data);

            for (int i = 0; i < 15; i++)
            {
                sb.Append(sb);
            }

            string bigdata = sb.ToString();

            Stopwatch sw = Stopwatch.StartNew();

            Scrambler.Scramble(bigdata, scramblerKey, enc);

            sw.Stop();

            double time1 = sw.ElapsedMilliseconds;

            Console.WriteLine(time1);
            double scramblersize = enc.GetByteCount(bigdata);
            Console.WriteLine(scramblersize);

            const string passphrase = "Sup3rS3curePass!";

            sw.Start();

            var encrypted = await EncryptAsync(bigdata, passphrase);

            sw.Stop();

            double time2 = sw.ElapsedMilliseconds;

            Console.WriteLine(time2); 
            Console.WriteLine(encrypted.Length);
            Console.WriteLine($"Encrypted data: {encrypted.Length}");
            Console.WriteLine();

            var timediff = (time1 - time2) / time1 * 100;
            var sizediff = (scramblersize - encrypted.Length) / scramblersize * 100;

            Console.WriteLine("Scrambler is faster by : " + Math.Round(timediff, 2) + "%");
            Console.WriteLine("Scrambler size is smaller by : " + Math.Round(sizediff, 2) + "%");
            Console.WriteLine();
            Console.WriteLine();
        }

        public static async Task<string> DecryptAsync(byte[] encrypted, string passphrase)
        {
            using Aes aes = Aes.Create();
            aes.Key = DeriveKeyFromPassword(passphrase);
            aes.IV = IV;
            using MemoryStream input = new(encrypted);
            using CryptoStream cryptoStream = new(input, aes.CreateDecryptor(), CryptoStreamMode.Read);
            using MemoryStream output = new();
            await cryptoStream.CopyToAsync(output);
            return Encoding.Unicode.GetString(output.ToArray());
        }

        private static byte[] IV =
        {
            0x01, 0x02, 0x03, 0x04, 0x05, 0x06, 0x07, 0x08,
            0x09, 0x10, 0x11, 0x12, 0x13, 0x14, 0x15, 0x16
        };

        private static byte[] DeriveKeyFromPassword(string password)
        {
            var emptySalt = Array.Empty<byte>();
            var iterations = 1000;
            var desiredKeyLength = 16; // 16 bytes equal 128 bits.
            var hashMethod = HashAlgorithmName.SHA384;
            return Rfc2898DeriveBytes.Pbkdf2(Encoding.Unicode.GetBytes(password),
                                             emptySalt,
                                             iterations,
                                             hashMethod,
                                             desiredKeyLength);
        }

        public static async Task<byte[]> EncryptAsync(string clearText, string passphrase)
        {
            using Aes aes = Aes.Create();
            aes.Key = DeriveKeyFromPassword(passphrase);
            aes.IV = IV;
            using MemoryStream output = new();
            using CryptoStream cryptoStream = new(output, aes.CreateEncryptor(), CryptoStreamMode.Write);
            await cryptoStream.WriteAsync(Encoding.Unicode.GetBytes(clearText));
            await cryptoStream.FlushFinalBlockAsync();
            return output.ToArray();
        }

        static string data = @"{
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
    }
}
