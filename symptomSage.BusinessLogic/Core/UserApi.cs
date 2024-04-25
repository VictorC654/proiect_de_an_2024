using System;
using System.ComponentModel.DataAnnotations;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Web;
using symptomSage.BusinessLogic.DBModel;
using symptomSage.Domain.Entities.User;
using symptomSage.Helpers;
using EntityState = System.Data.EntityState;

namespace symptomSage.BusinessLogic.Core
{
    public class UserApi : SymptomApi
    {
        internal ULoginResp ULoginAction(ULoginData data)
        {
            UDbTable result;
            var validate = new EmailAddressAttribute();

            var pass = LoginHelper.HashGen(data.Password);
            using (var db = new UserContext())
            {
                result = db.Users.FirstOrDefault(u => (u.Email == data.Credential || u.Username == data.Credential) && u.Password == pass);
            }

            if (result == null)
            {
                return new ULoginResp
                {
                    Status = false,
                    StatusMsg = "Adresa de email sau parola este incorectă."
                };
            }

            using (var todo = new UserContext())
            {
                result.LasIp = data.LoginIP;
                result.LastLogin = data.LoginDateTime;
                // result.Level = 0;
                todo.Entry(result).State = (System.Data.Entity.EntityState)EntityState.Modified;
                try
                {
                    todo.SaveChanges();
                }
                catch (System.Data.Entity.Validation.DbEntityValidationException dbEx)
                {
                    Exception raise = dbEx;  
                    foreach (var validationErrors in dbEx.EntityValidationErrors)  
                    {  
                        foreach (var validationError in validationErrors.ValidationErrors)  
                        {  
                            string message = string.Format("{0}:{1}",  
                                validationErrors.Entry.Entity.ToString(),  
                                validationError.ErrorMessage);  
                            raise = new InvalidOperationException(message, raise);  
                        }  
                    }  
                    throw raise;  
                }
            }
            return new ULoginResp { 
                Status = true,                     
                StatusMsg = "Success"
            };
        }
        
        internal URegisterResp URegisterAction(URegisterData data)
        {
            var pass = LoginHelper.HashGen(data.Password);
            UDbTable insert = new UDbTable
            {
                Username = data.Username,
                Password = pass,
                Email = data.Email,
                Level = Domain.Enums.URole.User,
                RegisterDate = DateTime.Now,
            };
            int result;

            using (var db = new UserContext())
            {
                db.Users.Add(insert);
                result = db.SaveChanges();
            }

            if (result == 0)
            {
                return new URegisterResp
                {
                    Status = false,
                    StatusMsg = "Datele nu au putut fi salvate"
                };
            }
            return new URegisterResp
            {
                Status = true
            };
        }
        
        internal HttpCookie Cookie(string loginCredential)
        {
            var apiCookie = new HttpCookie("X-KEY")
            {
                Value = CookieGenerator.Create(loginCredential)
            };

            using (var db = new SessionContext())
            {
                Session curent;
                var validate = new EmailAddressAttribute();
                if (validate.IsValid(loginCredential))
                {
                    curent = (from e in db.Sessions where e.Username == loginCredential select e).FirstOrDefault();
                }
                else
                {
                    curent = (from e in db.Sessions where e.Username == loginCredential select e).FirstOrDefault();
                }

                if (curent != null)
                {
                    curent.CookieString = apiCookie.Value;
                    curent.ExpireTime = DateTime.Now.AddMinutes(60);
                    using (var todo = new SessionContext())
                    {
                        todo.Entry(curent).State = (System.Data.Entity.EntityState)EntityState.Modified;
                        todo.SaveChanges();
                    }
                }
                else
                {
                    db.Sessions.Add(new Session
                    {
                        Username = loginCredential,
                        CookieString = apiCookie.Value,
                        ExpireTime = DateTime.Now.AddMinutes(60)
                    });
                    db.SaveChanges();
                }
            }

            return apiCookie;
        }
        
        internal UserMinimal UserCookie(string cookie)
        {
            Session session;
            UDbTable currentUser;

            using (var db = new SessionContext())
            {
                session = db.Sessions.FirstOrDefault(s => s.CookieString == cookie && s.ExpireTime > DateTime.Now);
            }

            if (session == null) return null;
            using (var db = new UserContext())
            {
                var validate = new EmailAddressAttribute();
                if (validate.IsValid(session.Username))
                {
                    currentUser = db.Users.FirstOrDefault(u => u.Email == session.Username);
                }
                else
                {
                    currentUser = db.Users.FirstOrDefault(u => u.Username == session.Username);
                }
            }

            if (currentUser == null) return null;
            
            var userMinimal = new UserMinimal
            {
                Id = currentUser.Id,
                Username = currentUser.Username,
                Email = currentUser.Email,
                LastLogin = currentUser.LastLogin,
                LasIp = currentUser.LasIp,
                Level = currentUser.Level,
            };

            return userMinimal;
        }
    }
}