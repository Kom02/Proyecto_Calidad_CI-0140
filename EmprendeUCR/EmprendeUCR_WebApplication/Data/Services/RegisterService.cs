using Dapper;
using EmprendeUCR_WebApplication.Data.Entities;
using EmprendeUCR_WebApplication.Data.Services;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;

namespace EmprendeUCR_WebApplication.Data.Services
{
    public class RegisterService
    {
        Registro _oRegister = new Registro();
        User _oUser = new User();
        public async Task<bool> ConfirmMail(string email)
        {
            bool emailConfirmed = false;
            try
            {
                if (!string.IsNullOrEmpty(email))
                {
                    Registro registro = new Registro()
                    {
                        Email = email,
                    };

                    emailConfirmed = await this.checkRecordExistence(registro);
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            return emailConfirmed;
        }

        public async Task<bool> Registrarse(Registro oRegistro)
        {
            bool registrar = false;
            try
            {
                registrar = await this.checkRecordExistence(oRegistro);
            }
            catch (Exception ex) 
            {
                Console.WriteLine(ex.Message);
            }
            return registrar;
        }

        public async Task<bool> checkRecordExistence(Registro oRegistro) 
        {
            bool encontrado = false;
            if (!string.IsNullOrEmpty(oRegistro.Email)) 
            {
                encontrado = await this.VerifyUserExistence(oRegistro.Email);
            }
            return encontrado;
        }

        public async Task<bool> VerifyUserExistence(string email) {
            bool retorno = false;

            using ( IDbConnection con = new SqlConnection(Global.ConnectionString)) 
            {
                if (con.State == ConnectionState.Closed) con.Open();

                string sSQL = "SELECT * FROM [User] WHERE 1=1 ";

                if (!string.IsNullOrEmpty(email)) sSQL += " AND Email='" + email + "'";

                var oUser = (await con.QueryAsync<User>(sSQL)).ToList();

                if (oUser != null && oUser.Count > 0) {
                    retorno = true;                
                }

                return retorno;
            }
        }
    }
}
