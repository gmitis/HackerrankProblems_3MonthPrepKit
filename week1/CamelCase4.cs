using System;
using System.Collections.Generic;
using System.IO;





class Solution {

    public static void ConvertCamel(string varType, string variable)
    {
        string[] varWords = variable.Split(" ");
        string result = "";

        if  (varType == "M")
        {
            result = varWords[0];
            varWords = varWords[1..];
            result = result +
                     string.Join(
                        "",
                        varWords.Select(word => char.ToUpper(word[0]) + word[1..] )
                                .ToArray()
                    ) + "()";
        }
        else 
        {
            foreach (var word in varWords) {
                result += char.ToUpper(word[0]) + word[1..];
            }
            
            if (varType == "V") result = char.ToLower(result[0]) + result[1..];
        }
        

        Console.WriteLine(result);
    }


    public static void ConvertSpace(string varType, string variable)
    {
        int j = 0;
        string lowerCaseName = variable.ToLower();
        string result;
        List<string> words = new List<string>();
        List<int> upperCharIndex = new List<int>();
        
        for (int i=0; i<variable.Length; i++)
        {
            if (char.IsUpper(variable[i])) 
            {
                upperCharIndex.Add(i);
            }
            
        }
        
        // only one word given
        if (upperCharIndex.Count == 0) words.Add(lowerCaseName);
        else {
            foreach (var ind in upperCharIndex)
            {
                words.Add(lowerCaseName[j..ind]);
                j = ind;
            }
            words.Add(lowerCaseName[j..]);
        }

        result = string.Join(" ", words);
        if (varType == "M") result = result[0..^2];
        else if (varType == "C") result = result[1..];
        
        Console.WriteLine(result);
    }


    static void Main(String[] args) {
        string input, action, varType, variable;
        string[] input_part;
        string[] validAction = {"C", "S"};
        string[] validVarType = {"M", "V", "C"};

        // get each line of input and convert it according to action
        while ( !string.IsNullOrWhiteSpace(input = Console.ReadLine()) )
        {
            
            input_part = input.Split(';');
            if (input_part.Length != 3) 
            {
                Console.WriteLine("Wrong input length, please insert again");
                continue;
            }

            if (! (validAction.Contains(input_part[0]) && validVarType.Contains(input_part[1])) ) 
            {
                Console.WriteLine("Wrong input");
                continue;
            }



            action = input_part[0];
            varType = input_part[1];
            variable = input_part[2];

        
            if      ( action == "C")    ConvertCamel(varType, variable);
            else                        ConvertSpace(varType, variable);
        }
    }
}
