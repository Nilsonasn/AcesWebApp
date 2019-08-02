using Octokit;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services
{
    /// <summary>
    /// Represents the ACES user
    /// </summary>
    public class UserInfo
    {
        /// <summary>
        /// Users GitHub user name
        /// </summary>
        public string UserName;

        /// <summary>
        /// Users GitHub password
        /// Probubly shouldn't be plain text, but we need to transmit it to GitHub
        /// </summary>
        public string Password;

        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="userName">Users GitHub user name</param>
        /// <param name="password">Users Github password</param>
        public UserInfo(string userName, string password)
        {
            this.UserName = userName;
            this.Password = password;
        }

        /// <summary>
        /// Test that the user is logged into GitHub
        /// </summary>
        /// <returns>Ignore return, it is for async</returns>
        async public Task TestLogin()
        {
            GitHubClient client = new GitHubClient(new ProductHeaderValue("ACES"));

            client.Credentials = new Credentials(UserName, Password);
            try
            {
                User userToGet = await client.User.Get(UserName);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
    public static class TestGithubLogin
    {
        static async public Task<bool> TestLogin(string UserName, string Password)
        {
            GitHubClient client = new GitHubClient(new ProductHeaderValue("ACES"));

            client.Credentials = new Credentials(UserName, Password);
            try
            {
                User userToGet = await client.User.Get(UserName);
                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
        }
    }
}
