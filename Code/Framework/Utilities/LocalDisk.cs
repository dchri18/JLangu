using System;
using System.Collections.Generic;
using System.Text;
using System.IO;
using Framework.Core;
using Newtonsoft.Json;
using static Framework.Utilities.Encryption;

namespace Framework.Utilities
{
    public static class LocalDisk
    {
        public static void WriteAllKanji(List<Kanji> kanjis)
        {
            try
            {
                StreamWriter writer = new StreamWriter("kanji.dat");
                foreach (Kanji kanji in kanjis)
                {
                    string serialised = JsonConvert.SerializeObject(kanji);
                    byte[] encrypted = EncryptString(serialised);
                    writer.WriteLine(encrypted);
                }
                writer.Close();
            } 
            catch (Exception e)
            {
                // Do something :)
            }
        }

        public static List<Kanji> ReadAllKanji()
        {
            List<Kanji> kanjis = new List<Kanji>();
            try
            {              
                StreamReader reader = new StreamReader("kanji.dat");
                while (!reader.EndOfStream)
                {
                    string ciphertext = reader.ReadLine();
                    string json = DecryptString(Encoding.ASCII.GetBytes(ciphertext));
                    kanjis.Add(JsonConvert.DeserializeObject<Kanji>(json));
                }               
            }
            catch (Exception e)
            {
                // Do something :)
            }
            return kanjis;
        }

        public static void WriteAllVocabulary(List<Vocabulary> vocab)
        {
            try
            {
                StreamWriter writer = new StreamWriter("vocab.dat");
                foreach (Vocabulary voc in vocab)
                {
                    string serialised = JsonConvert.SerializeObject(voc);
                    byte[] encrypted = EncryptString(serialised);
                    writer.WriteLine(encrypted);
                }
                writer.Close();
            }
            catch (Exception e)
            {
                // Do something :)
            }
        }

        public static List<Vocabulary> ReadAllVocabulary()
        {
            List<Vocabulary> vocab = new List<Vocabulary>();
            try
            {
                StreamReader reader = new StreamReader("vocab.dat");
                while (!reader.EndOfStream)
                {
                    string ciphertext = reader.ReadLine();
                    string json = DecryptString(Encoding.ASCII.GetBytes(ciphertext));
                    vocab.Add(JsonConvert.DeserializeObject<Vocabulary>(json));
                }
            }
            catch (Exception e)
            {
                // Do something :)
            }
            return vocab;
        }

        public static void WriteAllGrades(List<Grade> grades)
        {
            try
            {
                StreamWriter writer = new StreamWriter("grades.dat");
                foreach (Grade grade in grades)
                {
                    string serialised = JsonConvert.SerializeObject(grade);
                    byte[] encrypted = EncryptString(serialised);
                    writer.WriteLine(encrypted);
                }
                writer.Close();
            }
            catch (Exception e)
            {
                // Do something :)
            }
        }

        public static List<Grade> ReadAllGrades()
        {
            List<Grade> grades = new List<Grade>();
            try
            {
                StreamReader reader = new StreamReader("grade.dat");
                while (!reader.EndOfStream)
                {
                    string ciphertext = reader.ReadLine();
                    string json = DecryptString(Encoding.ASCII.GetBytes(ciphertext));
                    grades.Add(JsonConvert.DeserializeObject<Grade>(json));
                }
            }
            catch (Exception e)
            {
                // Do something :)
            }
            return grades;
        }

        public static void WriteAllNotes(List<Notes> notes)
        {
            try
            {
                StreamWriter writer = new StreamWriter("notes.dat");
                foreach (Notes note in notes)
                {
                    string serialised = JsonConvert.SerializeObject(note);
                    byte[] encrypted = EncryptString(serialised);
                    writer.WriteLine(encrypted);
                }
                writer.Close();
            }
            catch (Exception e)
            {
                // Do something :)
            }
        }

        public static List<Notes> ReadAllNotes()
        {
            List<Notes> notes = new List<Notes>();
            try
            {
                StreamReader reader = new StreamReader("notes.dat");
                while (!reader.EndOfStream)
                {
                    string ciphertext = reader.ReadLine();
                    string json = DecryptString(Encoding.ASCII.GetBytes(ciphertext));
                    notes.Add(JsonConvert.DeserializeObject<Notes>(json));
                }
            }
            catch (Exception e)
            {
                // Do something :)
            }
            return notes;
        }

        public static void WriteUserData(List<object> paras)
        {
            Dictionary<string, object> parameters = new Dictionary<string, object>();
            parameters.Add("Level", paras[0]);

            try
            {
                string serialised = JsonConvert.SerializeObject(parameters);
                byte[] encrypted = EncryptString(serialised);
                StreamWriter writer = new StreamWriter("user.dat");
                writer.WriteLine(encrypted);
                writer.Close();
            }
            catch (Exception e)
            {
                // Do something please.
            }
        }

        public static Dictionary<string, object> LoadUserData()
        {
            try
            {
                StreamReader reader = new StreamReader("user.dat");
                string encrypted = reader.ReadToEnd();
                string json = DecryptString(Encoding.ASCII.GetBytes(encrypted));
                return JsonConvert.DeserializeObject<Dictionary<string, object>>(json);
            }
            catch (Exception e)
            {
                // Can you do something here later on? Thanks.
            }
            return new Dictionary<string, object>();
        }
    }
}
