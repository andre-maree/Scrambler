﻿// Obfuscate alphanumeric text based on a key
// There is a Javascript version which can be used in a browser in the included file scrambler.htm
// Text can be obfuscated in Javascript and passed to C# and reverse the obfuscation, and vice versa

string key = "Gl6Nh1O.P2QeR3Safn5o{pi4q'rsyz@AYCDb:cdE0FHtvJw9xIKgk}mLMBTZ8VWj7X";

string scrambled = Scrambler.Scrambler.Scramble("andre.maree@engagementfactory.com", key);

string unscrambled = Scrambler.Scrambler.UnScramble(scrambled, key);