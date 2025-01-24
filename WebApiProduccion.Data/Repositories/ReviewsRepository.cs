using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebApiProduccion.Data.Data;
using WebApiProduccion.Data.Interfaces;
using WebApiProduccion.Entities;
using WebApiProduccion.Entities.Models;
using static System.Reflection.Metadata.BlobBuilder;

namespace WebApiProduccion.Data.Repositories
{
    public class ReviewsRepository : IReviewsRepository
    {
        public 
            ReviewsRepository()
        {
        }

        async Task<List<Review>> IReviewsRepository.GetAllReviewsByBook(int id)
        {
            List<Review> listreview = new List<Review>();
            Conexion bd = new Conexion();
            SqlConnection conn = new SqlConnection(bd.ConexionString());
            try
            {
                SqlCommand cmd = new SqlCommand("GetAllReviewByBook", conn);
                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Parameters.AddWithValue("@Id_Book", id);

                await conn.OpenAsync();
                SqlDataReader dr = null;
                dr = cmd.ExecuteReader();
                if (dr.HasRows)
                {
                    while (dr.Read())
                    {
                        listreview.Add(new Review
                        {
                            Id = int.Parse(dr["Id_Review"].ToString()),
                            Title = dr["Name_Review"].ToString(),
                            Description = dr["Review"].ToString(),
                            Rating = int.Parse(dr["Rating"].ToString()),
                            Name_User = dr["Name_User"].ToString(),
                            Title_Book = dr["Name_Book"].ToString(),
                            Date = dr["Review_Creation_Date"].ToString()
                        });
                    }
                    dr.Close();
                    return listreview;
                }
                else
                {
                    return listreview;
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

        async Task<List<Review>> IReviewsRepository.GetAllReviewsByUser(int id)
        {
            List<Review> listreview = new List<Review>();
            Conexion bd = new Conexion();
            SqlConnection conn = new SqlConnection(bd.ConexionString());
            try
            {
                SqlCommand cmd = new SqlCommand("GetReviewsByIdUser", conn);
                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Parameters.AddWithValue("@Id_User", id);

                await conn.OpenAsync();
                SqlDataReader dr = null;
                dr = cmd.ExecuteReader();
                if (dr.HasRows)
                {
                    while (dr.Read())
                    {
                        listreview.Add(new Review
                        {
                            Id = int.Parse(dr["Id_Review"].ToString()),
                            Title = dr["Name_Review"].ToString(),
                            Description = dr["Review"].ToString(),
                            Rating = int.Parse(dr["Rating"].ToString()),
                            Name_User = dr["Name_User"].ToString(),
                            Title_Book = dr["Name_Book"].ToString(),
                            Date = dr["Review_Creation_Date"].ToString()
                        });
                    }
                    dr.Close();
                    return listreview;
                }
                else
                {
                    return listreview;
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

        async Task<bool> IReviewsRepository.AddReview(AddReview review)
        {
            bool result = false;
            Conexion bd = new Conexion();
            SqlConnection conn = new SqlConnection(bd.ConexionString());
            try
            {
                SqlCommand cmd = new SqlCommand("AddReview", conn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@Id_Book", review.Id_Book);
                cmd.Parameters.AddWithValue("@Id_User", review.Id_User);
                cmd.Parameters.AddWithValue("@Name_Review", review.Title);
                cmd.Parameters.AddWithValue("@Review", review.Description);
                cmd.Parameters.AddWithValue("@Rating", review.Rating);

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

        async Task<string> IReviewsRepository.UpdateReview(AddReview review)
        {
            string result = string.Empty;
            Conexion bd = new Conexion();
            SqlConnection conn = new SqlConnection(bd.ConexionString());
            try
            {
                SqlCommand cmd = new SqlCommand("EditReviewById", conn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@Id_Review", review.Id);
                cmd.Parameters.AddWithValue("@Name_Review", review.Title);
                cmd.Parameters.AddWithValue("@Review", review.Description);
                cmd.Parameters.AddWithValue("@Rating", review.Rating);

                await conn.OpenAsync();
                result = cmd.ExecuteScalar().ToString();

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

        async Task<string> IReviewsRepository.DeleteReview(int id)
        {
            string result = string.Empty;
            Conexion bd = new Conexion();
            SqlConnection conn = new SqlConnection(bd.ConexionString());
            try
            {
                SqlCommand cmd = new SqlCommand("DeleteReview", conn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@Id_Review", id);

                await conn.OpenAsync();
                result = cmd.ExecuteScalar().ToString();

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
