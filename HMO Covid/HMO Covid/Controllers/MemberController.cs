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
using System.Data;
using System.Data.Sql;

namespace HMO_Covid.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MemberController : ControllerBase
    {
        public readonly IConfiguration _configuration;
        public MemberController(IConfiguration configuration)
        {
            _configuration = configuration;
        }
        [HttpGet]
        [Route("GetAllMembers")]
        
        public string GetMembers()
        {
            SqlConnection con = new SqlConnection(_configuration.GetConnectionString("MemberAppCon").ToString());
            SqlDataAdapter da = new SqlDataAdapter("SELECT * FROM Members ", con);
            DataTable dt = new DataTable();
            da.Fill(dt);

            List<Member> memberList = new List<Member>();
            Response response = new Response();
            if (dt.Rows.Count > 0)
            {
                for( int i= 0; i<dt.Rows.Count; i++)
                {
                    Member member = new Member();
                    member.FirstName = Convert.ToString(dt.Rows[i]["firstName"]);
                    member.LastName = Convert.ToString(dt.Rows[i]["lastName"]);
                    member.Id = Convert.ToString(dt.Rows[i]["idNumber"]);
                    member.Address = Convert.ToString(dt.Rows[i]["address"]);
                    member.Phone = Convert.ToString(dt.Rows[i]["phone"]);
                    member.CellPhone = Convert.ToString(dt.Rows[i]["cellPhone"]);
                    member.BirthDate = Convert.ToDateTime(dt.Rows[i]["birthDate"]);
                    memberList.Add(member);
                }
                
            }

            if (memberList.Count > 0)
            {
              return  JsonConvert.SerializeObject(memberList);
            }
            else
            {
                response.StatusCode = 100;
                response.ErrorMessage = "no data found";
             return   JsonConvert.SerializeObject(response);
            }   
                

        }
        [HttpGet]
        [Route("GetMemberById/{id}")]
        public string GetMemberById(int id)
        {
            SqlConnection con = new SqlConnection(_configuration.GetConnectionString("MemberAppCon").ToString());
            SqlDataAdapter da = new SqlDataAdapter("SELECT * FROM Members WHERE idNumber='"+id+"'", con);
            DataTable dt = new DataTable();
            da.Fill(dt);
            Response response = new Response();
            if(dt.Rows.Count > 0)
            {
                Member member = new Member();
                member.FirstName = Convert.ToString(dt.Rows[0]["firstName"]);
                member.LastName = Convert.ToString(dt.Rows[0]["lastName"]);
                member.Id = Convert.ToString(dt.Rows[0]["idNumber"]);
                member.Address = Convert.ToString(dt.Rows[0]["address"]);
                member.Phone = Convert.ToString(dt.Rows[0]["phone"]);
                member.CellPhone = Convert.ToString(dt.Rows[0]["cellPhone"]);
                member.BirthDate = Convert.ToDateTime(dt.Rows[0]["birthDate"]);
                return JsonConvert.SerializeObject(member);
            }
            else
            {

                response.StatusCode = 100;
                response.ErrorMessage = "no data found";
                return JsonConvert.SerializeObject(response);
            }
        }


        [HttpPost]
        [Route("AddNewMember")]
        public string AddNewMember(Member member)
        {
            SqlConnection con = new SqlConnection(_configuration.GetConnectionString("MemberAppCon").ToString());
            con.Open();
            string query = "SELECT TOP 1 1 FROM Members WHERE idNumber = @id";
            SqlCommand command = new SqlCommand(query, con);
            command.Parameters.AddWithValue("@id", member.Id);

            using (SqlDataReader reader = command.ExecuteReader())
            {
                if(!reader.HasRows)
                {
                    SqlCommand cmd = new SqlCommand("INSERT INTO Members(firstName,lastName,idNumber,address,phone,cellPhone,birthDate) VALUES('" + member.FirstName + "','" + member.LastName + "','" + member.Id + "','" + member.Address + "','" + member.Phone + "','" + member.CellPhone + "','" + member.BirthDate + "')", con);
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
                return "this member is exist already";
            }
            
            
    

        }
    }
}
