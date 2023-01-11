namespace Contact.Models
{
    public class Repo
    {
        private static List<ContactRes> contacts = new List<ContactRes>();
        public static IEnumerable<ContactRes> Contacts => contacts;
        public static void AddContact(ContactRes contact)
        {
            contacts.Add(contact);
        }
    }
}
