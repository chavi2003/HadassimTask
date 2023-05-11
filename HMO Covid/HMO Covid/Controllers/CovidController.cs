using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;
using HMO_Covid.Models;
using Newtonsoft.Json;

namespace HMO_Covid.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CovidController : ControllerBase
    {
        public readonly IConfiguration _configuration;
        public CovidController(IConfiguration configuration)
        {
            _configuration = configuration;
        }
        [HttpGet]
        [Route("GetAllMembersCovidDetails")]
        public string GetCovidDetails()
        {
            SqlConnection con = new SqlConnection(_configuration.GetConnectionString("MemberAppCon").ToString());
            SqlDataAdapter da = new SqlDataAdapter("SELECT * FROM Covid19", con);
            DataTable dt = new DataTable();
            da.Fill(dt);

            List<Covid> CovidList = new List<Covid>();
            Response response = new Response();
            if (dt.Rows.Count > 0)
            {
                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    Covid covid = new Covid();
                    covid.idMember = Convert.ToString(dt.Rows[i]["idMember"]);
                    covid.firstVaccinationDate = Convert.ToDateTime(dt.Rows[i]["firstVaccinationDate"]);
                    covid.firstVaccinationManufacturer = Convert.ToString(dt.Rows[i]["firstVaccinationManufacturer"]);
                    if (covid.secondVaccinationDate != null)
                    {
                        covid.secondVaccinationDate = Convert.ToDateTime(dt.Rows[i]["secondVaccinationDate"]);
                    }
                    
                    covid.secondVaccinationManufacturer = Convert.ToString(dt.Rows[i]["secondVaccinationManufacturer"]);
                    if (covid.thirdVaccinationDate != null)
                    {
                        covid.thirdVaccinationDate = Convert.ToDateTime(dt.Rows[i]["thirdVaccinationDate"]);
                    }
                    covid.thirdVaccinationManufacturer = Convert.ToString(dt.Rows[i]["thirdVaccinationManufacturer"]);
                    if (covid.fourthVaccinationDate != null)
                    {
                        covid.fourthVaccinationDate = Convert.ToDateTime(dt.Rows[i]["fourthVaccinationDate"]);
                    }
                    covid.fourthVaccinationManufacturer = Convert.ToString(dt.Rows[i]["fourthVaccinationManufacturer"]);
                    if (covid.dateOfGettingPositiveResult != null)
                    {
                        covid.dateOfGettingPositiveResult = Convert.ToDateTime(dt.Rows[i]["dateOfGettingPositiveResult"]);
                    }
                    if (covid.recoveryDate != null)
                    {
                        covid.recoveryDate = Convert.ToDateTime(dt.Rows[i]["recoveryDate"]);
                    }
                    CovidList.Add(covid);
                }

            }
            if (CovidList.Count > 0)
            {
                return JsonConvert.SerializeObject(CovidList);
            }
            else
            {
                response.StatusCode = 100;
                response.ErrorMessage = "no data found";
                return JsonConvert.SerializeObject(response);
            }
        }

        
        [HttpGet]
        [Route("GetMemberById/{id}")]
        public string GetDetailsById(int id)
        {
            SqlConnection con = new SqlConnection(_configuration.GetConnectionString("MemberAppCon").ToString());
            SqlDataAdapter da = new SqlDataAdapter("SELECT * FROM Covid19 WHERE idMember='" + id + "'", con);
            DataTable dt = new DataTable();
            da.Fill(dt);
            Response response = new Response();
            if (dt.Rows.Count > 0)
            {
                Covid covid = new Covid();
                covid.idMember = Convert.ToString(dt.Rows[0]["idMember"]);
                covid.firstVaccinationDate = Convert.ToDateTime(dt.Rows[0]["firstVaccinationDate"]);
                covid.firstVaccinationManufacturer = Convert.ToString(dt.Rows[0]["firstVaccinationManufacturer"]);
                if (covid.secondVaccinationDate != null)
                {
                    covid.secondVaccinationDate = Convert.ToDateTime(dt.Rows[0]["secondVaccinationDate"]);
                }

                covid.secondVaccinationManufacturer = Convert.ToString(dt.Rows[0]["secondVaccinationManufacturer"]);
                if (covid.thirdVaccinationDate != null)
                {
                    covid.thirdVaccinationDate = Convert.ToDateTime(dt.Rows[0]["thirdVaccinationDate"]);
                }
                covid.thirdVaccinationManufacturer = Convert.ToString(dt.Rows[0]["thirdVaccinationManufacturer"]);
                if (covid.fourthVaccinationDate != null)
                {
                    covid.fourthVaccinationDate = Convert.ToDateTime(dt.Rows[0]["fourthVaccinationDate"]);
                }
                covid.fourthVaccinationManufacturer = Convert.ToString(dt.Rows[0]["fourthVaccinationManufacturer"]);
                if (covid.dateOfGettingPositiveResult != null)
                {
                    covid.dateOfGettingPositiveResult = Convert.ToDateTime(dt.Rows[0]["dateOfGettingPositiveResult"]);
                }
                if (covid.recoveryDate != null)
                {
                    covid.recoveryDate = Convert.ToDateTime(dt.Rows[0]["recoveryDate"]);
                }
                return JsonConvert.SerializeObject(covid);
            }
            else
            {

                response.StatusCode = 100;
                response.ErrorMessage = "no data found";
                return JsonConvert.SerializeObject(response);
            }
        }
        [HttpPost]
        [Route("AddCovidDetails")]
        public string AddCovidDetails(Covid covid)
        {
            SqlConnection con = new SqlConnection(_configuration.GetConnectionString("MemberAppCon").ToString());
            con.Open();
            string query = "SELECT TOP 1 1 FROM Members WHERE idNumber = @ForeignKeyId";
            SqlCommand command = new SqlCommand(query, con);
            command.Parameters.AddWithValue("@ForeignKeyId", covid.idMember);

            using (SqlDataReader reader = command.ExecuteReader())
            {
                if (reader.HasRows)
                {
                    SqlCommand cmd = new SqlCommand("INSERT INTO Covid19(idMember,firstVaccinationDate,firstVaccinationManufacturer,secondVaccinationDate,secondVaccinationManufacturer,thirdVaccinationDate,thirdVaccinationManufacturer,fourthVaccinationDate,fourthVaccinationManufacturer,dateOfGettingPositiveResult,recoveryDate) VALUES('" + covid.idMember + "','" + covid.fourthVaccinationDate + "','" + covid.firstVaccinationManufacturer + "','" + covid.secondVaccinationDate + "','" + covid.secondVaccinationManufacturer + "','" + covid.thirdVaccinationDate + "','" + covid.thirdVaccinationManufacturer + "','" + covid.fourthVaccinationDate + "','" + covid.fourthVaccinationManufacturer + "','" + covid.dateOfGettingPositiveResult + "','" + covid.recoveryDate + "')", con);
                    con.Close();
                    con.Open();
                    int i = cmd.ExecuteNonQuery();
                    con.Close();
                    if (i > 0)
                    {
                        return "data inserted";
                    }
                    else
                    {
                        return "Error";
                    }
                }
                return "this member is not exist";
            }

        }

    }
}
