using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using Microsoft.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebApiProduccion.Data.Interfaces;
using WebApiProduccion.Entities;
using WebApiProduccion.Data.Data;
using System.Net;

namespace WebApiProduccion.Data.Repositories
{
    public class BooksRepository : IBooksrepository
    {
        public BooksRepository() 
        { 
        }

        async Task<List<Book>> IBooksrepository.GetAllBooks()
        {

            Conexion bd = new Conexion();
            List<Book> books = new List<Book>();
            SqlConnection conn = new SqlConnection(bd.ConexionString());
            try
            {
                SqlCommand cmd = new SqlCommand("GetAllBooks", conn);
                cmd.CommandType = CommandType.StoredProcedure;

                await conn.OpenAsync();
                SqlDataReader dr = null;
                dr = cmd.ExecuteReader();
                if (dr.HasRows)
                {
                    while (dr.Read())
                    {
                        books.Add(new Book
                        {
                            Id = int.Parse(dr["Id_Book"].ToString()),
                            Title = dr["Name_Book"].ToString(),
                            Description = dr["Book_Summary"].ToString(),
                            Author = dr["Name_Author"].ToString(),
                            Genre = dr["Name_Genre"].ToString(),
                            Date = dr["Book_Creation_Date"].ToString()
                        });
                    }
                    dr.Close();
                    return books;
                }
                else
                {
                    return books;
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

        async Task<Book> IBooksrepository.GetBookById(int Id)
        {

            Conexion bd = new Conexion();
            Book book = new Book();
            SqlConnection conn = new SqlConnection(bd.ConexionString());
            try
            {
                SqlCommand cmd = new SqlCommand("GetBookById", conn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@Id_Book", Id);

                await conn.OpenAsync();
                SqlDataReader dr = null;
                dr = cmd.ExecuteReader();
                if (dr.HasRows)
                {
                    while (dr.Read())
                    {
                        book.Id = int.Parse(dr["Id_Book"].ToString());
                        book.Title = dr["Name_Book"].ToString();
                        book.Description = dr["Book_Summary"].ToString();
                        book.Author = dr["Name_Author"].ToString();
                        book.Genre = dr["Name_Genre"].ToString();
                        book.Date = dr["Book_Creation_Date"].ToString();
                    }
                    dr.Close();
                    return book;
                }
                else
                {
                    return book;
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


    }
}
