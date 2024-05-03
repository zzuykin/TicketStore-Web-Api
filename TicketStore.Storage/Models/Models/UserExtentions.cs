
namespace TicketStore.Storage.Models.Models;

public  static class UserExtentions
{
    public static string GetFIO(this User user)
    {
        return string.Join(" ",(new string[]
        {
            user.ClientName,
            user.ClientSurname,
            user.ClientLastName
        }).Where(x => !string.IsNullOrEmpty(x)));
    }

    public static string GetEmail(this User user)
    {
        if (user.ClientEmail != string.Empty)
        {
            return user.ClientEmail;
        }
        return string.Empty;
    }

}
