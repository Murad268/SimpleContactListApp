Console.OutputEncoding = System.Text.Encoding.UTF8;
string[][] contactList = {
    new string[]{"1", "Murad", "Agamedov", "0504194230"},
    new string[]{"2", "Eduard", "Agamedov", "0708535998"},
};
Start:
Console.WriteLine("Siyahıya baxmaq üçün 1, yeni kontakt əlavə etmək üçün 2, kontaktı yeniləmək üçün 3, kontaktı silmək üçün 4, axtarış etmək üçün 5 seçin");
var selectedAction = Console.ReadLine();

if (!int.TryParse(selectedAction, out int action))
{
    Console.WriteLine("yanlış seçim");

    goto Start;
}
else
{
    switch (action)
    {
        case 1:
            Console.Clear();
            Console.WriteLine("Kontakt siyahısı");
            for (int i = 0; i < contactList.Length; i++)
            {
                Console.WriteLine(contactList[i][0]);
                Console.WriteLine($"Ad: {contactList[i][1]}");
                Console.WriteLine($"Soyad: {contactList[i][2]}");
                Console.WriteLine($"Telefon: {contactList[i][3]}");
                Console.WriteLine("===================");
            }

            goto Start;
        case 2:
            Console.Clear();
        Create:
            Console.WriteLine("Yeni kontaktın adı:");
            string name = Convert.ToString(Console.ReadLine());
            Console.WriteLine("Yeni kontaktın soyadı:");
            string surname = Convert.ToString(Console.ReadLine());
            Console.WriteLine("Yeni kontaktın nömrəsi:");
            string number = Convert.ToString(Console.ReadLine());
            string id = (contactList.Length + 1).ToString();
            string[][] newContactListForCreate = new string[contactList.Length + 1][];
            for (int i = 0;i < contactList.Length; i++)
            {
                newContactListForCreate[i] = contactList[i];
            }
            newContactListForCreate[contactList.Length] = new string[] { id, name, surname, number };
            contactList = newContactListForCreate;
            Console.WriteLine($"{name} {surname} adlı kontakt yaradıldı");
          
            goto Start;
        case 3:
            Console.Clear();
        Edit:
            Console.WriteLine("Kontakt siyahısı");
            for (int i = 0; i < contactList.Length; i++)
            {
                Console.WriteLine(contactList[i][0]);
                Console.WriteLine($"Ad: {contactList[i][1]}");
                Console.WriteLine($"Soyad: {contactList[i][2]}");
                Console.WriteLine($"Telefon: {contactList[i][3]}");
                Console.WriteLine("===================");
            }

            Console.WriteLine("Dəyişmək istədiyiniz kontaktın id-sini daxil edin ya da end yazıb əvvələ qayıdın ");
            var selectedIdForEdit = Console.ReadLine();
            if (selectedIdForEdit == "end")
            {
                goto Start;
            } else
            {
                bool check = false;
                int editId = -1;
                string[] willEditedArray = { };
                for (int i = 0; i < contactList.Length; i++)
                {
                    if (contactList[i][0] == selectedIdForEdit)
                    {
                        check = true;
                        editId = i;
                        willEditedArray = contactList[i];
                        break;
                    }
                }
                if (!check)
                {
                    Console.WriteLine("Belə bir ID-yə sahib kontakt yoxdur");
                    goto SelectContactToDelete;
                }

                for (int i = 0; i < willEditedArray.Length - 1; i++)
                {
                    Console.WriteLine($"Kontaktın adı: {willEditedArray[1]} Ya adda dəyişiklik edin, ya entere basaraq davam edin");
                    string newName = Convert.ToString(Console.ReadLine());
                    if(newName == null)
                    {
                        newName = willEditedArray[1];
                    } 
                    Console.WriteLine($"Kontaktın soyadı: {willEditedArray[2]} Ya soyadda dəyişiklik edin, ya entere basaraq davam edin");
                    string newSurname = Convert.ToString(Console.ReadLine());
                    if (newSurname == null)
                    {
                        newSurname = willEditedArray[2];
                    }
                    Console.WriteLine($"Kontaktın nömrəsi: {willEditedArray[3]} Ya nömrədə dəyişiklik edin, ya entere basaraq davam edin");
                    string newNumber = Convert.ToString(Console.ReadLine());
                    if (newNumber == null)
                    {
                        newNumber = willEditedArray[2];
                    }
                    willEditedArray = [willEditedArray[0], newName, newSurname, newNumber];
                    contactList[editId] = willEditedArray;
                    goto Start;
                }
            }
            break;
        case 4:
            Console.Clear();
        SelectContactToDelete:
            Console.WriteLine("Kontakt siyahısı");
            for (int i = 0; i < contactList.Length; i++)
            {
                Console.WriteLine(contactList[i][0]);
                Console.WriteLine($"Ad: {contactList[i][1]}");
                Console.WriteLine($"Soyad: {contactList[i][2]}");
                Console.WriteLine($"Telefon: {contactList[i][3]}");
                Console.WriteLine("===================");
            }

            Console.WriteLine("Silmək istədiyiniz kontaktın id-sini daxil edin ya da end yazıb əvvələ qayıdın ");
            var selectedId = Console.ReadLine();
            if(selectedId == "end")
            {
                goto Start;
            } else
            {
                bool check = false;
                int removeId = -1;
                for (int i = 0;i < contactList.Length;i++)
                {
                    if (contactList[i][0] == selectedId)
                    {
                        check = true;
                        removeId = i;
                        break;
                    }
                }
                if (!check)
                {
                    Console.WriteLine("Belə bir ID-yə sahib kontakt yoxdur");
                    goto SelectContactToDelete;
                }
                string[][] newContactList = new string[contactList.Length - 1][];
                int newIndex = 0;
                string deletedName = null;
                for (int i = 0; i < contactList.Length; i++)
                {
                    if (i != removeId)
                    {
                        newContactList[newIndex] = contactList[i];
                        newIndex++;
                    } else
                    {
                        deletedName = $"{contactList[i][1]} {contactList[i][2]}";
                        Console.WriteLine($"{deletedName} ad, soyadlı kontakt silindi");
                    }
                }
                contactList = newContactList;
            }

            goto Start;

        case 5:
            Console.Clear();
            Console.WriteLine("Axtarış parametrini daxil edin");
            string prm = Console.ReadLine();
            string[] willFindedArray = { };
            foreach (var contact in contactList)
            {
                if (contact[0] == prm || contact[1] == prm || contact[2] == prm) {
                    willFindedArray = contact;
                }
            }

       ;
            bool newCheck = false;
            foreach (var contact in contactList)
            {
                if (contact[0] == prm || contact[1] == prm || contact[2] == prm)
                {
                    willFindedArray = contact;
                    newCheck = true;
                }
            }
            if(!newCheck)
            {
                Console.WriteLine("Uyğun istifadəçi tapılmadı");
     
                goto Start;
            } else
            {
                Console.WriteLine("Tapılmış kontakt");
              
                Console.WriteLine(willFindedArray[0]);
                Console.WriteLine($"Ad: {willFindedArray[1]}");
                Console.WriteLine($"Soyad: {willFindedArray[2]}");
                Console.WriteLine($"Telefon: {willFindedArray[3]}");
              
            }
   
            goto Start;
        default: 
            Console.WriteLine("Yanlış seçim");
            goto Start;
    }



}
Console.ReadLine();