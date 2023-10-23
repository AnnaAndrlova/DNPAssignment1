using System.ComponentModel.DataAnnotations;
using Domain;
using HttpClients.ClientInterfaces;
using Microsoft.AspNetCore.Identity;


namespace BlazorWASM.Services;

public class AuthService: IAuthService
{
    /*private IUserService userService;
    public async Task<User> LoadUsers()
    {
    IEnumerable<User> users = await userService.GetUsers();

    return users;
    }
*/
    

    private readonly  IList<User> users = new List<User>
    {
        new User
        {
            UserName = "Anna",
            Password = "anna",
           
        },
        
        
    };
    //TODO add users 
   /* private static IUserService userService;
    
    private Task<IEnumerable<User>> userss = userService.GetUsers();
    private List<User> users;*/
    
    
    

    public Task<User> ValidateUser(string username, string password)
    {
        User? existingUser = users.FirstOrDefault(u => 
            u.UserName.Equals(username, StringComparison.OrdinalIgnoreCase));
        
        if (existingUser == null)
        {
            throw new Exception("User not found");
        }

        if (!existingUser.Password.Equals(password))
        {
            throw new Exception("Password mismatch");
        }

        return Task.FromResult(existingUser);
    }

    public Task RegisterUser(User user)
    {

        if (string.IsNullOrEmpty(user.UserName))
        {
            throw new ValidationException("Username cannot be null");
        }

        if (string.IsNullOrEmpty(user.Password))
        {
            throw new ValidationException("Password cannot be null");
        }
        // Do more user info validation here
        
        // save to persistence instead of list
        
        //users.Add(user);
        
        return Task.CompletedTask;
    }
}