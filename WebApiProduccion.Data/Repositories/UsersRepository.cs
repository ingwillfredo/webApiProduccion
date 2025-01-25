using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using WebApiProduccion.Data.Data;
using WebApiProduccion.Data.Interfaces;
using WebApiProduccion.Entities;
using WebApiProduccion.Entities.Models;
using static System.Reflection.Metadata.BlobBuilder;

namespace WebApiProduccion.Data.Repositories
{
    public class UsersRepository : IUsersRepository
    {
        private readonly PasswordEncryptor _util;
        public UsersRepository(PasswordEncryptor util) 
        {
            _util = util;
        }

        async Task<string> IUsersRepository.AddUser(AddUser user)
        {
            string messageResult = string.Empty;
            Conexion bd = new Conexion();
            SqlConnection conn = new SqlConnection(bd.ConexionString());
            try
            {
                //Encripto el password
                PasswordEncryptor encrypt = new PasswordEncryptor();
                user.Password = encrypt.EncryptPassword(user.Password);

                SqlCommand cmd = new SqlCommand("AddUser", conn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@Name_User", user.Name);
                cmd.Parameters.AddWithValue("@Email_User", user.Email);
                cmd.Parameters.AddWithValue("@Password_UserLogin", user.Password);

                await conn.OpenAsync();
                messageResult = cmd.ExecuteScalar().ToString();

                return messageResult;
            }
            catch (Exception ex)
            {
                throw new Exception("Error: " + ex);
            }
            finally
            {
                conn.Close();
                conn.Dispose();
            }
        }



        async Task<LoginUser> IUsersRepository.LoginUser(Login user)
        {
            string messageResult = string.Empty;
            LoginUser loginUser = new LoginUser();
            Conexion bd = new Conexion();
            SqlConnection conn = new SqlConnection(bd.ConexionString());
            try
            {
                SqlCommand cmd = new SqlCommand("ValidateLogin", conn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@Email_User", user.Email);

                await conn.OpenAsync();
                SqlDataReader dr = null;
                dr = cmd.ExecuteReader();
                if (dr.HasRows)
                {
                    while (dr.Read())
                    {
                        loginUser.Id = Convert.ToInt32(dr["Id_User"]);
                        loginUser.Name = dr["Name_User"].ToString();
                        loginUser.Email = dr["Email_User"].ToString();
                        loginUser.Password = dr["Password_UserLogin"].ToString();
                    }
                    dr.Close();

                    //Valido Password
                    PasswordEncryptor encrypt = new PasswordEncryptor();

                    bool isMatch = encrypt.VerifyPassword(user.Password, loginUser.Password);

                    if (isMatch)
                    {
                        loginUser.Token = _util.generateJWT(loginUser);
                        return loginUser;
                    }
                    else
                    {
                        return loginUser;
                    }
                }
                else
                {
                    return loginUser;
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Error: " + ex);
            }
            finally
            {
                conn.Close();
                conn.Dispose();
            }
        }



        async Task<bool> IUsersRepository.ValidateEmail(string email)
        {
            bool result = false;
            LoginUser loginUser = new LoginUser();
            Conexion bd = new Conexion();
            SqlConnection conn = new SqlConnection(bd.ConexionString());
            try
            {
                SqlCommand cmd = new SqlCommand("ValidateEmail", conn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@Email_User", email);

                await conn.OpenAsync();
                result = (bool)cmd.ExecuteScalar();
                return result;
            }
            catch (Exception ex)
            {
                throw new Exception("Error: " + ex);
            }
            finally
            {
                conn.Close();
                conn.Dispose();
            }
        }
    }
}
