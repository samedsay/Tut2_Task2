using System;
using System.Collections.Generic;
using System.IO;
using System.Xml.Serialization;
using Tutorial2.Models;

namespace Tutorial2
{
    public class Program
    {
        static void Main(string[] args)
        {
         
            FileInfo log;

            var path = "";
            
            var list = new HashSet<Student>(new CustomComparer());
            try
            {
                using var s = new StreamWriter(@"log.txt");
                path = @"NewFolder\data.csv";
                var fi = new FileInfo(path);
                
               
                using (var stream = new StreamReader(fi.OpenRead()))
                {
                    string line = null;
                    while ((line = stream.ReadLine()) != null)
                    {
                        String[] ar = line.Split(",");
                       
                        var checker = true;
                        foreach (String e in ar)
                        {
                            if (e=="")
                            {
                                checker = false;
                            }
                        }
                        if (checker == false)
                        {
                            s.WriteLine(line);
                        }
                        else
                        {
                            var student = new Student
                            {
                                Name = ar[0],
                                Surname = ar[1],
                                FieldOfStudy = ar[2],
                                LearningStyle = ar[3],
                                StudentNumber = ar[4].ToString(),
                                EnrolmentDate = DateTime.Parse(ar[5]),
                                Email = ar[6],
                                MotherName = ar[7],
                                FatherName = ar[8],

                            };
                            if (list.Contains(student))
                            { 
                                s.WriteLine(line);

                            }
                            else 
                            {
                                list.Add(student);
                            }
                          
                        }
                        
                        Console.WriteLine(line);

                    }

                }
            }
            catch (DirectoryNotFoundException)
            {
                using var s = new StreamWriter(@"log.txt");
                s.WriteLine("Not Found");
            }
            catch (ArgumentException)
            {
                using var s = new StreamWriter(@"log.txt");
                s.WriteLine("Not found");

            }
            FileStream writer = new FileStream(@"result.xml", FileMode.Create);

             //Changed later, to adapt the code for HashSet
            XmlSerializer serializer = new XmlSerializer(typeof(HashSet<Student>),
                     new XmlRootAttribute("University"));

            // Using XmlSerializer to write in xml format.Moreover, RootAttribute has created in the name of university.
            serializer.Serialize(writer, list);

        }
    }
}
