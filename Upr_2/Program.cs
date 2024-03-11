using Newtonsoft.Json;
using System.Text.RegularExpressions;
using System.Xml.Linq;
using System.Xml.Serialization;

namespace Upr_2
{
    public class Program
    {
        static void Main(string[] args)
        {
            /*
             * TASK 1
            string filePath = "input-01.txt";
            List<Coordinates> coordinates = ReadCoordinatesFromFile(filePath);

            string jsonCoordinates = JsonConvert.SerializeObject(coordinates);
            //string jsonCoordinates = ConvertCoordinatesListToJson(coordinates);

            try
            {
                //File.WriteAllText(Path.Combine(Environment.CurrentDirectory, "coordinates.json"), jsonCoordinates);
                File.WriteAllText("coordinates.json", jsonCoordinates);
                Console.WriteLine("Coordinates saved to coordinates.json.");
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error saving coordinates: " + ex.Message);
            }
            */

            /*Dictionary<string, string> contacts = ReadContactsFromFile("input-02.txt");
            WriteContactsToXml(contacts, "contacts.xml");
            Console.WriteLine("Contacts saved to contacts.xml.");
            */

            /*Contacts[] contacts = ReadContactsFromFile("input-02.txt");
            foreach (var contact in contacts)
            {
                Console.WriteLine($"Name: {contact.Name}, ID: {contact.Id}, Phone Number: {contact.PhoneNumber}");
            }*/

            List<Contacts> contacts = SplitSolution();
            XmlSerializer x = new XmlSerializer(typeof(List<Contacts>));
            TextWriter writer = new StreamWriter("contactsFormated.xml");
            x.Serialize(writer, contacts);
        }

        public struct Coordinates
        {
            public float lat;
            public float lng;
        }

        public struct Contacts
        {
            public string Name;
            public int Id;
            public string PhoneNumber;
        }

        public static List<Coordinates> ReadCoordinatesFromFile(string filePath)
        {
            List<Coordinates> coordinatesList = new List<Coordinates>();
            string[] lines = File.ReadAllLines(filePath);
            foreach (string line in lines)
            {
                string[] coordPairs = line.Split(';');
                foreach (string pair in coordPairs)
                {
                    string[] coords = pair.Split(',');
                    if (coords.Length == 2)
                    {
                        Coordinates coordinates;
                        if (float.TryParse(coords[0], out coordinates.lat) &&
                            float.TryParse(coords[1], out coordinates.lng))
                        {
                            coordinatesList.Add(coordinates);
                        }
                    }
                }
            }

            return coordinatesList;
        }

