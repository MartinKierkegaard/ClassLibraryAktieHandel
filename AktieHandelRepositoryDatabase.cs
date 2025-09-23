using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using Microsoft.Data.SqlClient;
namespace ClassLibraryAktieHandel
{
    public class AktieHandelRepositoryDatabase : IAktieHandelRepository
    {
   
        private readonly string _connectionString = "Data Source=(localdb)\\MSSQLLocalDB;Initial Catalog=Aktie;Integrated Security=True;Connect Timeout=30;Encrypt=False;Trust Server Certificate=False;Application Intent=ReadWrite;Multi Subnet Failover=False";

        //public AktieHandelRepositoryDatabase(string connectionString)
        //{
        //    _connectionString = connectionString;
        //}

        public AktieHandel AddAktieHandel(AktieHandel aktieHandel)
        {
            using var conn = new SqlConnection(_connectionString);
            using var cmd = new SqlCommand(
                "INSERT INTO AktieHandel (Navn, Antal, HandelsPris) VALUES (@Navn, @Antal, @HandelsPris)", conn);
            cmd.Parameters.AddWithValue("@Navn", aktieHandel.Navn);
            cmd.Parameters.AddWithValue("@Antal", aktieHandel.Antal);
            cmd.Parameters.AddWithValue("@HandelsPris", aktieHandel.HandelsPris);
            conn.Open();
            cmd.ExecuteNonQuery();

            return aktieHandel;
        }

        public AktieHandel? GetById(int handelsId)
        {
            using var conn = new SqlConnection(_connectionString);
            using var cmd = new SqlCommand(
                "SELECT HandelsId, Navn, Antal, HandelsPris FROM AktieHandler WHERE HandelsId = @Id", conn);
            cmd.Parameters.AddWithValue("@Id", handelsId);
            conn.Open();
            using var reader = cmd.ExecuteReader();
            if (reader.Read())
            {
                return new AktieHandel
                {
                    HandelsId = reader.GetInt32(0),
                    Navn = reader.GetString(1),
                    Antal = reader.GetInt32(2),
                    HandelsPris = reader.GetDecimal(3)
                };
            }
            return null;
        }

        public IEnumerable<AktieHandel> GetAll()
        {
            var result = new List<AktieHandel>();
            using var conn = new SqlConnection(_connectionString);
            using var cmd = new SqlCommand("SELECT HandelsId, Navn, Antal, HandelsPris FROM AktieHandler", conn);
            conn.Open();
            using var reader = cmd.ExecuteReader();
            while (reader.Read())
            {
                result.Add(new AktieHandel
                {
                    HandelsId = reader.GetInt32(0),
                    Navn = reader.GetString(1),
                    Antal = reader.GetInt32(2),
                    HandelsPris = reader.GetDecimal(3)
                });
            }
            return result;
        }

        public AktieHandel UpdateAktieHandel(AktieHandel aktiehandel)
        {
            using var conn = new SqlConnection(_connectionString);
            using var cmd = new SqlCommand(
                "UPDATE AktieHandler SET Navn = @Navn, Antal = @Antal, HandelsPris = @HandelsPris WHERE HandelsId = @Id", conn);
            cmd.Parameters.AddWithValue("@Navn", aktiehandel.Navn);
            cmd.Parameters.AddWithValue("@Antal", aktiehandel.Antal);
            cmd.Parameters.AddWithValue("@HandelsPris", aktiehandel.HandelsPris);
            cmd.Parameters.AddWithValue("@Id", aktiehandel.HandelsId);
            conn.Open();
            cmd.ExecuteNonQuery();

            return aktiehandel;
        }

        public AktieHandel? DeleteAktieHandel(int id)
        {
            AktieHandel? delete = new AktieHandel();
            delete = GetById(id);

            using var conn = new SqlConnection(_connectionString);
            using var cmd = new SqlCommand("DELETE FROM AktieHandler WHERE HandelsId = @Id", conn);
            cmd.Parameters.AddWithValue("@Id", id);
            conn.Open();
            cmd.ExecuteNonQuery();

            return delete;
        }
    }



}

