using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace BazaDateDecodare
{
    class Program
    {
        static void Main(string[] args)
        {
            
            string filePath = @"C:\Hash\hashToDecode.txt";
            string numeFilePath = @"C:\Hash\numeHash.txt";
            string hashFilePath = @"C:\Hash\hashParole.txt";
            string hashNedecFilePath = @"C:\Hash\hashNedecodat.txt";
            string hashCombinat = @"C:\Hash\hashCombinat.txt";
            arataMeniu();
            verificaNumar(filePath,numeFilePath,hashFilePath,hashNedecFilePath,hashCombinat);
            Console.ReadLine();
        }
        public static void arataMeniu()
        {
            Console.WriteLine("-----------Simple Hash Sorter-----------");
            Console.WriteLine("------------Made by Stellrow------------");
        }
        public static void scrieHashNedecodat(String filePath,String fileFinal)
        {
            int dupeCount = 0;
            List<String> hashNedecodat = new List<String>();
            List<string> linesHashToDecode = File.ReadLines(filePath).ToList();
            foreach (var line in linesHashToDecode)
            {
                string[] entry = line.Split(',');
                if (hashNedecodat.Contains(entry[2].Replace((char)39, ' ').Replace('*', ' ').Trim(' ')))
                {
                    hashNedecodat.Add("Dublura" + dupeCount);
                    dupeCount++;
                }
                else {
                hashNedecodat.Add((entry[2].Replace((char)39, ' ').Replace('*', ' ').Trim(' ')));
            }
            }
            File.WriteAllLines(fileFinal, hashNedecodat);

        }
        public static void scrieNumeHash(String filePath,String fileFinal)
        {
            List<String> numeHash = new List<String>();
            List<String> numeHashDeOrdonat = File.ReadLines(filePath).ToList();
            foreach (var line in numeHashDeOrdonat)
            {
                string[] entry = line.Split(',');
                numeHash.Add(entry[1]);
            }
            File.WriteAllLines(fileFinal, numeHash);
        }
        public static void combinaHash(String pathNume,String pathParola,String pathFinal)
        {
            List<String> numeHash = File.ReadLines(pathNume).ToList();
            List<String> paroleHash = File.ReadLines(pathParola).ToList();
            List<String> liniCombinate = new List<String>();
            if(paroleHash.Count <= 0)
            {
                return;
            }
            int length = paroleHash.Count - 1;
            for(int i = 0;i<= length; i++)
            {
                string paroleLine = paroleHash[i];
                string[] paroleDespartita = paroleLine.Split(' ');
                liniCombinate.Add("Nume : " + numeHash[i] + "," + " Parola : " + paroleDespartita.Last());
            }
            File.WriteAllLines(pathFinal, liniCombinate);
        }
        public static void verificaNumar(String pathHash,String numeHashPath,String parolaHashPath,String hashNedecodatPath,String hashCombinatPath)
        {
                scrieHashNedecodat(pathHash, hashNedecodatPath);
                scrieNumeHash(pathHash, numeHashPath);
                combinaHash(numeHashPath, parolaHashPath, hashCombinatPath);
        }
    }
}
