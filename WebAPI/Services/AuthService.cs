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
   private IUserService userService;
   
    

    /*public AuthService(IUserService userService)
    {
        this.userService = userService;
        
    }

    private async Task<IEnumerable<User>> getUsers()
    {
        IEnumerable < User > users = await userService.GetUsers();
        return users;
    }*/
    

    /*public async Task<User> ValidateUser(string username, string password)
    {
        User? existingUser =  (await getUsers()).FirstOrDefault(u => 
            u.UserName.Equals(username, StringComparison.OrdinalIgnoreCase));
        
        if (existingUser == null)
        {
            throw new Exception("User not found");
        }

        if (!existingUser.Password.Equals(password))
        {
            throw new Exception("Password mismatch");
        }

        return existingUser;
    }*/
    public async Task<User> ValidateUser(string username, string password)
    {
        User? existingUser =  users.FirstOrDefault(u => 
            u.UserName.Equals(username, StringComparison.OrdinalIgnoreCase));
        
        if (existingUser == null)
        {
            throw new Exception("User not found");
        }

        if (!existingUser.Password.Equals(password))
        {
            throw new Exception("Password mismatch");
        }

        return existingUser;
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