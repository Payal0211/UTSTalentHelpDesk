﻿using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using System.Net;
using UTSTalentHelpDesk.Helpers;
using UTSTalentHelpDesk.Helpers.Common;
using UTSTalentHelpDesk.Models.ComplexTypes;
using UTSTalentHelpDesk.Models.Models;
using UTSTalentHelpDesk.Repositories.Interfaces;

namespace UTSTalentHelpDesk.Repositories.Repositories
{
    public class UniversalProcRunnerRepository : IUniversalProcRunner
    {
        #region Variables
        private UTSTalentHelpDeskDBConnection db;
        private IConfiguration _configuration;
        #endregion

        #region Constructor
        public UniversalProcRunnerRepository(UTSTalentHelpDeskDBConnection _db, IConfiguration configuration)
        {
            this.db = _db;
            _configuration = configuration;
        }

        #endregion

        #region Public Methods
        public object Manipulation(string proName, object[] args)
        {
            var result = 0;
            if (!string.IsNullOrEmpty(proName))
            {
                string _arguments = string.Empty;
                if (args != null && args.Length > 0)
                {
                    for (int i = 0; i < args.Length; i++)
                    {
                        args[i] = (args[i] == null) ? string.Empty : args[i];
                        if (i == args.Length - 1)
                        {
                            if (CommonLogic.CheckIsString(args[i]))
                                _arguments += "'" + args[i] + "'";
                            else
                                _arguments += args[i];
                        }
                        else
                        {
                            if (CommonLogic.CheckIsString(args[i]))
                                _arguments += "'" + args[i] + "',";
                            else
                                _arguments += args[i] + ",";
                        }
                    }
                    int j = 0;
                    result = db.Database.ExecuteSqlRaw(String.Format("{0} {1}", proName, _arguments));
                }
            }
            return result;
        }

        public object ManipulationWithNULL(string proName, object[] args)
        {
            var result = 0;
            if (!string.IsNullOrEmpty(proName))
            {
                string _arguments = string.Empty;
                if (args.Length > 0)
                {
                    for (int i = 0; i < args.Length; i++)
                    {
                        if (args[i] == null)
                        {
                            if (i == args.Length - 1)
                            {
                                _arguments += "null";
                            }
                            else
                            {
                                _arguments += "null" + ",";
                            }
                        }
                        else
                        {
                            if (i == args.Length - 1)
                            {
                                if (CommonLogic.CheckIsString(args[i]))
                                {
                                    string value = args[i].ToString();
                                    if (!string.IsNullOrEmpty(value))
                                    {
                                        _arguments += "'" + Convert.ToString(args[i]).Replace("'", "''") + "'";
                                    }
                                    else
                                    {
                                        _arguments += "'" + args[i] + "'";
                                    }
                                }
                                else
                                {
                                    _arguments += args[i];
                                }
                            }
                            else
                            {
                                if (CommonLogic.CheckIsString(args[i]))
                                {
                                    string value = args[i].ToString();
                                    if (!string.IsNullOrEmpty(value))
                                    {
                                        _arguments += "'" + Convert.ToString(args[i]).Replace("'", "''") + "',";
                                    }
                                    else
                                    {
                                        _arguments += "'" + args[i] + "',";
                                    }
                                }
                                else
                                {
                                    _arguments += args[i] + ",";
                                }
                            }
                        }
                    }
                    result = db.Database.ExecuteSqlRaw(String.Format("{0} {1}", proName, _arguments));
                }
            }
            return result;
        }

        public void InsertReactPayload(GenUtsadminReactPayload genUtsadminReactPayload)
        {
            if (genUtsadminReactPayload != null)
            {
                db.GenUtsadminReactPayloads.Add(genUtsadminReactPayload);
                db.SaveChanges();
            }
        }
        #endregion
    }
}

