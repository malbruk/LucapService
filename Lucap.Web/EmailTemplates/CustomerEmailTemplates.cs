namespace Lucap.Web.EmailTemplates
{
    public static class CustomerEmailTemplates
    {
        public static string CreateNewCustomerMessage(string customerName)
        {
            return @$"<h3>הי, {customerName} 🖐</h3> 
                    <p>תודה שהצטרפת אלינו 🤗</p>
                    <p>להתראות!</p>";

        }
    }
}
