using System;
using System.Linq;
using System.Collections.Generic;

namespace StretchExercise
{
class Program
{
static string Decrypt(string text, int shift)
        {
            char[] characters = text.ToCharArray();
            for (int i = 0; i < characters.Length; i++)
            {
                char c = characters[i]; 
                char letter = Char.ToLower(characters[i]); 
                if (char.IsLetter(letter))
                {
                    letter = (char)(letter - shift);
                    if (letter > 'z') 
                    {
                        letter = (char)(letter - 26);
                    }
                    else if (letter < 'a') 
                    {
                        letter = (char)(letter + 26);
                    }
                  
                    if (char.IsLower(c))
                        characters[i] = letter; 
                    else
                        characters[i] = Char.ToUpper(letter);
                }
            }
            return new string(characters);
		}
		
		
static void Main()
{
	string text = @"Mu husudjbo iqm, veh jxu vyhij jycu, jxu huikbj ev q iefxyijysqjut hqdiecmqhu qjjqsa, qdt
jxu uvvusji jxqj yj xqt ed jxu Dqjyedqb Xuqbjx Iuhlysu, ydsbktydw qcrkbqdsui ruydw jkhdut
qmqo qdt fqjyudji xqlydw jxuyh efuhqjyedi sqdsubbut mxybij fhufqhydw je we yd je
jxuqjhu. Jxu MqddqSho lyhki, qi yj rusqcu ademd, xqt vekdt q auo lkbduhqrybyjo, qdt yj
xqt q tulqijqjydw ycfqsj qi edu xeifyjqb qvjuh qdejxuh hufehjut jxqj yj xqt ruud qvvusjut;
duqhbo vyvjo yd jejqb. Yd jxu yccutyqju qvjuhcqjx, unfuhji qdt ydiytuhi qbyau mudj ed je
dumi ekjbuji qdt ed je iesyqb cutyq, myjx jxuyh unfbqdqjyedi eh xem jxyi sekbt xqlu
xqffudut. Mxqj yi sbuqh yi jxqj iecujxydw duutut je ru tedu je udikhu jxqj iksx qd qjjqsa
mybb duluh xqlu jxu iqcu ycfqsj ed jxu Dqjyedqb Xuqb Iuhlysu yd jxu vkjkhu.";

	var characterCount = new Dictionary<char, int>();
            foreach (char c in text)
            {
                if (characterCount.ContainsKey(c))
                    characterCount[c]++;
                else
                    characterCount[c] = 1;
            }

          
            var items = from pair in characterCount
                        orderby pair.Value ascending
                        select pair;

            foreach (KeyValuePair<char, int> pair in characterCount.OrderByDescending(i => i.Value))
            {
                int shift = 0;
                char c = pair.Key;

                if (char.IsLetter(c))
                {
                    Console.WriteLine("{0} - {1}", pair.Key, pair.Value); 

                  
                    while (c != 'e')
                    {
                        c--;
                        shift++;
                        if (c > 'z')
                        {
                            c = (char)(c - 26);
                        }
                        else if (c < 'a') 
                        {
                            c = (char)(c + 26);
                        }
                    }
                    if (c == 'e')
                    {
                        Console.WriteLine("Shift is {0}", shift); 
                        string decrypted = Decrypt(text, shift);  
                        Console.WriteLine(decrypted);             
                    }

                    
                    Console.WriteLine("Is this correct? (Y/N)");
                    char next = char.Parse(Console.ReadLine().ToLower());
                    if (next == 'y')
                        break;
                    else
                        continue;

                }
            }


        }


    }
}