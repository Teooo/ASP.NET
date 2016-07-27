using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net.Http;
using System.Net.Http.Headers;
using Battleships.WebServices;
using Battleships.Data;
using Microsoft.AspNet.Identity;
using System.Web;


namespace BatleShip.ConsoleClient
{
    public class Program
    {


        static void Main(string[] args)
        {
            HttpClient httpclient = new HttpClient();
            //string emailPlayerOne = "motikarq@abv.bg";
            //string passPlayerOne = "1234567";
            string playerTwo = "pesho@abv.bg";
            string passwordPlTwo = "123456";
            //register(playerTwo, passwordPlTwo,httpclient);
            //CreateGame(emailPlayerOne, passPlayerOne,httpclient);

            Guid gameId =  new Guid("F4B1C82B-7B2A-4FDF-8F8E-644B0CE948F7");
            
            JoinGame(gameId, playerTwo, passwordPlTwo);
            
           
            
             
        }
        // register
        public static void register(string email, string pass, HttpClient client)
        {
            var content = new FormUrlEncodedContent(new[]
                {
                    new KeyValuePair<string, string>("email", email),
                    new KeyValuePair<string, string>("password", pass),
                    new KeyValuePair<string, string>("confirmPassword", pass)   
                });
            var response = client.PostAsync("http://localhost:62858/api/Account/Register", content).Result;
            if (!response.IsSuccessStatusCode)
            {
                throw new HttpRequestException("Unsucsesfull registration. Try again");
            }
            else
            {
                Console.WriteLine("{0}. Succsesfull registration", response.StatusCode);
            }


        }
        //Login
        private  static LoginDTO Login(string email, string pass)
        {
            var httpClient = new HttpClient();
            using (httpClient)
            {
                var content = new FormUrlEncodedContent(new[]
                {
                    new KeyValuePair<string, string>("username", email),
                    new KeyValuePair<string, string>("password", pass),
                    new KeyValuePair<string, string>("grant_type", "password")   
                });

                var response = httpClient.PostAsync("http://localhost:62858/Token", content).Result;

                if (!response.IsSuccessStatusCode)
                {
                    // Nothing to return, throw a proper exception + message
                    throw new HttpRequestException(
                        response.Content.ReadAsStringAsync().Result);
                }

                return response.Content.ReadAsAsync<LoginDTO>().Result;
            }
            
            
        }
        //Create Empty Game
        public static void CreateGame(string email, string pass)
        {
            var httpClient = new HttpClient();
            using(httpClient)
                {
                    
                    
                    var loginDetails = Login(email, pass);
                    httpClient.DefaultRequestHeaders.Add("Authorization", "Bearer " + loginDetails.Access_Token);
                    var response = httpClient.PostAsync("http://localhost:62858/api/Games/create", new StringContent("")).Result;


                }
        }
        //Join Game
        public static void JoinGame(Guid gameId, string pl2Username,string pass)
        {
            var httpClient = new HttpClient();
            using (httpClient)
            {
                var loginDetails = Login(pl2Username, pass);
                httpClient.DefaultRequestHeaders.Add("Authorization", "Bearer " + loginDetails.Access_Token);
                var content = new FormUrlEncodedContent(new[]
                {
                    new KeyValuePair<string, string>("gameid", gameId.ToString())
                     
                });
                var response = httpClient.PostAsync("http://localhost:62858/api/Games/join", content).Result;

            }

        }
    }
}