        static string ConvertCoordinatesListToJson(List<Coordinates> coordinatesList)
        {
            List<object> jsonList = new List<object>();

            foreach (var coords in coordinatesList)
            {
                jsonList.Add(new { lat = coords.lat, lng = coords.lng });
            }

            return JsonConvert.SerializeObject(jsonList);
        }
        /*
        public static Dictionary<string, string> ReadContactsFromFile(string filePath)
        {
            Dictionary<string, string> contacts = new Dictionary<string, string>();
            string[] lines = File.ReadAllLines(filePath);

            string name = "";
            string id = "";
            string phoneNumber = "";

            foreach (string line in lines)
            {
                string[] tokens = line.Split(new char[] { ' ', '\t' }, StringSplitOptions.RemoveEmptyEntries);

                foreach (string token in tokens)
                {
                    if (Regex.IsMatch(token, @"^\d{6}$"))
                    {
                        id = token;
                    }
                    else if (Regex.IsMatch(token, @"^\+395\d{3}\s\d{2}\s\d{2}$"))
                    {
                        phoneNumber = token.Replace("+395", "").Replace(" ", "");
                    }
                    else
                    {
                        name = token;
                    }

                    if (!string.IsNullOrWhiteSpace(name) && !string.IsNullOrWhiteSpace(id) && !string.IsNullOrWhiteSpace(phoneNumber))
                    {
                        contacts.Add(name, phoneNumber);
                        name = "";
                        id = "";
                        phoneNumber = "";
                    }
                }
            }

            return contacts;
        }
        */
        /*
        public static void WriteContactsToXml(Dictionary<string, string> contacts, string filePath)
        {
            XElement root = new XElement("Contacts");

            foreach (var contact in contacts)
            {
                XElement contactElement = new XElement("Contact",
                    new XElement("Name", contact.Key),
                    new XElement("PhoneNumber", contact.Value));
                root.Add(contactElement);
            }

            XDocument xmlDoc = new XDocument(root);
            xmlDoc.Save(filePath);
        }
        */
        /*
        public static Contacts[] ReadContactsFromFile(string filePath)
        {
            List<Contacts> contactsList = new List<Contacts>();

            try
            {
                string[] lines = File.ReadAllLines(filePath);

                string currentName = "";
                string currentId = "";
                string currentPhoneNumber = "";

                foreach (string line in lines)
                {
                    string[] tokens = line.Split('\t', StringSplitOptions.RemoveEmptyEntries);

                    foreach (string token in tokens)
                    {
                        if (Regex.IsMatch(token, @"^\d{6}$"))
                        {
                            currentId = token.Trim();
                        }
                        else if (Regex.IsMatch(token, @"^\+395\d{3}\s\d{2}\s\d{2}$"))
                        {
                            currentPhoneNumber = token.Replace("+395", "").Replace(" ", "").Trim();
                        }
                        else if (!string.IsNullOrWhiteSpace(token))
                        {
                            currentName = token.Trim();
                        }
                    }

                    if (!string.IsNullOrWhiteSpace(currentName) && !string.IsNullOrWhiteSpace(currentId) && !string.IsNullOrWhiteSpace(currentPhoneNumber))
                    {
                        Contacts contact = new Contacts
                        {
                            Name = currentName,
                            Id = currentId,
                            PhoneNumber = currentPhoneNumber
                        };
                        contactsList.Add(contact);

                        currentName = "";
                        currentId = "";
                        currentPhoneNumber = "";
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error reading contacts: " + ex.Message);
            }

            return contactsList.ToArray();
        }

        public static void WriteContactsToXml(Contacts[] contacts, string filePath)
        {
            try
            {
                XElement xmlFile = new XElement("Contacts");

                foreach (var contact in contacts)
                {
                    XElement contactElement = new XElement("Contact",
                        new XElement("Name", contact.Name),
                        new XElement("Id", contact.Id),
                        new XElement("PhoneNumber", contact.PhoneNumber));
                    xmlFile.Add(contactElement);
                }

                XDocument xmlDoc = new XDocument(xmlFile);
                xmlDoc.Save(filePath);
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error writing contacts to XML: " + ex.Message);
            }
        }
        */

        public static List<Contacts> SplitSolution()
        {
            string file = File.ReadAllText("input-02.txt");
            List<Contacts> contacts = new List<Contacts>();
            var splittedString = file.Split(new char[0], StringSplitOptions.RemoveEmptyEntries);

            int id = 0;
            string name = null;
            string phone = null;

            for (int i = 0; i < splittedString.Length; i++)
            {
                char firstSymbol = splittedString[i][0];
                if (firstSymbol >= 'А' && firstSymbol <= 'Я')
                {
                    name = splittedString[i];
                }
                else if (firstSymbol == '+')
                {
                    phone = $"{splittedString[i]} {splittedString[i + 1]} {splittedString[i + 2]} {splittedString[i + 3]}";
                    i += 3;
                }
                else
                {
                    id = int.Parse(splittedString[i]);
                }

                if (name != null && id != 0 && phone != null)
                {
                    contacts.Add(new Contacts 
                    {
                        Name = name,
                        Id = id,
                        PhoneNumber = phone
                    });
                    id = 0;
                    name = null;
                    phone = null;
                }
            }
            return contacts;
        }
    }
}