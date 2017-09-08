using System.Collections.Generic;

namespace StudentCard.Forms
{
    public class DictionaryForRefreshDataTables
    {
        public static string GetContactTypeEnumToString(ContactType contactType)
        {
            var contactTypes = new Dictionary<ContactType, string>
            {
                {ContactType.HomeNumberPhone, "Номер домашнего телефона"},
                {ContactType.MobileNumberPhone, "Номер мобильного телефона"},
                {ContactType.Email, "Адрес электронной почты"}
            };

            string contactValue;

            contactTypes.TryGetValue(contactType, out contactValue);

            return contactValue;
        }

        public static ContactType GetContactTypeByValueContactTypeCombobox(string selectedValue)
        {
            var contactTypes = new Dictionary<string, ContactType>
            {
                {"Номер домашнего телефона", ContactType.HomeNumberPhone},
                {"Номер мобильного телефона", ContactType.MobileNumberPhone},
                {"Адрес электронной почты", ContactType.Email}
            };

            ContactType contactType;

            contactTypes.TryGetValue(selectedValue, out contactType);

            return contactType;

        }

        public static AdressType GetAdressTypeByValueAdressTypeComboBox(string selectedValue)
        {
            var adressTypes = new Dictionary<string, AdressType>
            {
                {"Адрес по прописке", AdressType.RegistrationAddress},
                {"Адрес фактический", AdressType.ActualAdress}
            };


            AdressType adressType;

            adressTypes.TryGetValue(selectedValue, out adressType);

            return adressType;
        }

        public static string GetAdressTypeEnumToString(AdressType adressTypeEnum)
        {
            var adressTypesString = new Dictionary<AdressType, string>
            {
                {AdressType.ActualAdress, "Адрес фактический"},
                {AdressType.RegistrationAddress, "Адрес по прописке"}
            };


            string selectedValue;

            adressTypesString.TryGetValue(adressTypeEnum, out selectedValue);

            return selectedValue;
        }

    }
}